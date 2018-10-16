namespace TFSCreate
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboBoxWorkItemType = new System.Windows.Forms.ComboBox();
            this.labelWorkItemType = new System.Windows.Forms.Label();
            this.labelWorkItemTitle = new System.Windows.Forms.Label();
            this.textBoxWorkItemTitle = new System.Windows.Forms.TextBox();
            this.labelWorkItemDescription = new System.Windows.Forms.Label();
            this.richTextBoxWorkItemDescription = new System.Windows.Forms.RichTextBox();
            this.listBoxAttachedFiles = new System.Windows.Forms.ListBox();
            this.buttonGetFiles = new System.Windows.Forms.Button();
            this.buttonAddAttachment = new System.Windows.Forms.Button();
            this.buttonNewPlanBrowsePath = new System.Windows.Forms.Button();
            this.textBoxNewAttachmentPath = new System.Windows.Forms.TextBox();
            this.groupBoxWorkItemFiles = new System.Windows.Forms.GroupBox();
            this.labelDragNotification = new System.Windows.Forms.Label();
            this.buttonCreateWorkItem = new System.Windows.Forms.Button();
            this.labelWorkItemIteration = new System.Windows.Forms.Label();
            this.comboBoxWorkItemIteration = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.checkBoxResetFields = new System.Windows.Forms.CheckBox();
            this.groupBoxWorkItemFiles.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxWorkItemType
            // 
            this.comboBoxWorkItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWorkItemType.FormattingEnabled = true;
            this.comboBoxWorkItemType.Items.AddRange(new object[] {
            "Bug",
            "Product Backlog Item"});
            this.comboBoxWorkItemType.Location = new System.Drawing.Point(86, 58);
            this.comboBoxWorkItemType.Name = "comboBoxWorkItemType";
            this.comboBoxWorkItemType.Size = new System.Drawing.Size(154, 21);
            this.comboBoxWorkItemType.TabIndex = 2;
            // 
            // labelWorkItemType
            // 
            this.labelWorkItemType.AutoSize = true;
            this.labelWorkItemType.Location = new System.Drawing.Point(12, 61);
            this.labelWorkItemType.Name = "labelWorkItemType";
            this.labelWorkItemType.Size = new System.Drawing.Size(68, 13);
            this.labelWorkItemType.TabIndex = 1;
            this.labelWorkItemType.Text = "Type of item:";
            // 
            // labelWorkItemTitle
            // 
            this.labelWorkItemTitle.AutoSize = true;
            this.labelWorkItemTitle.Location = new System.Drawing.Point(12, 9);
            this.labelWorkItemTitle.Name = "labelWorkItemTitle";
            this.labelWorkItemTitle.Size = new System.Drawing.Size(30, 13);
            this.labelWorkItemTitle.TabIndex = 2;
            this.labelWorkItemTitle.Text = "Title:";
            // 
            // textBoxWorkItemTitle
            // 
            this.textBoxWorkItemTitle.Location = new System.Drawing.Point(48, 6);
            this.textBoxWorkItemTitle.Name = "textBoxWorkItemTitle";
            this.textBoxWorkItemTitle.Size = new System.Drawing.Size(305, 20);
            this.textBoxWorkItemTitle.TabIndex = 0;
            // 
            // labelWorkItemDescription
            // 
            this.labelWorkItemDescription.AutoSize = true;
            this.labelWorkItemDescription.Location = new System.Drawing.Point(12, 89);
            this.labelWorkItemDescription.Name = "labelWorkItemDescription";
            this.labelWorkItemDescription.Size = new System.Drawing.Size(63, 13);
            this.labelWorkItemDescription.TabIndex = 4;
            this.labelWorkItemDescription.Text = "Description:";
            // 
            // richTextBoxWorkItemDescription
            // 
            this.richTextBoxWorkItemDescription.Location = new System.Drawing.Point(81, 85);
            this.richTextBoxWorkItemDescription.Name = "richTextBoxWorkItemDescription";
            this.richTextBoxWorkItemDescription.Size = new System.Drawing.Size(272, 127);
            this.richTextBoxWorkItemDescription.TabIndex = 3;
            this.richTextBoxWorkItemDescription.Text = "";
            // 
            // listBoxAttachedFiles
            // 
            this.listBoxAttachedFiles.AllowDrop = true;
            this.listBoxAttachedFiles.FormattingEnabled = true;
            this.listBoxAttachedFiles.HorizontalScrollbar = true;
            this.listBoxAttachedFiles.Location = new System.Drawing.Point(6, 50);
            this.listBoxAttachedFiles.Name = "listBoxAttachedFiles";
            this.listBoxAttachedFiles.Size = new System.Drawing.Size(335, 95);
            this.listBoxAttachedFiles.TabIndex = 6;
            this.listBoxAttachedFiles.TabStop = false;
            this.listBoxAttachedFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBoxAttachedFiles_DragDrop);
            this.listBoxAttachedFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBoxAttachedFiles_DragEnter);
            this.listBoxAttachedFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxAttachedFiles_KeyDown);
            this.listBoxAttachedFiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxAttachedFiles_MouseDown);
            this.listBoxAttachedFiles.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBoxAttachedFiles_MouseMove);
            // 
            // buttonGetFiles
            // 
            this.buttonGetFiles.Location = new System.Drawing.Point(6, 21);
            this.buttonGetFiles.Name = "buttonGetFiles";
            this.buttonGetFiles.Size = new System.Drawing.Size(82, 23);
            this.buttonGetFiles.TabIndex = 4;
            this.buttonGetFiles.Text = "Get User Files";
            this.buttonGetFiles.UseVisualStyleBackColor = true;
            this.buttonGetFiles.Click += new System.EventHandler(this.buttonGetFiles_Click);
            // 
            // buttonAddAttachment
            // 
            this.buttonAddAttachment.Location = new System.Drawing.Point(305, 151);
            this.buttonAddAttachment.Name = "buttonAddAttachment";
            this.buttonAddAttachment.Size = new System.Drawing.Size(36, 23);
            this.buttonAddAttachment.TabIndex = 27;
            this.buttonAddAttachment.TabStop = false;
            this.buttonAddAttachment.Text = "Add";
            this.buttonAddAttachment.UseVisualStyleBackColor = true;
            this.buttonAddAttachment.Click += new System.EventHandler(this.buttonNewPlanAdd_Click);
            // 
            // buttonNewPlanBrowsePath
            // 
            this.buttonNewPlanBrowsePath.Location = new System.Drawing.Point(240, 150);
            this.buttonNewPlanBrowsePath.Name = "buttonNewPlanBrowsePath";
            this.buttonNewPlanBrowsePath.Size = new System.Drawing.Size(25, 23);
            this.buttonNewPlanBrowsePath.TabIndex = 7;
            this.buttonNewPlanBrowsePath.TabStop = false;
            this.buttonNewPlanBrowsePath.Text = "...";
            this.buttonNewPlanBrowsePath.UseVisualStyleBackColor = true;
            this.buttonNewPlanBrowsePath.Click += new System.EventHandler(this.buttonNewPlanBrowsePath_Click);
            // 
            // textBoxNewAttachmentPath
            // 
            this.textBoxNewAttachmentPath.Location = new System.Drawing.Point(6, 151);
            this.textBoxNewAttachmentPath.Name = "textBoxNewAttachmentPath";
            this.textBoxNewAttachmentPath.Size = new System.Drawing.Size(228, 20);
            this.textBoxNewAttachmentPath.TabIndex = 6;
            this.textBoxNewAttachmentPath.TabStop = false;
            // 
            // groupBoxWorkItemFiles
            // 
            this.groupBoxWorkItemFiles.Controls.Add(this.labelDragNotification);
            this.groupBoxWorkItemFiles.Controls.Add(this.listBoxAttachedFiles);
            this.groupBoxWorkItemFiles.Controls.Add(this.buttonAddAttachment);
            this.groupBoxWorkItemFiles.Controls.Add(this.buttonGetFiles);
            this.groupBoxWorkItemFiles.Controls.Add(this.buttonNewPlanBrowsePath);
            this.groupBoxWorkItemFiles.Controls.Add(this.textBoxNewAttachmentPath);
            this.groupBoxWorkItemFiles.Location = new System.Drawing.Point(12, 218);
            this.groupBoxWorkItemFiles.Name = "groupBoxWorkItemFiles";
            this.groupBoxWorkItemFiles.Size = new System.Drawing.Size(348, 180);
            this.groupBoxWorkItemFiles.TabIndex = 28;
            this.groupBoxWorkItemFiles.TabStop = false;
            this.groupBoxWorkItemFiles.Text = "Files";
            // 
            // labelDragNotification
            // 
            this.labelDragNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDragNotification.Location = new System.Drawing.Point(218, 19);
            this.labelDragNotification.Name = "labelDragNotification";
            this.labelDragNotification.Size = new System.Drawing.Size(123, 28);
            this.labelDragNotification.TabIndex = 28;
            this.labelDragNotification.Text = "You can also drag files into the box below";
            // 
            // buttonCreateWorkItem
            // 
            this.buttonCreateWorkItem.Location = new System.Drawing.Point(282, 447);
            this.buttonCreateWorkItem.Name = "buttonCreateWorkItem";
            this.buttonCreateWorkItem.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateWorkItem.TabIndex = 5;
            this.buttonCreateWorkItem.Text = "Create Item";
            this.buttonCreateWorkItem.UseVisualStyleBackColor = true;
            this.buttonCreateWorkItem.Click += new System.EventHandler(this.buttonCreateWorkItem_Click);
            // 
            // labelWorkItemIteration
            // 
            this.labelWorkItemIteration.AutoSize = true;
            this.labelWorkItemIteration.Location = new System.Drawing.Point(12, 34);
            this.labelWorkItemIteration.Name = "labelWorkItemIteration";
            this.labelWorkItemIteration.Size = new System.Drawing.Size(48, 13);
            this.labelWorkItemIteration.TabIndex = 31;
            this.labelWorkItemIteration.Text = "Iteration:";
            // 
            // comboBoxWorkItemIteration
            // 
            this.comboBoxWorkItemIteration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWorkItemIteration.FormattingEnabled = true;
            this.comboBoxWorkItemIteration.Location = new System.Drawing.Point(86, 31);
            this.comboBoxWorkItemIteration.Name = "comboBoxWorkItemIteration";
            this.comboBoxWorkItemIteration.Size = new System.Drawing.Size(267, 21);
            this.comboBoxWorkItemIteration.TabIndex = 1;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(121, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.MarqueeAnimationSpeed = 20;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 16);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 473);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(369, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 32;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // checkBoxResetFields
            // 
            this.checkBoxResetFields.AutoSize = true;
            this.checkBoxResetFields.Location = new System.Drawing.Point(12, 453);
            this.checkBoxResetFields.Name = "checkBoxResetFields";
            this.checkBoxResetFields.Size = new System.Drawing.Size(146, 17);
            this.checkBoxResetFields.TabIndex = 33;
            this.checkBoxResetFields.Text = "Reset fields after creating";
            this.checkBoxResetFields.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 495);
            this.Controls.Add(this.checkBoxResetFields);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.labelWorkItemIteration);
            this.Controls.Add(this.comboBoxWorkItemIteration);
            this.Controls.Add(this.buttonCreateWorkItem);
            this.Controls.Add(this.groupBoxWorkItemFiles);
            this.Controls.Add(this.richTextBoxWorkItemDescription);
            this.Controls.Add(this.labelWorkItemDescription);
            this.Controls.Add(this.textBoxWorkItemTitle);
            this.Controls.Add(this.labelWorkItemTitle);
            this.Controls.Add(this.labelWorkItemType);
            this.Controls.Add(this.comboBoxWorkItemType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "TFS Create";
            this.groupBoxWorkItemFiles.ResumeLayout(false);
            this.groupBoxWorkItemFiles.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxWorkItemType;
        private System.Windows.Forms.Label labelWorkItemType;
        private System.Windows.Forms.Label labelWorkItemTitle;
        private System.Windows.Forms.TextBox textBoxWorkItemTitle;
        private System.Windows.Forms.Label labelWorkItemDescription;
        private System.Windows.Forms.RichTextBox richTextBoxWorkItemDescription;
        private System.Windows.Forms.ListBox listBoxAttachedFiles;
        private System.Windows.Forms.Button buttonGetFiles;
        private System.Windows.Forms.Button buttonAddAttachment;
        private System.Windows.Forms.Button buttonNewPlanBrowsePath;
        private System.Windows.Forms.TextBox textBoxNewAttachmentPath;
        private System.Windows.Forms.GroupBox groupBoxWorkItemFiles;
        private System.Windows.Forms.Button buttonCreateWorkItem;
        private System.Windows.Forms.Label labelWorkItemIteration;
        private System.Windows.Forms.ComboBox comboBoxWorkItemIteration;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label labelDragNotification;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.CheckBox checkBoxResetFields;
    }
}

