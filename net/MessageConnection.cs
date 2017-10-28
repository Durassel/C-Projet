namespace Projet.net
{
    interface MessageConnection
    {
        Message getMessage();
        void sendMessage(Message m);
    }
}
