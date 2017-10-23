using System;
using System.Collections.Generic;
using System.Text;

namespace Projet.chat
{
    interface Chatroom
    {
        void post(String msg, Chatter c);

        void quit(Chatter c);

        void join(Chatter c);

        string getTopic();
    }
}
