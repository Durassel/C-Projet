using System;

namespace Projet.chat
{
    interface Chatroom
    {
        string Topic { get; }
        void post(String msg, Chatter c);
        void quit(Chatter c);
        void join(Chatter c);
    }
}
