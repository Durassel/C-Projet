using System;
using System.Collections.Generic;

namespace Projet.chat
{
    class TextTopicsManager : TopicsManager
    {
        private Dictionary<String, Chatroom> chatrooms = new Dictionary<String, Chatroom>(); // List of topics/chatrooms

        public List<String> listTopics()
        {
            // Return topics
            List<String> topics = new List<String>(this.chatrooms.Keys);
            return topics;
        }

        public List<String> listMembers(String topic)
        {
            // Return members of a chatroom
            List<Chatter> chatters = chatrooms[topic].Chatters;
            List<String> members = new List<String>();
            foreach (Chatter chatter in chatters) {
                members.Add(chatter.Pseudo);
            }
            return members;
        }

        public Chatroom joinTopic(String topic)
        {
            // Return the chatroom of this topic
            return chatrooms[topic];
        }

        public void createTopic(String topic)
        {
            // Check if the topic already exists
            if (!chatrooms.ContainsKey(topic)) {
                chatrooms[topic] = new TextChatroom(topic);
            } else {
                throw new ChatroomExistsException(topic);
            }
	    }
    }
}
