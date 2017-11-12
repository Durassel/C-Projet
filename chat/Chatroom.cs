using System;
using System.Collections.Generic;

namespace Projet.chat
{
    public interface Chatroom
    {
        string Topic { get; }
        List<Chatter> Chatters { get; }
        void post(String msg, Chatter c);
        void quit(Chatter c);
        void join(Chatter c);
    }
}
