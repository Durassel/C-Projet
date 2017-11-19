using projet.client;
using System;
using static Projet.net.Message;

namespace Projet.chat
{
    public class TextChatter : Chatter
    {
        private String pseudo;
        private String password;
        private Transmittor transm = new Transmittor(); // UI Listener

        public TextChatter(String pseudo) : base()
        {
            this.pseudo = pseudo;
            transm.AddReceiveDel(receiveMessage);
        }

        public TextChatter(String pseudo, String password) : base()
        {
            this.pseudo = pseudo;
            this.password = password;
            transm.AddReceiveDel(receiveMessage);
        }

        public String Pseudo
        {
            get { return this.pseudo; }
            set { this.pseudo = value; }
        }

        public String Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public void receiveMessage(object sender, EventArgs e, String message, Chatter c, Header h)
        {
            if (c != null) {
                switch (h) {
                    case Header.GET:
                        receiveAMessage(message, c);
                        break;
                    case Header.JOINED:
                        joinNotification(c);
                        break;
                    case Header.LEFT:
                        quitNotification(c);
                        break;
                }
            }
            transm.RemoveReceiveDel(receiveMessage);
        }

        public void receiveAMessage(String message, Chatter c)
        {
            Console.WriteLine("(At " + pseudo + ") : " + c.Pseudo + " $> " + message);
        }

        public void joinNotification(Chatter c)
        {
            Console.WriteLine(c.Pseudo + " joined the chatroom.");
        }

        public void quitNotification(Chatter c)
        {
            Console.WriteLine(c.Pseudo + " disconnected from the chatroom.");
        }
    }
}
