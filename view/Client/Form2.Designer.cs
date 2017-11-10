using System;

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
            this.messageBox = new System.Windows.Forms.TextBox();
            this.sendMessageBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.listTopicsBox = new System.Windows.Forms.TextBox();
            this.selectTopicBox = new System.Windows.Forms.DomainUpDown();
            this.joinButton = new System.Windows.Forms.Button();
            this.leaveTopic = new System.Windows.Forms.Button();
            this.addTopicBox = new System.Windows.Forms.TextBox();
            this.addTopicButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // messageBox
            // 
            this.messageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.messageBox.Location = new System.Drawing.Point(208, 13);
            this.messageBox.Multiline = true;
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(510, 435);
            this.messageBox.TabIndex = 0;
            // 
            // sendMessageBox
            // 
            this.sendMessageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sendMessageBox.Location = new System.Drawing.Point(208, 462);
            this.sendMessageBox.Multiline = true;
            this.sendMessageBox.Name = "sendMessageBox";
            this.sendMessageBox.Size = new System.Drawing.Size(418, 78);
            this.sendMessageBox.TabIndex = 1;
            // 
            // sendButton
            // 
            this.sendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.sendButton.Location = new System.Drawing.Point(639, 461);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(80, 80);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // listTopicsBox
            // 
            this.listTopicsBox.Enabled = false;
            this.listTopicsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listTopicsBox.Location = new System.Drawing.Point(13, 103);
            this.listTopicsBox.Multiline = true;
            this.listTopicsBox.Name = "listTopicsBox";
            this.listTopicsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.listTopicsBox.Size = new System.Drawing.Size(182, 306);
            this.listTopicsBox.TabIndex = 3;
            this.listTopicsBox.Text = "Topics :\r\n";
            // 
            // selectTopicBox
            // 
            this.selectTopicBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.selectTopicBox.Location = new System.Drawing.Point(13, 422);
            this.selectTopicBox.Name = "selectTopicBox";
            this.selectTopicBox.Size = new System.Drawing.Size(182, 26);
            this.selectTopicBox.TabIndex = 4;
            this.selectTopicBox.Text = "Select a topic";
            // 
            // joinButton
            // 
            this.joinButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.joinButton.Location = new System.Drawing.Point(12, 461);
            this.joinButton.Name = "joinButton";
            this.joinButton.Size = new System.Drawing.Size(185, 34);
            this.joinButton.TabIndex = 5;
            this.joinButton.Text = "Join topic";
            this.joinButton.UseVisualStyleBackColor = true;
            this.joinButton.Click += new System.EventHandler(this.joinButton_Click);
            // 
            // leaveTopic
            // 
            this.leaveTopic.Enabled = false;
            this.leaveTopic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.leaveTopic.Location = new System.Drawing.Point(11, 507);
            this.leaveTopic.Name = "leaveTopic";
            this.leaveTopic.Size = new System.Drawing.Size(185, 34);
            this.leaveTopic.TabIndex = 6;
            this.leaveTopic.Text = "Leave topic";
            this.leaveTopic.UseVisualStyleBackColor = true;
            this.leaveTopic.Click += new System.EventHandler(this.leaveTopic_Click);
            // 
            // addTopicBox
            // 
            this.addTopicBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.addTopicBox.Location = new System.Drawing.Point(13, 58);
            this.addTopicBox.Multiline = true;
            this.addTopicBox.Name = "addTopicBox";
            this.addTopicBox.Size = new System.Drawing.Size(182, 32);
            this.addTopicBox.TabIndex = 7;
            // 
            // addTopicButton
            // 
            this.addTopicButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.addTopicButton.Location = new System.Drawing.Point(12, 12);
            this.addTopicButton.Name = "addTopicButton";
            this.addTopicButton.Size = new System.Drawing.Size(184, 34);
            this.addTopicButton.TabIndex = 8;
            this.addTopicButton.Text = "Add topic";
            this.addTopicButton.UseVisualStyleBackColor = true;
            this.addTopicButton.Click += new System.EventHandler(this.addTopicButton_Click);
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(732, 553);
            this.Controls.Add(this.addTopicButton);
            this.Controls.Add(this.addTopicBox);
            this.Controls.Add(this.leaveTopic);
            this.Controls.Add(this.joinButton);
            this.Controls.Add(this.selectTopicBox);
            this.Controls.Add(this.listTopicsBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.sendMessageBox);
            this.Controls.Add(this.messageBox);
            this.Name = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.TextBox sendMessageBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox listTopicsBox;
        private System.Windows.Forms.DomainUpDown selectTopicBox;
        private System.Windows.Forms.Button joinButton;
        private System.Windows.Forms.Button leaveTopic;
        private System.Windows.Forms.TextBox addTopicBox;
        private System.Windows.Forms.Button addTopicButton;
    }
}