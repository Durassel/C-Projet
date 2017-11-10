using System;

namespace Projet.chat
{
    public interface Chatter
    {
        String Pseudo { get; set; }
        String Password { get; set; }
        void receiveAMessage(String message, Chatter c);
        void joinNotification(Chatter c);
        void quitNotification(Chatter c);
    }
}
