using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    partial class Form2
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.messageBox = new System.Windows.Forms.TextBox();
            this.sendMessageBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.joinButton = new System.Windows.Forms.Button();
            this.leaveTopic = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.listTopics = new System.Windows.Forms.ListBox();
            this.listTopicsLabel = new System.Windows.Forms.Label();
            this.chatLabel = new System.Windows.Forms.Label();
            this.topicMembersLabel = new System.Windows.Forms.Label();
            this.listMembers = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // messageBox
            // 
            this.messageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.messageBox.Location = new System.Drawing.Point(208, 69);
            this.messageBox.Multiline = true;
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(510, 379);
            this.messageBox.TabIndex = 0;
            // 
            // sendMessageBox
            // 
            this.sendMessageBox.Enabled = false;
            this.sendMessageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sendMessageBox.Location = new System.Drawing.Point(208, 462);
            this.sendMessageBox.Multiline = true;
            this.sendMessageBox.Name = "sendMessageBox";
            this.sendMessageBox.Size = new System.Drawing.Size(418, 78);
            this.sendMessageBox.TabIndex = 1;
            // 
            // sendButton
            // 
            this.sendButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sendButton.BackgroundImage")));
            this.sendButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.sendButton.Enabled = false;
            this.sendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.sendButton.Location = new System.Drawing.Point(639, 461);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(80, 80);
            this.sendButton.TabIndex = 2;
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // joinButton
            // 
            this.joinButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("joinButton.BackgroundImage")));
            this.joinButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.joinButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.joinButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.joinButton.Location = new System.Drawing.Point(13, 307);
            this.joinButton.Name = "joinButton";
            this.joinButton.Size = new System.Drawing.Size(57, 36);
            this.joinButton.TabIndex = 5;
            this.toolTip1.SetToolTip(this.joinButton, "Join topic");
            this.joinButton.UseVisualStyleBackColor = true;
            this.joinButton.Click += new System.EventHandler(this.joinButton_Click);
            // 
            // leaveTopic
            // 
            this.leaveTopic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("leaveTopic.BackgroundImage")));
            this.leaveTopic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.leaveTopic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.leaveTopic.Enabled = false;
            this.leaveTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.leaveTopic.Location = new System.Drawing.Point(76, 307);
            this.leaveTopic.Name = "leaveTopic";
            this.leaveTopic.Size = new System.Drawing.Size(57, 36);
            this.leaveTopic.TabIndex = 6;
            this.toolTip1.SetToolTip(this.leaveTopic, "Leave topic");
            this.leaveTopic.UseVisualStyleBackColor = true;
            this.leaveTopic.Click += new System.EventHandler(this.leaveTopic_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("refreshButton.BackgroundImage")));
            this.refreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.refreshButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.refreshButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.refreshButton.Location = new System.Drawing.Point(138, 307);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(57, 36);
            this.refreshButton.TabIndex = 12;
            this.toolTip1.SetToolTip(this.refreshButton, "Refresh topics");
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refresh_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.topicToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(732, 28);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menu";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disconnectToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // topicToolStripMenuItem
            // 
            this.topicToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.topicToolStripMenuItem.Name = "topicToolStripMenuItem";
            this.topicToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.topicToolStripMenuItem.Text = "Topic";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.addToolStripMenuItem.Text = "Add topic";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 500;
            this.toolTip1.ShowAlways = true;
            // 
            // listTopics
            // 
            this.listTopics.FormattingEnabled = true;
            this.listTopics.ItemHeight = 16;
            this.listTopics.Location = new System.Drawing.Point(13, 69);
            this.listTopics.Name = "listTopics";
            this.listTopics.Size = new System.Drawing.Size(182, 228);
            this.listTopics.TabIndex = 15;
            // 
            // listTopicsLabel
            // 
            this.listTopicsLabel.AutoSize = true;
            this.listTopicsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listTopicsLabel.Location = new System.Drawing.Point(12, 41);
            this.listTopicsLabel.Name = "listTopicsLabel";
            this.listTopicsLabel.Size = new System.Drawing.Size(97, 20);
            this.listTopicsLabel.TabIndex = 16;
            this.listTopicsLabel.Text = "List topics :";
            // 
            // chatLabel
            // 
            this.chatLabel.AutoSize = true;
            this.chatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.chatLabel.Location = new System.Drawing.Point(205, 41);
            this.chatLabel.Name = "chatLabel";
            this.chatLabel.Size = new System.Drawing.Size(44, 20);
            this.chatLabel.TabIndex = 17;
            this.chatLabel.Text = "Chat";
            // 
            // topicMembersLabel
            // 
            this.topicMembersLabel.AutoSize = true;
            this.topicMembersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.topicMembersLabel.Location = new System.Drawing.Point(12, 347);
            this.topicMembersLabel.Name = "topicMembersLabel";
            this.topicMembersLabel.Size = new System.Drawing.Size(135, 20);
            this.topicMembersLabel.TabIndex = 18;
            this.topicMembersLabel.Text = "Topic members :";
            // 
            // listMembers
            // 
            this.listMembers.FormattingEnabled = true;
            this.listMembers.ItemHeight = 16;
            this.listMembers.Location = new System.Drawing.Point(13, 377);
            this.listMembers.Name = "listMembers";
            this.listMembers.Size = new System.Drawing.Size(182, 164);
            this.listMembers.TabIndex = 19;
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(732, 553);
            this.Controls.Add(this.listMembers);
            this.Controls.Add(this.topicMembersLabel);
            this.Controls.Add(this.chatLabel);
            this.Controls.Add(this.listTopicsLabel);
            this.Controls.Add(this.listTopics);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.leaveTopic);
            this.Controls.Add(this.joinButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.sendMessageBox);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.TextBox sendMessageBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button joinButton;
        private System.Windows.Forms.Button leaveTopic;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private ToolTip toolTip1;
        private ListBox listTopics;
        private Label listTopicsLabel;
        private Label chatLabel;
        private Label topicMembersLabel;
        private ListBox listMembers;
    }
}