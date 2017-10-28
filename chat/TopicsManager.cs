using System;
using System.Collections.Generic;

namespace Projet.chat
{
    interface TopicsManager
    {
        List<String> listTopics();
        Chatroom joinTopic(String topic);
        void createTopic(String topic);
    }
}
