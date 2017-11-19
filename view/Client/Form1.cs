using Projet.authentification;
using Projet.client;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows.Forms;
using static Projet.net.Message;

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
            ClientTopicsManager client = new ClientTopicsManager();

            try { // Client connection to the server
                client.setServer("127.0.0.1", 2453);
                client.connect();
            } catch (SocketException exception) {
                error = true;
                MessageBox.Show(exception.Message, "Error server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (pseudo.Equals("")) {
                MessageBox.Show("Use an username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (password == "") {
                MessageBox.Show("Use a password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                List<String> log = new List<String>();
                log.Add(pseudo);
                log.Add(password);

                client.sendMessage(new Projet.net.Message(Header.LOGIN, log));
                Projet.net.Message response = client.getMessage();
                if (response.Data[0].Equals("ok")) {
                    error = false;
                } else {
                    error = true;
                    MessageBox.Show(response.Data[0], "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (error == false) {
                Form chat = new Form2(client, pseudo, password);
                chat.Show();
                this.Hide();
            }
        }

        private void signup_Click(object sender, EventArgs e)
        {
            String pseudo = usernameBox.Text;
            String password = passwordText.Text;
            ClientTopicsManager client = new ClientTopicsManager();

            try { // Client connection to the server
                client.setServer("127.0.0.1", 2453);
                client.connect();
            } catch (SocketException exception) {
                MessageBox.Show(exception.Message, "Error server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if (pseudo.Equals("")) {
                MessageBox.Show("Use an username", "Error");
            } else if (password == "") {
                MessageBox.Show("Use a password", "Error");
            } else {
                List<String> log = new List<String>();
                log.Add(pseudo);
                log.Add(password);

                client.sendMessage(new Projet.net.Message(Header.REGISTRATION, log));
                Projet.net.Message response = client.getMessage();

                if (response.Data[0] == "ok") {
                    MessageBox.Show("Successful registration !", "Sign up", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                } else {
                    MessageBox.Show(response.Data[0], "Sign up error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
