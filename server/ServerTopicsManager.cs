using Projet.authentification;
using Projet.chat;
using Projet.net;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using static Projet.net.Message;

namespace Projet.server
{
    public class ServerTopicsManager : TCPServer
    {
        private TCPTopicsManager tcpTopicsManager = new TCPTopicsManager();

        public override void manageClient(TcpClient comm)
        {
            try {
                Message message;
                while ((message = getMessage()) != null) { // Read message
                    switch (message.head) { // Treat message
                        case Header.LIST_TOPICS :
                            List<String> topics = tcpTopicsManager.listTopics();
                            sendMessage(new Message(Header.LIST_TOPICS, topics));
                            break;
                        case Header.LIST_MEMBERS:
                            String topic = message.Data[0];
                            List<String> members = tcpTopicsManager.listMembers(topic);
                            sendMessage(new Message(Header.LIST_MEMBERS, members));
                            break;
                        case Header.JOIN_TOPIC :
                            topic = message.Data[0];
                            sendMessage(new Message(Header.JOIN_TOPIC, (tcpTopicsManager.getTopicPort(topic)).ToString()));
                            break;
                        case Header.CREATE_TOPIC :
                            topic = message.Data[0];
                            try {
                                tcpTopicsManager.createTopic(topic);
                                sendMessage(new Message(Header.ERROR, "ok"));
                            } catch (ChatroomExistsException e) {
                                sendMessage(new Message(Header.ERROR, e.Message));
                            }
                            break;
                        case Header.REGISTRATION:
                            Authentification auth = new Authentification();
                            try {
                                auth.addUser(message.Data[0], message.Data[1]);
                                sendMessage(new Message(Header.ERROR, "ok"));
                            } catch (UserExistsException e) {
                                sendMessage(new Message(Header.ERROR, e.Message));
                            }
                            break;
                        case Header.LOGIN:
                            auth = new Authentification();
                            try {
                                auth.authentify(message.Data[0], message.Data[1]);
                                sendMessage(new Message(Header.ERROR, "ok"));
                            } catch (UserUnknownException e) {
                                sendMessage(new Message(Header.ERROR, e.Message));
                            } catch (WrongPasswordException e) {
                                sendMessage(new Message(Header.ERROR, e.Message));
                            } catch (UserConnectedException e) {
                                sendMessage(new Message(Header.ERROR, e.Message));
                            }
                            break;
                    }
                }
            } catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}
