using Projet.net;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using static Projet.net.Message;

namespace Projet.server
{
    class ServerTopicsManager : TCPServer
    {
        private TCPTopicsManager tcpTopicsManager = new TCPTopicsManager();

        public override void manageClient(TcpClient comm)
        {
            try {
                Message message;
                while ((message = getMessage()) != null) { // Read message
                    switch (message.head) { // Treat message
                        case Header.LIST_TOPICS:
                            List<String> topics = tcpTopicsManager.listTopics();
                            Message msg = new Message(Header.LIST_TOPICS, topics);
                            sendMessage(msg);
                            break;
                        case Header.CREATE_TOPIC:
                            tcpTopicsManager.createTopic(message.Data[0]);
                            break;
                        case Header.JOIN_TOPIC:
                            String topicToJoin = message.Data[0];
                            Message msg2 = new Message(Header.JOIN_TOPIC, (tcpTopicsManager.getTopicPort(topicToJoin)).ToString());
                            sendMessage(msg2);
                            break;
                        default:
                            break;
                    }
                }
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
