using Projet.net;
using System;
using static Projet.net.Message;

namespace Projet
{
    class TestTCPClient
    {
        static void Main(string[] args)
        {
            // Test de base de l'échange de messages entre serveur/client
            TCPClient cli = new TCPClient();
            try {
                cli.setServer("127.0.0.1", 2453);
                cli.connect();
                cli.sendMessage(new Message(Header.DEBUG, "Ping from client !"));
                cli.getMessage();
                cli.disconnect();
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
            Console.Read();
        }
    }
}
