using System;

namespace Projet.chat
{
    interface Chatroom
    {
        string Topic { get; set; }
        void post(String msg, Chatter c);
        void quit(Chatter c);
        void join(Chatter c);
    }
}
