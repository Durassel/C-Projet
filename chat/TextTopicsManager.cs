using System;
using System.Collections.Generic;
using System.Text;

namespace Projet.chat
{
    class TextTopicsManager : TopicsManager
    {
        private Dictionary<String, Chatroom> chatrooms = new Dictionary<string, Chatroom>();

        public List<String> listTopics()
        {
            List<String> topics = new List<string>(this.chatrooms.Keys);
            Console.WriteLine("The openned topics are : ");
            foreach (String topic in topics) {
                Console.WriteLine(topic);
            }
            return topics;
        }

        public Chatroom joinTopic(String topic)
        {
            return chatrooms[topic];
        }

        public void createTopic(String topic)
        {
            if (!chatrooms.ContainsKey(topic)) {
                chatrooms[topic] = new TextChatroom(topic);
            } else {
                // Throw exception : topic already exists
            }
	    }
    }
}
