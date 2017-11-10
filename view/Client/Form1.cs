using Projet.authentification;
using System;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            Boolean error = false;
            String pseudo = usernameBox.Text;
            String password = passwordText.Text;

            if (pseudo.Equals("")) {
                MessageBox.Show("Use an USername", "Error");
            } else if (password == "") {
                MessageBox.Show("Use a password", "Error");
            } else {
                try {
                    Authentification var = new Authentification();
                    var.authentify(pseudo, password);
                } catch (UserUnknownException exception) {
                    error = true;
                    MessageBox.Show(exception.Message, exception.titleError(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                } catch (WrongPasswordException exception) {
                    error = true;
                    MessageBox.Show(exception.Message, exception.titleError(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (error == false) {
                Form chat = new Form2(pseudo, password);
                chat.Show();
                this.Hide();
            }
        }

        private void signup_Click(object sender, EventArgs e)
        {
            String pseudo = usernameBox.Text;
            String password = passwordText.Text;
 
            if (pseudo.Equals("")) {
                MessageBox.Show("Use an username", "Error");
            } else if (password == "") {
                MessageBox.Show("Use a password", "Error");
            } else {
                try {
                    Authentification var = new Authentification();
                    var.addUser(pseudo, password);
                    var.save("C:\\Users\\Frédéric\\Desktop\\EFREI\\2017-2018\\Semestre 1\\C#\\Project\\Projet\\Projet\\bin\\Debug\\users.txt");
                    MessageBox.Show("Successful registration !", string.Format("Sign up"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                } catch (UserExistsException exception) {
                    MessageBox.Show(exception.Message, exception.titleError(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
