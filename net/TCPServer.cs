using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Projet.net
{
    [Serializable]
    public abstract class TCPServer : MessageConnection
    {
	    private enum Mode { treatClient, treatConnections } // Two mode : client request / connection request
        private Mode mode = Mode.treatConnections;
        private TcpClient comm; // Communication
        private TcpListener wait; // Listener
        private int port;

        public int Port
        {
            get { return this.port; }
        }

        public void startServer(int port)
        {
            this.port = port;
            Console.WriteLine("Server started");
            wait = new TcpListener(new IPAddress(new byte[] { 127, 0, 0, 1 }), port);
            new Thread(this.run).Start();
            Console.WriteLine("Thread started");
        }

        public void stopServer()
        {
            wait.Stop();
        }

        public void run()
        {
            if (mode == Mode.treatConnections) {
                while (true) {
                    try {
                        comm = wait.AcceptTcpClient(); // New client communication
                        Console.WriteLine("Connection established @" + comm);
                        TCPServer clone = Clone(this);
                        clone.mode = Mode.treatClient; // Change mode
                        new Thread(clone.run).Start();
                    } catch (System.IO.IOException e) {
                        Console.WriteLine(e.ToString());
                    }
                }
            } else { // Client side
                Console.WriteLine("Dealing with client");
                manageClient(comm);
            }
        }

        public abstract void manageClient(TcpClient comm); // Client/Server manage the request (each case : join, post, list topics, create topic ...)

        public static TCPServer Clone(TCPServer obj) // Clone a TCPServer object
        {
            using (MemoryStream ms = new MemoryStream()) {
                BinaryFormatter f = new BinaryFormatter();
                f.Serialize(ms, obj);
                ms.Position = 0;
                return (TCPServer) f.Deserialize(ms);
            }
        }

        public Message getMessage()
        {
            try {
                BinaryFormatter bf = new BinaryFormatter();
                Message message = (Message) bf.Deserialize(comm.GetStream());
                Console.WriteLine("Server receive : " + message);
                return message;
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                return null;
            }
	    }
	
        public void sendMessage(Message message)
        {
            Console.WriteLine("Server send : " + message);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(comm.GetStream(), message);
        }
    }
}
