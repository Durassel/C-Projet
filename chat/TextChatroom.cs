using System;
using System.Collections.Generic;
using Projet.net;

namespace Projet.chat
{
    class TextChatroom : Chatroom
    {
        private List<Chatter> chatters = new List<Chatter>(); // List of chatters in this chatroom
        private String topic; // Subject of this chatroom

        public TextChatroom(String topic)
        {
            this.topic = topic;
        }

        public String Topic
        {
            get { return this.topic; }
        }

        public void post(String message, Chatter c)
        {
            // Check if the chatter is in the chatroom
            if (chatters.Contains(c)) {
                foreach (Chatter chatter in chatters) {
                    chatter.receiveAMessage(message, c);
                }
            } else {
                throw new Exception("The message cannot be sent. Sender isn't in the chatroom.");
            }
        }
        public void quit(Chatter c)
        {
            // Check if the chatter is in the chatroom
            if (chatters.Contains(c)) {
                chatters.Remove(c);
                //Console.WriteLine("(Message from Chatroom : " + topic + ") " + c.Pseudo + " leaved the chatroom.");
                foreach (Chatter chatter in chatters) {
                    chatter.quitNotification(c);
                }
            } else {
                throw new Exception(c.Pseudo + " cannot leave the chatroom. He isn't in the chatroom.");
            }
        }

        public void join(Chatter c)
        {
            // Check if the chatter isn't in the chatroom
            if (!chatters.Contains(c)) {
                chatters.Add(c);
                //Console.WriteLine("(Message from Chatroom : " + topic + ") " + c.Pseudo + " has join the chatroom.");
                foreach (Chatter chatter in chatters) {
                    chatter.joinNotification(c);
                }
            } else {
                throw new Exception(c.Pseudo + " cannot join the chatroom. He is already in the chatroom.");
            }
        }
    }
}
