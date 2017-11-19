using System;
using System.Collections.Generic;
using Projet.net;

namespace Projet.chat
{
    class TextChatroom : Chatroom
    {
        private List<Chatter> chatters = new List<Chatter>(); // List of chatters in this chatroom
        private String topic; // Topic of this chatroom

        public TextChatroom(String topic)
        {
            this.topic = topic;
        }

        public String Topic
        {
            get { return this.topic; }
        }

        public List<Chatter> Chatters
        {
            get { return this.chatters; }
        }

        public void post(String message, Chatter c)
        {
            // Check if the chatter is in the chatroom
            if (chatters.Contains(c)) {
                foreach (Chatter chatter in chatters) { // Send message to all chatters
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
                foreach (Chatter chatter in chatters) { // Send message to all chatters
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
                foreach (Chatter chatter in chatters) { // Send message to all chatters
                    chatter.joinNotification(c);
                }
            } else {
                throw new Exception(c.Pseudo + " cannot join the chatroom. He is already in the chatroom.");
            }
        }
    }
}
