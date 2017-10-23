using System;
using System.Collections.Generic;
using System.Text;

namespace Projet.chat
{
    class TextChatroom : Chatroom
    {
        private List<Chatter> chatters = new List<Chatter>();
        private String topic;

        public TextChatroom(String topic)
        {
            this.topic = topic;
        }

        public void join(Chatter c)
        {
            if (!chatters.Contains(c)) {
                chatters.Add(c);
                Console.WriteLine("(Message from Chatroom : " + topic + ") " + c.getAlias() + " has join the room.");
            }
        }

        public void post(String msg, Chatter c)
        {
            if (chatters.Contains(c)) {
                foreach (Chatter chatter in chatters) {
                    chatter.receiveAMessage(msg, c);
                }
            } else {
                // Throw exception : sender not in the chatroom
                Console.WriteLine("Error : message \"" + msg + "\" could not be sent. Sender " + c.getAlias() + " not in the chatroom");
            }
        }

        public void quit(Chatter c)
        {
            if (chatters.Contains(c)) {
                chatters.Remove(c);
                Console.WriteLine("(Message from Chatroom : " + topic + ") " + c.getAlias() + " has quit the room.");
            } else {
                // Throw exception : Chatter not in the chatroom can't quit
            }
        }

        public String getTopic()
        {
            return this.topic;
        }
    }
}
