using System;

namespace Projet.chat
{
    interface Chatter
    {
        string Pseudo { get; set; }
        string Password { get; set; }
        void receiveAMessage(String msg, Chatter c);
    }
}
