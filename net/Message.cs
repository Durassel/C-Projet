using System;
using System.Collections.Generic;

namespace Projet.net
{
    [Serializable]
    public class Message
    {
        public enum Header { LIST_TOPIC, CREATE_TOPIC, JOIN_TOPIC, JOIN, POST, QUIT, GET, JOINED, LEFT }
        private Header head;
        private List<String> data = new List<String>();

        public Message(Header head)
        {
            this.head = head;
            Console.WriteLine("Header message : " + this.head);
        }

        public Message(Header head, String message) : this(head)
        {
             this.data.Add(message);
            Console.WriteLine("Message : " + this.head + " -> " + message);
        }

        public Message(Header head, List<String> message) : this(head)
        {
            this.data = message;
            Console.WriteLine("Messages : " + this.head + " -> ");
            foreach (String msg in data) {
                Console.WriteLine(msg);
            }
        }

        public void addData(String str)
        {
            this.data.Add(str);
        }

        public List<String> Data
        {
            get { return this.data; }
        }

        public override string ToString()
        {
            return head + " -> " + data.ToString();
        }
    }
}
