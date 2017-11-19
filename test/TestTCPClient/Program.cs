using Projet.chat;
using Projet.client;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Projet
{
    class TestTCPClient
    {
        static void Main(string[] args)
        {
            // Test de base de l'échange de messages entre serveur/client
            ClientTopicsManager client = new ClientTopicsManager();
            try {
                client.setServer("127.0.0.1", 2453);
                client.connect();

                client.createTopic("topic 1");
                client.createTopic("topic 2");

                List<String> topics = client.listTopics();
                Console.WriteLine("The openned topics are : ");
                foreach (String topic in topics)
                {
                    Console.WriteLine(topic);
                }

                Chatroom chatroom = client.joinTopic("topic 2");

                Chatter chatter = new TextChatter("bob", "123");
                chatroom.join(chatter);

                chatroom.post("nouveau message", chatter);
                Thread.Sleep(10000);
                chatroom.quit(chatter);
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
