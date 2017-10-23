using System;
using System.Collections.Generic;
using System.Text;

namespace Projet.chat
{
    class TextChatter : Chatter
    {
        private String alias;

        public TextChatter(String alias)
        {
            this.alias = alias;
        }

        public void receiveAMessage(String msg, Chatter c)
        {
            Console.WriteLine("(At " + alias + ") : " + c.Alias + " $> " + msg);
        }

        public String Alias
        {
            get
            {
                return this.alias;
            }
            set
            {
                this.alias = value;
            }
        }
    }
}
