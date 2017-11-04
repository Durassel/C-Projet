using Projet.net;
using System;
using System.Net.Sockets;
using static Projet.net.Message;

namespace Projet
{
    class TestTCPServer : TCPServer
    {
        static void Main(string[] args)
        {
            TestTCPServer serv = new TestTCPServer();
            try {
                serv.startServer(2453);
                Console.WriteLine("Press enter to quit...");
                Console.Read();
                serv.stopServer();
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        public override void manageClient(TcpClient comm)
        {
            try {
                getMessage();
                sendMessage(new Message(Header.DEBUG, "pong from server"));
                Console.WriteLine("Server finished handling client.");
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
