using Projet.chat;
using System;
using System.Collections.Generic;

namespace Projet.server
{
    class TCPTopicsManager : TextTopicsManager
    {
        private static int nextPort = 16000;
        private Dictionary<String, ServerChatroom> tcpChatrooms = new Dictionary<String, ServerChatroom>();

        public new void createTopic(String topic)
        {
            try {
                base.createTopic(topic);
                Chatroom chatroom = base.joinTopic(topic);
                ServerChatroom serverChatroom = new ServerChatroom(chatroom);
                tcpChatrooms[topic] = serverChatroom;
                bool started = true;
                do { // Search a valid port
                    try {
                        serverChatroom.startServer(nextPort);
                        started = true;
                    } catch (System.IO.IOException e) {
                        started = false;
                        Console.WriteLine(e.ToString());
                    }
                    nextPort++;
                } while (!started);
            } catch (ChatroomExistsException e) {
                Console.WriteLine(e.ToString());
            }
        }

        public int getTopicPort(String topic)
        {
            return tcpChatrooms[topic].Port;
        }
    }
}
