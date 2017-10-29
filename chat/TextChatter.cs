using System;

namespace Projet.chat
{
    class TextChatter : Chatter
    {
        private String pseudo;
        private String password;

        public TextChatter(String pseudo) : base()
        {
            this.pseudo = pseudo;
        }

        public TextChatter(String pseudo, String password) : base()
        {
            this.pseudo = pseudo;
            this.password = password;
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

        public void receiveAMessage(String message, Chatter c)
        {
            Console.WriteLine("(At " + pseudo + ") : " + c.Pseudo + " $> " + message);
        }

        public void joinNotification(Chatter c)
        {
            Console.WriteLine(c.Pseudo + " joined");
        }

        public void quitNotification(Chatter c)
        {
            Console.WriteLine(c.Pseudo + " disconnected");
        }
    }
}
