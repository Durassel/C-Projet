using Projet.chat;
using Projet.net;
using System;
using System.Collections.Generic;
using System.Threading;
using static Projet.net.Message;

namespace Projet.client
{
    public class ClientChatroom : TCPClient, Chatroom
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
                data.Add(c.Pseudo);
                data.Add(message);
                sendMessage(new Message(Header.POST, data));
            } catch (System.IO.IOException e) {
                Console.WriteLine(e.ToString());
            }
        }

        public void quit(Chatter c)
        {
            try {
                sendMessage(new Message(Header.QUIT, c.Pseudo));
                Thread.Sleep(500);
                this.disconnect(); // Close connection between client and server when clients receive notification
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
                        case Header.JOINED:
                            if (chatter != null) {
                                chatter.joinNotification(new TextChatter(message.Data[0]));
                            }
                            break;
                        case Header.LEFT :
                            if (chatter != null) {
                                chatter.quitNotification(new TextChatter(message.Data[0]));
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
