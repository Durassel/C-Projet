using Projet.chat;
using Projet.client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using projet.client;
using static Projet.net.Message;
using System.Drawing;

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
        private UpdateChat textChat;
        private UpdateTopic textTopic;

        public Form2(ClientTopicsManager client, String pseudo, String password)
        {
            transm.AddReceiveDel(receiveMessage);
            this.client = client;
            this.pseudo = pseudo;
            this.password = password;
            this.topic = "";
            this.Text = "Home / " + pseudo;
            InitializeComponent();
            textChat += new UpdateChat(this.showText);
            textTopic += new UpdateTopic(this.showTopic);
            showTopic();
            showMember();
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
                        messageBox.Invoke(textChat, ("\r\n" + c.Pseudo + " joined the chatroom." + "\r\n"));
                    }
                    break;
                case Header.LEFT:
                    if (chatter != null) {
                        messageBox.Invoke(textChat, ("\r\n" + c.Pseudo + " disconnected from the chatroom." + "\r\n"));
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
            this.listTopics.Items.Clear();
            List<String> topics = client.listTopics();
            int i = 0;
            foreach (String topic in topics) {
                this.listTopics.Items.Add(topic);
                if (this.topic.CompareTo(topic) == 0) {
                    this.listTopics.SetSelected(i, true);
                } else {
                    i++;
                }
            }

            if (this.listTopics.Items.Count == i && listTopics.Items.Count > 0) {
                this.listTopics.SetSelected(0, true);
            }
        }

        private void showMember() // update list topics
        {
            if (topic != "") {
                this.listMembers.Items.Clear();
                List<String> members = client.listMembers(this.topic);
                if (members != null) {
                    foreach (String member in members) {
                        this.listMembers.Items.Add(member);
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
                this.topic = listTopics.SelectedItem.ToString();
                this.chatroom = client.joinTopic(this.topic);
                this.joinButton.Enabled = false; // Lock / Unlock buttons
                this.sendMessageBox.Enabled = true;
                this.leaveTopic.Enabled = true;
                this.sendButton.Enabled = true;
                this.sendMessageBox.Enabled = true;
                this.chatter = new TextChatter(this.pseudo, this.password);
                this.chatroom.join(chatter);
                this.Text = this.topic + " / " + pseudo;
            }
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
            this.sendMessageBox.Enabled = false;
            this.sendButton.Enabled = false;
            this.chatroom.quit(chatter);
            this.Text = "Home / " + pseudo;
            this.topic = "";
            this.listMembers.Items.Clear();
            this.messageBox.Text = "";
            showTopic(); // Refresh topics
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            showTopic();
            showMember();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String topic = "";

            if (dialogBox("New topic", "Name topic : ", ref topic) == DialogResult.OK)
            {
                if (!listTopics.Items.Contains(topic)) {
                    this.listTopics.Items.Add(topic);
                    if (this.topic != "" && this.topic.CompareTo(this.listTopics.SelectedItem.ToString()) != 0) {
                        int index = this.listTopics.Items.Count - 1;
                        this.listTopics.SetSelected(index, true);
                    }
                    this.client.createTopic(topic); // A faire : renvoye une exception en cas d'erreur
                } else {
                    ChatroomExistsException exception = new ChatroomExistsException(topic);
                    MessageBox.Show(exception.Message, string.Format("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            form.ClientSize = new Size(396, 107);
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
            return dialogResult;
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            client.disconnect();
            this.Hide();
            Form1 log = new Form1();
            log.Show();
        }
    }
}
