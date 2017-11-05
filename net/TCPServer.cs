using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Projet.net
{
    public abstract class TCPServer : MessageConnection, ICloneable
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
        }

        public void stopServer()
        {
            wait.Stop();
            Console.WriteLine("Server stopped");
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void run()
        {
            if (mode == Mode.treatConnections) {
                while (true) {
                    wait.Start(); // ~~~ bof ~~~
                    try {
                        comm = wait.AcceptTcpClient(); // New client communication
                        Console.WriteLine("Connection established @" + comm);
                        TCPServer clone = (TCPServer)this.Clone();
                        clone.mode = Mode.treatClient; // Change mode
                        new Thread(clone.run).Start();
                    } catch (System.IO.IOException e) {
                        //Console.WriteLine(e.ToString());
                    } catch (SocketException e) {
                        //Console.WriteLine(e.ToString());
                    }
                }
            } else { // Manage client request
                manageClient(comm);
            }
        }

        public abstract void manageClient(TcpClient comm); // Client/Server manage the request 

        public Message getMessage()
        {
            try {
                NetworkStream stream = comm.GetStream();
                IFormatter formatter = new BinaryFormatter();
                Message message = (Message) formatter.Deserialize(stream);
                Console.WriteLine("Server receive : " + message);
                return message;
            } catch (Exception e) {
                return null;
            }
        }
	
        public void sendMessage(Message message)
        {
            Console.WriteLine("Server send : " + message);
            IFormatter formatter = new BinaryFormatter();
            NetworkStream stream = comm.GetStream();
            formatter.Serialize(stream, message);
        }
    }
}
