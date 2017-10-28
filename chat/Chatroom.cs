using System;

namespace Projet.chat
{
    interface Chatroom
    {
        void post(String msg, Chatter c);
        void quit(Chatter c);
        void join(Chatter c);
        string Topic { get; set;  }
    }
}
