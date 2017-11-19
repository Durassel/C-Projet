using Projet.server;
using System;
using System.Net.Sockets;
using static Projet.net.Message;

namespace Projet
{
    class TestTCPServer : ServerTopicsManager
    {
        static void Main(string[] args)
        {
            ServerTopicsManager server = new ServerTopicsManager();
            try {
                server.startServer(2453);
                server.stopServer(); // Don't interrupt the thread server listener : wait in while(true)
            } catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}
