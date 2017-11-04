using Projet.chat;
using Projet.net;
using System;
using System.Collections.Generic;
using System.Threading;
using static Projet.net.Message;

namespace Projet.client
{
    class ClientTopicsManager : TCPClient, TopicsManager
    {
        public List<String> listTopics()
        {
            try {
                sendMessage(new Message(Header.LIST_TOPICS)); // Sending message
                List<String> topics = getMessage().Data; // Receive list of topics
                Console.WriteLine("The openned topics are : ");
                foreach (String topic in topics)
                {
                    Console.WriteLine(topic);
                }
                return topics;
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public Chatroom joinTopic(String topic)
        {
            try {
                sendMessage(new Message(Header.JOIN_TOPIC, topic)); // Sending message : server answer the port chatroom
                int port = int.Parse(getMessage().Data[0]); // Reception of the port
                // Initialize a connection between client and server
                ClientChatroom chatroom = new ClientChatroom();
                chatroom.setServer(Address, port);
                chatroom.connect();
                Thread thread = new Thread(chatroom.run).Start();
                return chatroom;
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public void createTopic(String topic)
        {
            try {
                sendMessage(new Message(Header.CREATE_TOPIC, topic)); // Sending message : server perform it
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
