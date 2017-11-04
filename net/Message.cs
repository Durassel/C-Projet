﻿using System;
using System.Collections.Generic;

namespace Projet.net
{
    [Serializable]
    public class Message
    {
        public enum Header { DEBUG, JOIN, POST, QUIT, GET, LIST_TOPICS, CREATE_TOPIC, JOIN_TOPIC } // Header of the message
        public Header head;
        public List<String> data = new List<String>(); // Data of the message

        public Message(Header head)
        {
            this.head = head;
        }

        public Message(Header head, String message) : this(head)
        {
             this.data.Add(message);
        }

        public Message(Header head, List<String> message) : this(head)
        {
            this.data = message;
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
            string str = this.head + " -> ";
            foreach (String s in this.data) {
                str += s + " ";
            }
            return str;
        }
    }
}
