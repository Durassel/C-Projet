using Projet.chat;
using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Projet.server
{
    class TCPTopicsManager : TextTopicsManager
    {
        private static int nextPort = 9000;
        private Dictionary<String, ServerChatroom> tcpChatrooms = new Dictionary<String, ServerChatroom>(); // Link a topic to a server chatroom (thanks to the topic, we can have the server and the chatroom)

        public new void createTopic(String topic)
        {
            try {
                // Initialization of TextTopicsManager attribute
                base.createTopic(topic);
                Chatroom chatroom = base.joinTopic(topic);
                // Initialization of ServerChatroom attribute
                ServerChatroom serverChatroom = new ServerChatroom(chatroom);
                // Initialization of TCPTopicsManager attribute
                tcpChatrooms[topic] = serverChatroom;
                // Search a valid port to start the chatroom
                Boolean validPort = true;
                do {
                    try {
                        serverChatroom.startServer(nextPort); // An exception occured when another process use this port
                        validPort = true;
                    } catch (SocketException e) {
                        validPort = false;
                        Console.WriteLine(e);
                    }
                    nextPort++;
                } while (!validPort);
            } catch (ChatroomExistsException e) { // TextTopicsManager.createTopic throws exception if this topic already exists
                throw e;
            }
        }

        public int getTopicPort(String topic)
        {
            return tcpChatrooms[topic].Port; // Return the server port of the topic chatroom
        }
    }
}
