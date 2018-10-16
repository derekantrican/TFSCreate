using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Server;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TFSCreate
{
    /*
     * Todo:
     * 
     * Need to have the ability to "assign self" (checkbox)
     * Need to have the ability to assign a developer to the dev task (how hard is this - and the next one - since those items are created by the server? Would probably require a second call)
     * Need to have the ability to assign a tester to the test task
     * Need to be able to save the above settings to a xml
     * 
     * Need to have the ability to set "Committed" state on items
     * 
     * Fields requested by Paul: https://i.imgur.com/bhaQCvS.png (along with "Found in Build" - that should be saved to Settings file)
     * Rough UI requested by Paul: https://i.imgur.com/1OiaQul.png
     * 
     */

    public partial class Form1 : Form
    {
        Project ownersProject;
        Node sxAreaNode;
        public Form1()
        {
            InitializeComponent();

            UpdateStatusMessage("Initializing...");
            SetFormControlsEnabled(false);

            comboBoxWorkItemType.SelectedIndex = 0;

            Task initializeTask = new Task(() => InitializeTFS());
            initializeTask.Start();
            initializeTask.ContinueWith((_) => { SetFormReady(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void SetFormControlsEnabled(bool enabled)
        {
            //Only modify the ones that are directly dependent on information from TFS
            comboBoxWorkItemIteration.Enabled = enabled;
            buttonCreateWorkItem.Enabled = enabled;
        }

        private void SetFormReady()
        {
            SetFormControlsEnabled(true);
            StopMarqueeBar();
            UpdateStatusMessage("Ready");
        }

        private void InitializeTFS()
        {
            int tries = 5;
            while (true)
            {
                try
                {
                    #region TFS Initialization
                    //Credit: https://www.pmichaels.net/2016/11/23/programmatically-create-a-bug-in-tfs/
                    TfsTeamProjectCollection tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri("https://tfs.sigmatek.net/SigmaTEK"));
                    tfs.Authenticate();

                    WorkItemStore workItemStore = new WorkItemStore(tfs);
                    ownersProject = (from Project pr in workItemStore.Projects
                                     where pr.Name == "Owners"
                                     select pr).FirstOrDefault();

                    //foreach (WorkItemType w in ownersProject.WorkItemTypes)
                    //    Console.WriteLine(w.Name);

                    sxAreaNode = (from Node n in ownersProject.AreaRootNodes
                                  where n.Name == "SigmaNEST SX"
                                  select n).FirstOrDefault();

                    Node sxIterationNode = (from Node n in ownersProject.IterationRootNodes
                                            where n.Name == "SigmaNEST SX"
                                            select n).FirstOrDefault();

                    ICommonStructureService4 css = tfs.GetService<ICommonStructureService4>();
                    NodeInfo sxNode = css.GetNode(sxIterationNode.Uri.ToString());
                    XmlElement iterationsTree = css.GetNodesXml(new[] { sxNode.Uri }, true);

                    comboBoxWorkItemIteration.Invoke((MethodInvoker)delegate
                    {
                        comboBoxWorkItemIteration.Items.Add("[BACKLOG] Owners"); //Manually add the backlog to the iteration options
                        comboBoxWorkItemIteration.SelectedIndex = 0;
                    });

                    GetIterations(iterationsTree.ChildNodes, css, ownersProject.Name);
                    #endregion TFS Initialization

                    break;
                }
                catch (Exception ex)
                {
                    tries--;

                    if (tries == 0)
                    {
                        MessageBox.Show("Could not connect to TFS\n\n" + ex.Message);
                        Environment.Exit(1);
                    }
                }
            }
        }

        private void GetIterations(XmlNodeList subItems, ICommonStructureService4 css, string ProjectName)
        {
            foreach (XmlNode node in subItems)
            {
                var nodeId = GetNodeID(node.OuterXml);
                var nodeInfo = css.GetNode(nodeId);

                string iterationToAdd = nodeInfo.Path;
                iterationToAdd = iterationToAdd.TrimStart('\\');
                iterationToAdd = iterationToAdd.Replace("\\Iteration", "");

                comboBoxWorkItemIteration.Invoke((MethodInvoker)delegate
                {
                    if (!comboBoxWorkItemIteration.Items.Contains(iterationToAdd))
                        comboBoxWorkItemIteration.Items.Add(iterationToAdd);
                });

                UpdateComboBoxDropDownWidth(iterationToAdd);
                if (nodeInfo.StartDate.HasValue && nodeInfo.FinishDate.HasValue)
                {
                    if (DateTime.Now.Date >= nodeInfo.StartDate.Value.Date && DateTime.Now.Date <= nodeInfo.FinishDate.Value.Date && node.ChildNodes.Count <= 0)
                    {
                        Console.WriteLine("CURRENT SPRINT: " + nodeInfo.Path);

                        string currentIteration = nodeInfo.Path;
                        currentIteration = currentIteration.TrimStart('\\');
                        currentIteration = currentIteration.Replace("\\Iteration", "");

                        comboBoxWorkItemIteration.Invoke((MethodInvoker)delegate
                        {
                            int index = comboBoxWorkItemIteration.Items.IndexOf(currentIteration);
                            comboBoxWorkItemIteration.Items.RemoveAt(index);
                            currentIteration = "[CURRENT] " + currentIteration;
                            comboBoxWorkItemIteration.Items.Insert(index, currentIteration);
                            //comboBoxWorkItemIteration.SelectedIndex = index;
                        });

                        UpdateComboBoxDropDownWidth(currentIteration);
                    }
                }

                if (node.ChildNodes.Count > 0)
                {
                    Console.WriteLine("GETTING CHILD OF " + nodeInfo.Path);
                    GetIterations(node.ChildNodes, css, ProjectName);
                }
            }
        }

        private string GetNodeID(string xml)
        {
            var first = "NodeID=\"";
            var start = xml.IndexOf(first) + first.Length;
            var end = xml.IndexOf("\"", start);
            return xml.Substring(start, (end - start));
        }

        private void UpdateComboBoxDropDownWidth(string referenceText)
        {
            //Apparently "MeasureText" is known to be inaccurate sometimes. So I've added a "saftey margin" to the end
            comboBoxWorkItemIteration.Invoke((MethodInvoker)delegate
            {
                comboBoxWorkItemIteration.DropDownWidth = TextRenderer.MeasureText(referenceText, comboBoxWorkItemIteration.Font).Width + 
                                                          SystemInformation.VerticalScrollBarWidth + 50;
            });
        }

        private void buttonNewPlanBrowsePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxNewAttachmentPath.Text = fileDialog.FileName;
                toolTip1.SetToolTip(textBoxNewAttachmentPath, fileDialog.FileName);
            }
        }

        private void buttonNewPlanAdd_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBoxNewAttachmentPath.Text))
            {
                //Don't need to verify file size (though we could do it here if we wanted) because newItem.Save() below will thrown an exception if the file is too large
                listBoxAttachedFiles.Items.Add(textBoxNewAttachmentPath.Text);
                textBoxNewAttachmentPath.Text = "";
            }
        }

        private void buttonGetFiles_Click(object sender, EventArgs e)
        {
            string sxAppDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SigmaNEST SX");
            string logFile = Path.Combine(sxAppDataFolder, "SigmaNEST SX.log");
            if (File.Exists(logFile))
                listBoxAttachedFiles.Items.Add(logFile);

            string applicationSettings = Path.Combine(sxAppDataFolder, "SXApplicationSettings.xml");
            if (File.Exists(applicationSettings))
                listBoxAttachedFiles.Items.Add(applicationSettings);
        }

        private void buttonCreateWorkItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxNewAttachmentPath.Text))
            {
                if (MessageBox.Show("You selected a file, but didn't add it to the list of files to attach. Did you want to include " + textBoxNewAttachmentPath.Text + " ?",
                                    "File selected but not added", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    buttonNewPlanAdd_Click(null, null);
                }
            }

            StartMarqueeBar();

            WorkItemType itemType = ownersProject.WorkItemTypes[comboBoxWorkItemType.SelectedItem.ToString()];
            WorkItem newItem = new WorkItem(itemType);
            newItem.Title = textBoxWorkItemTitle.Text;

            if (comboBoxWorkItemType.SelectedItem.ToString() == "Bug")
                newItem.Fields["Repro Steps"].Value = richTextBoxWorkItemDescription.Text;
            else if (comboBoxWorkItemType.SelectedItem.ToString() == "Product Backlog Item")
                newItem.Description = richTextBoxWorkItemDescription.Text;

            newItem.AreaPath = sxAreaNode.Path;

            string iteration = comboBoxWorkItemIteration.SelectedItem.ToString();

            //Clean up anything extra that may have been put on for comboBox display
            iteration = iteration.Replace("[BACKLOG] ", "").Replace("[CURRENT] ", "");

            newItem.IterationPath = iteration;

            foreach (string file in listBoxAttachedFiles.Items)
                newItem.Attachments.Add(new Attachment(file, Path.GetFileNameWithoutExtension(file)));

            //newItem.Fields["Assigned To"].Value = 

            var validationResult = newItem.Validate();
            List<string> errorList = new List<string>();
            foreach (var res in validationResult)
            {
                Field field = res as Field;
                if (field == null)
                    errorList.Add(res.ToString());
                else
                    errorList.Add($"Error with: {field.Name}");
            }

            if (errorList.Count == 0)
            {
                UpdateStatusMessage("Adding item...");
                try
                {
                    newItem.Save();

                    MessageBoxManager.Cancel = "Open";
                    MessageBoxManager.Register();
                    DialogResult res = MessageBox.Show("Item Added!", "", MessageBoxButtons.OKCancel);
                    MessageBoxManager.Unregister();

                    if (res == DialogResult.Cancel) //Open item
                        Process.Start("https://tfs.sigmatek.net/SigmaTEK/Owners/SigmaNEST%20SX/_workitems/edit/" + newItem.Id);
                }
                catch (Exception ex)
                {
                    errorList.Add(ex.Message);
                }
            }

            if (errorList.Count > 0) //Export errors
            {
                UpdateStatusMessage("Problems with item");
                MessageBox.Show("Error adding item: \n\n" + string.Join("\n", errorList));
            }

            if (errorList.Count == 0 && checkBoxResetFields.Checked)
            {
                textBoxWorkItemTitle.Text = "";
                richTextBoxWorkItemDescription.Text = "";
                listBoxAttachedFiles.Items.Clear();
                textBoxNewAttachmentPath.Text = "";
            }

            StopMarqueeBar();
            UpdateStatusMessage("Ready");
        }

        private void UpdateStatusMessage(string text)
        {
            toolStripStatusLabel1.Text = text;
            statusStrip1.Update();
        }

        private void StartMarqueeBar(int speed = 20)
        {
            toolStripProgressBar1.Visible = true;
            toolStripProgressBar1.MarqueeAnimationSpeed = speed;
        }

        private void StopMarqueeBar()
        {
            toolStripProgressBar1.Visible = false;
            toolStripProgressBar1.MarqueeAnimationSpeed = 0;
        }

        private void listBoxAttachedFiles_MouseMove(object sender, MouseEventArgs e)
        {
            int index = listBoxAttachedFiles.IndexFromPoint(e.Location);
            if (index >= 0)
                toolTip1.SetToolTip(listBoxAttachedFiles, listBoxAttachedFiles.Items[index].ToString());
            else
                toolTip1.SetToolTip(listBoxAttachedFiles, "");
        }

        private void listBoxAttachedFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void listBoxAttachedFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
                listBoxAttachedFiles.Items.Add(file);
        }

        private void listBoxAttachedFiles_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = this.listBoxAttachedFiles.IndexFromPoint(new Point(e.X, e.Y));

                if (index < 0)
                    return;

                this.listBoxAttachedFiles.SelectedIndex = index;

                ContextMenu removeMenu = new ContextMenu();
                MenuItem removeItem = new MenuItem() { Text = "Remove" };
                removeItem.Click += (s, args) => { listBoxAttachedFiles.Items.RemoveAt(index); };
                removeMenu.MenuItems.Add(removeItem);
                removeMenu.Show((sender as ListBox), new Point(e.X, e.Y));
            }
        }

        private void listBoxAttachedFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                listBoxAttachedFiles.Items.RemoveAt(listBoxAttachedFiles.SelectedIndex);
        }
    }
}