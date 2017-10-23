using System;
using System.Collections.Generic;
using System.Text;

namespace Projet.chat
{
    class TextChatter : Chatter
    {
        private String pseudo;

        public TextChatter(String pseudo)
        {
            this.pseudo = pseudo;
        }

        public void receiveAMessage(String msg, Chatter c)
        {
            Console.WriteLine("(At " + pseudo + ") : " + c.getAlias() + " $> " + msg);
        }

        public String getAlias()
        {
            return this.pseudo;
        }
    }
}
