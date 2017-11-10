namespace Server
{
    partial class Form1
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
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.server = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.addressText = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.portText = new System.Windows.Forms.TextBox();
            this.start = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // server
            // 
            this.server.Dock = System.Windows.Forms.DockStyle.Fill;
            this.server.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.server.Location = new System.Drawing.Point(0, 0);
            this.server.Name = "server";
            this.server.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.server.Size = new System.Drawing.Size(482, 173);
            this.server.TabIndex = 0;
            this.server.Text = "Server";
            this.server.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.addressLabel.Location = new System.Drawing.Point(17, 69);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(101, 25);
            this.addressLabel.TabIndex = 7;
            this.addressLabel.Text = "Address : ";
            // 
            // addressText
            // 
            this.addressText.Enabled = false;
            this.addressText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.addressText.HideSelection = false;
            this.addressText.Location = new System.Drawing.Point(118, 69);
            this.addressText.Name = "addressText";
            this.addressText.ReadOnly = true;
            this.addressText.Size = new System.Drawing.Size(195, 26);
            this.addressText.TabIndex = 8;
            this.addressText.Text = "127.0.0.1";
            this.addressText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portLabel.Location = new System.Drawing.Point(319, 69);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(63, 25);
            this.portLabel.TabIndex = 9;
            this.portLabel.Text = "Port : ";
            // 
            // portText
            // 
            this.portText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.portText.Location = new System.Drawing.Point(380, 69);
            this.portText.Name = "portText";
            this.portText.Size = new System.Drawing.Size(85, 26);
            this.portText.TabIndex = 10;
            this.portText.Text = "2453";
            this.portText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // start
            // 
            this.start.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.start.Location = new System.Drawing.Point(88, 124);
            this.start.Margin = new System.Windows.Forms.Padding(0);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(148, 29);
            this.start.TabIndex = 12;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // stop
            // 
            this.stop.Enabled = false;
            this.stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.stop.Location = new System.Drawing.Point(247, 124);
            this.stop.Margin = new System.Windows.Forms.Padding(0);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(148, 29);
            this.stop.TabIndex = 13;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 173);
            this.Controls.Add(this.portText);
            this.Controls.Add(this.addressText);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.start);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.server);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label server;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.TextBox addressText;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox portText;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button stop;
    }
}

