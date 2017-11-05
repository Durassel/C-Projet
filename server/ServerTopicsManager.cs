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
                        case Header.JOIN_TOPIC :
                            String topic = message.Data[0];
                            sendMessage(new Message(Header.JOIN_TOPIC, (tcpTopicsManager.getTopicPort(topic)).ToString()));
                            break;
                        case Header.CREATE_TOPIC :
                            topic = message.Data[0];
                            tcpTopicsManager.createTopic(topic);
                            break;
                    }
                }
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
