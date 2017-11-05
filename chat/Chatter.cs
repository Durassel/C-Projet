using System;

namespace Projet.chat
{
    public interface Chatter
    {
        string Pseudo { get; set; }
        string Password { get; set; }
        void receiveAMessage(String msg, Chatter c);
        void joinNotification(Chatter c);
        void quitNotification(Chatter c);
    }
}
