﻿using Projet.authentification;
using Projet.chat;
using Projet.net;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using static Projet.net.Message;

namespace Projet.server
{
    class ServerChatroom : TCPServer, Chatter
    {
        private String pseudo;
        private String password;
        private TextChatroom textChatroom;

        public String Pseudo
        {
            get { return this.pseudo; }
            set { this.pseudo = value; }
        }

        public String Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public ServerChatroom(Chatroom chatroom)
        {
            this.textChatroom = (TextChatroom) chatroom;
        }

        public override void manageClient(TcpClient comm)
        {
            try {
                Message message;
                while ((message = getMessage()) != null) { // Read message
                    switch (message.head) { // Treat message
                        case Header.JOIN :
                            pseudo = message.Data[0];
                            password = message.Data[1];
                            Authentification am = new Authentification();
                            try {
                                am.authentify(pseudo, password);
                                textChatroom.join(this);
                            } catch (Exception e) {
                                Console.WriteLine(e);
                            }
                            joinNotification(this);
                            break;
                        case Header.POST :
                            String msg = message.Data[1];
                            textChatroom.post(msg, this);
                            break;
                        case Header.QUIT :
                            textChatroom.quit(this);
                            break;
                        default:
                            break;
                    }
                }
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        public void receiveAMessage(String msg, Chatter c)
        {
            List<String> data = new List<String>(2);
            data.Add(c.Pseudo);
            data.Add(msg);
            try {
                sendMessage(new Message(Header.GET, data));
            } catch (System.IO.IOException e) {
                Console.WriteLine(e.ToString());
            }
        }

        public void joinNotification(Chatter c)
        {
            List<String> data = new List<String>(1);
            data.Add(c.Pseudo);
            try {
                sendMessage(new Message(Header.JOINED, data));
            } catch (System.IO.IOException e) {
                Console.WriteLine(e.ToString());
            }
        }

        public void quitNotification(Chatter c)
        {
            List<String> data = new List<String>(1);
            data.Add(c.Pseudo);
            try {
                sendMessage(new Message(Header.LEFT, data));
            } catch (System.IO.IOException e) {
                Console.WriteLine(e.ToString());
            }
        }
    }
}