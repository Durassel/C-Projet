using Projet.chat;
using Projet.client;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using projet.client;
using static Projet.net.Message;
using System.Drawing;
using Projet.authentification;

namespace Client
{
    public partial class Form2 : Form
    {
        private ClientTopicsManager client;
        private Chatroom chatroom;
        private String pseudo;
        private String password;
        private String topic;
        private Chatter chatter;
        private Transmittor transm = new Transmittor();
        private delegate void UpdateChat(String text);
        private delegate void UpdateTopic();
        private delegate void UpdateMember();
        private UpdateChat textChat;
        private UpdateTopic textTopic;
        private UpdateMember textMember;

        public Form2(ClientTopicsManager client, String pseudo, String password)
        {
            transm.AddReceiveDel(receiveMessage);
            this.client = client;
            this.pseudo = pseudo;
            this.password = password;
            this.topic = "";
            this.Text = pseudo;
            InitializeComponent();
            textChat += new UpdateChat(this.showText);
            textTopic += new UpdateTopic(this.showTopic);
            textMember += new UpdateMember(this.showMember);
            showTopic();
        }

        private void receiveMessage(object sender, EventArgs e, String message, Chatter c, Header h)
        {
            switch (h) {
                case Header.GET:
                    if (chatter != null) {
                        messageBox.Invoke(textChat, (c.Pseudo + " $> " + message + "\r\n"));
                    }
                    break;
                case Header.JOINED:
                    if (chatter != null) {
                        messageBox.Invoke(textChat, (c.Pseudo + " joined the chatroom." + "\r\n"));
                        listMembers.Invoke(textMember);
                    }
                    break;
                case Header.LEFT:
                    if (chatter != null) {
                        messageBox.Invoke(textChat, (c.Pseudo + " disconnected from the chatroom." + "\r\n"));
                        listMembers.Invoke(textMember);
                    }
                    break;
                case Header.ERROR:
                    if (chatter != null) {
                        MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
            messageBox.ForeColor = System.Drawing.Color.Black;
        }

        private void showText(String value)
        {
            messageBox.Text += value;
        }

        private void showTopic() // update list topics
        {
            listTopics.Items.Clear();
            List<String> topics = client.listTopics();
            int i = 0;
            foreach (String topic in topics) {
                listTopics.Items.Add(topic);
                if (topic.CompareTo(topic) == 0) {
                    listTopics.SetSelected(i, true);
                } else {
                    i++;
                }
            }

            if (listTopics.Items.Count == i && listTopics.Items.Count > 0) {
                listTopics.SetSelected(0, true);
            }
        }

        private void showMember() // update list topics
        {
            if (topic != "") {
                if (listMembers.Items.Count > 0) {
                    listMembers.Items.Clear();
                }
                List<String> members = client.listMembers(topic);
                if (members != null) {
                    foreach (String member in members) {
                        listMembers.Items.Add(member);
                    }
                }
            }
        }

        private bool itemIsSelected()
        {
            bool selected = false;
            int nbItems = listTopics.Items.Count;
            for (int i = 0; i < nbItems; i++) {
                String topic = listTopics.Items[i].ToString();
                if (listTopics.SelectedItems.Contains(topic)) {
                    selected = true;
                }
            }
            return selected;
        }

        private void joinButton_Click(object sender, EventArgs e)
        {
            if (listTopics.Items.Count > 0 && itemIsSelected()) {
                topic = listTopics.SelectedItem.ToString();
                chatroom = client.joinTopic(topic);
                joinButton.Enabled = false; // Lock / Unlock buttons
                sendMessageBox.Enabled = true;
                leaveTopic.Enabled = true;
                sendButton.Enabled = true;
                sendMessageBox.Enabled = true;
                chatter = new TextChatter(pseudo, password);
                chatroom.join(chatter);
                chatLabel.Text = "Chat : " + topic;
                showMember();
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            String phrase = sendMessageBox.Text;
            if (phrase != "") {
                chatroom.post(phrase, chatter);
            }
            sendMessageBox.Text = "";
        }

        private void leaveTopic_Click(object sender, EventArgs e)
        {
            if (chatroom != null) {
                joinButton.Enabled = true;
                leaveTopic.Enabled = false;
                sendMessageBox.Enabled = false;
                sendButton.Enabled = false;
                chatroom.quit(chatter);
                chatLabel.Text = "Chat";
                topic = "";
                listMembers.Items.Clear();
                messageBox.Text = "";
                showTopic(); // Refresh topics
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            showTopic();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String topic = "";
            if (dialogBox("New topic", "Name topic : ", ref topic) == DialogResult.OK) {
                client.createTopic(topic);
                Projet.net.Message response = client.getMessage();
                if (response.Data[0].Equals("ok")) {
                    listTopics.Items.Add(topic);
                } else {
                    MessageBox.Show(response.Data[0], "Error during chatroom creation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static DialogResult dialogBox(String title, String promptText, ref String value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(400, 105);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            form.Dispose();
            return dialogResult;
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            leaveTopic_Click(sender, e); // Check if he is in a chatroom
            Authentification auth = new Authentification();
            auth.updateUser(pseudo, false);// Put user connected state at false and save in file
            client.disconnect();
            this.Hide(); // Close = bug
            Form1 log = new Form1();
            log.Show();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            disconnectToolStripMenuItem_Click(sender, e);
        }
    }
}
