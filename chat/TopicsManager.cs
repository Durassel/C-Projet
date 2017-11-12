using System;
using System.Collections.Generic;

namespace Projet.chat
{
    interface TopicsManager
    {
        List<String> listTopics();
        List<String> listMembers(String topic);
        Chatroom joinTopic(String topic);
        void createTopic(String topic);
    }
}
