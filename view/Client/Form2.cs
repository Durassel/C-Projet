using Projet.chat;
using Projet.client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using projet.client;
using static Projet.net.Message;

namespace Client
{
    public partial class Form2 : Form
    {
        private ClientTopicsManager client;
        private Chatroom chatroom;
        private String pseudo;
        private String password;
        private Chatter chatter;
        private DomainUpDown.DomainUpDownItemCollection items;
        private Transmittor transm = new Transmittor();
        private delegate void UpdateChat(String text);
        private UpdateChat textChat;

        public Form2(string pseudo, string password)
        {
            transm.AddReceiveDel(receiveMessage);
            this.pseudo = pseudo;
            this.password = password;
            InitializeComponent();
            this.client = new ClientTopicsManager();
            textChat = new UpdateChat(this.showText);

            try { // Client connection to the server
                client.setServer("127.0.0.1", 2453);
                client.connect();
                this.items = this.selectTopicBox.Items;
                showTopic();
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
        }

        private void receiveMessage(object sender, EventArgs e, String message, Chatter c, Header h)
        {
            switch (h) {
                case Header.GET:
                    if (chatter != null) {
                        messageBox.Invoke(textChat, ("\r\n(At " + pseudo + ") : " + c.Pseudo + " $> " + message));
                    }
                    break;
                case Header.JOINED:
                    if (chatter != null) {
                        messageBox.Invoke(textChat, ("\r\n" + c.Pseudo + " joined the chatroom."));
                    }
                    break;
                case Header.LEFT:
                    if (chatter != null) {
                        messageBox.Invoke(textChat, ("\r\n" + c.Pseudo + " disconnected from the chatroom."));
                    }
                    break;
            }
        }

        private void showText(String value)
        {
            messageBox.Text += value;
        }

        private void showTopic() // mise a jour de la liste des topics+ enregrstrement dans la barre de defilement
        {
            List<String> topics = client.listTopics();
            this.listTopicsBox.Text = "Topics";

            foreach (String topic in topics) {
                this.listTopicsBox.Text += "\r\n" + topic;
                this.items.Add(topic);
            }

            if (topics.Count != 0) {
                this.selectTopicBox.Text = topics.First();
            }
        }

        private void joinButton_Click(object sender, EventArgs e)
        {
            this.chatroom = client.joinTopic(selectTopicBox.Text);
            this.joinButton.Enabled = false; // Lock buttons
            this.leaveTopic.Enabled = true;
            this.sendButton.Enabled = true;
            this.chatter = new TextChatter(this.pseudo, this.password);
            this.chatroom.join(chatter);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            String phrase = sendMessageBox.Text;
            if (phrase != "") {
                this.chatroom.post(phrase, chatter);
            }

            this.sendMessageBox.Text = "";
        }

        private void leaveTopic_Click(object sender, EventArgs e)
        {
            this.joinButton.Enabled = true;
            this.leaveTopic.Enabled = false;
            this.sendButton.Enabled = false;
            this.chatroom.quit(chatter);
        }

        private void addTopicButton_Click(object sender, EventArgs e)
        {
            this.client.createTopic(addTopicBox.Text);
            addTopicBox.Text = "";
            showTopic();
        }
    }
}
