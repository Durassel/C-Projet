using Projet.chat;
using Projet.net;
using System;
using System.Collections.Generic;
using static Projet.net.Message;

namespace Projet.client
{
    class ClientChatroom : TCPClient, Chatroom
    {
        private Chatter chatter;

        public String Topic
        {
            get {
                String topic = "";
                try {
                    Message message = getMessage();
                    topic = message.Data[0];
                } catch (Exception e) {
                    Console.WriteLine(e.ToString());
                }
                return topic;
            }
        }

        public void join(Chatter c)
        {
            try {
                List<String> data = new List<String>(2);
                data.Add(c.Pseudo);
                data.Add(c.Password);
                sendMessage(new Message(Header.JOIN, data));
                chatter = c;
            } catch (System.IO.IOException e) {
                Console.WriteLine(e.ToString());
            }
        }

        public void post(String message, Chatter c)
        {
            try {
                List<String> data = new List<String>(2);
                user.Add(c.Pseudo);
                user.Add(message);
                sendMessage(new Message(Header.POST, data));
            } catch (System.IO.IOException e) {
                Console.WriteLine(e.ToString());
            }
        }

        public void quit(Chatter c)
        {
            try {
                sendMessage(new Message(Header.QUIT, c.Pseudo));
                this.disconnect();
            } catch (System.IO.IOException e) {
                Console.WriteLine(e.ToString());
            }
        }

        public void run()
        {
            try {
                Message message;
                while ((message = getMessage()) != null) {
                    switch (message.head) {
                        case Header.GET :
                            if (chatter != null) {
                                chatter.receiveAMessage(message.Data[1], new TextChatter(message.Data[0]));
                            }
                            break;
                    }
                }
            } catch (System.IO.IOException e) {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
