using System;
using System.Collections.Generic;

namespace Projet.net
{
    [Serializable]
    public class Message
    {
        public enum Header { JOINED, LEFT, JOIN, POST, QUIT, GET, LIST_TOPICS, CREATE_TOPIC, JOIN_TOPIC } // Header of the message
        public Header head;
        public List<String> data = new List<String>(); // Data of the message

        public Message(Header head)
        {
            this.head = head;
            Console.WriteLine("Header message : " + this.head);
        }

        public Message(Header head, String message) : this(head)
        {
             this.data.Add(message);
            Console.WriteLine("Message : " + this);
        }

        public Message(Header head, List<String> message) : this(head)
        {
            this.data = message;
            Console.WriteLine("Message : " + this);
        }

        public void addData(String data)
        {
            this.data.Add(data);
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
