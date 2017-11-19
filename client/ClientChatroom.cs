using projet.client;
using Projet.chat;
using Projet.net;
using System;
using System.Collections.Generic;
using static Projet.net.Message;

namespace Projet.client
{
    public class ClientChatroom : TCPClient, Chatroom
    {
        private Chatter chatter;
        private Transmittor transm = new Transmittor();

        public String Topic
        {
            get {
                String topic = "";
                try {
                    Message message = getMessage();
                    topic = message.Data[0];
                } catch (Exception e) {
                    Console.WriteLine(e);
                }
                return topic;
            }
        }

        public List<Chatter> Chatters
        {
            get {
                List<Chatter> chatters = new List<Chatter>();
                try {
                    Message message = getMessage();
                    foreach (String chatter in message.Data) {
                        chatters.Add(new TextChatter(chatter));
                    }
                } catch (Exception e) {
                    Console.WriteLine(e);
                }
                return chatters;
            }
        }

        public void join(Chatter c)
        {
            try {
                List<String> data = new List<String>();
                data.Add(c.Pseudo);
                data.Add(c.Password);
                sendMessage(new Message(Header.JOIN, data));
                chatter = c;
            } catch (Exception e) {
                Console.WriteLine(e);
            }
        }

        public void post(String message, Chatter c)
        {
            try {
                List<String> data = new List<String>();
                data.Add(c.Pseudo);
                data.Add(message);
                sendMessage(new Message(Header.POST, data));
            } catch (Exception e) {
                Console.WriteLine(e);
            }
        }

        public void quit(Chatter c)
        {
            try {
                sendMessage(new Message(Header.QUIT, c.Pseudo));
            } catch (Exception e) {
                Console.WriteLine(e);
            }
        }

        public void run()
        {
            try {
                Message message;
                while ((message = getMessage()) != null) {
                    if (chatter != null) {
                        if (message.Data.Count > 1) {
                            transm.raiseEvent(message.Data[1], new TextChatter(message.Data[0]), message.head); // Get message
                        } else {
                            transm.raiseEvent(new TextChatter(message.Data[0]), message.head); // Notification
                        }
                    }
                }
            } catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}
