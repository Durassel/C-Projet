namespace Client
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
            this.Text = "Chat";
            this.loginButton = new System.Windows.Forms.Button();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.signupButton = new System.Windows.Forms.Button();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.authentificationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.loginButton.Location = new System.Drawing.Point(76, 150);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(133, 28);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.login_Click);
            // 
            // usernameBox
            // 
            this.usernameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.usernameBox.Location = new System.Drawing.Point(169, 65);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(217, 26);
            this.usernameBox.TabIndex = 2;
            this.usernameBox.Text = "bob";
            // 
            // passwordText
            // 
            this.passwordText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.passwordText.Location = new System.Drawing.Point(169, 104);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(217, 26);
            this.passwordText.TabIndex = 4;
            this.passwordText.Text = "123";
            this.passwordText.UseSystemPasswordChar = true;
            // 
            // signupButton
            // 
            this.signupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.signupButton.Location = new System.Drawing.Point(227, 150);
            this.signupButton.Name = "signupButton";
            this.signupButton.Size = new System.Drawing.Size(133, 28);
            this.signupButton.TabIndex = 5;
            this.signupButton.Text = "Sign up";
            this.signupButton.UseVisualStyleBackColor = true;
            this.signupButton.Click += new System.EventHandler(this.signup_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.usernameLabel.Location = new System.Drawing.Point(50, 66);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(113, 25);
            this.usernameLabel.TabIndex = 6;
            this.usernameLabel.Text = "Username :";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.passwordLabel.Location = new System.Drawing.Point(54, 104);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(109, 25);
            this.passwordLabel.TabIndex = 7;
            this.passwordLabel.Text = "Password :";
            // 
            // authentificationLabel
            // 
            this.authentificationLabel.AutoSize = true;
            this.authentificationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.authentificationLabel.Location = new System.Drawing.Point(93, 9);
            this.authentificationLabel.Name = "authentificationLabel";
            this.authentificationLabel.Size = new System.Drawing.Size(250, 39);
            this.authentificationLabel.TabIndex = 8;
            this.authentificationLabel.Text = "Authentification";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(437, 201);
            this.Controls.Add(this.authentificationLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.signupButton);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.loginButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
 
        #endregion

        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Button signupButton;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label authentificationLabel;
    }
}

