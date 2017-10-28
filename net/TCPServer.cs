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
	    private enum Mode { treatClient, treatConnections }
        private Mode mode = Mode.treatConnections;
        private TcpClient comm;
        private TcpListener wait;
        private int port;

        public void startServer(int port)
        {
            this.port = port;
            Console.WriteLine("Server started");
            wait = new TcpListener(new IPAddress(new byte[] { 127, 0, 0, 1 }), port);
            new Thread(this.run).Start();
            Console.WriteLine("thread started");
        }

        public void stopServer()
        {
            wait.Stop();
        }

        public void run()
        {
            if (mode == Mode.treatConnections) {
                while (true) {
                    try
                    {
                        comm = wait.AcceptTcpClient();
                        Console.WriteLine("Connection established @" + comm);

                        TCPServer clone = Clone(this);
                        clone.mode = Mode.treatClient;
                        new Thread(clone.run).Start();
                    } catch (System.IO.IOException e) {
                        Console.WriteLine(e.ToString());
                    }
                }
            } else {
                Console.WriteLine("Dealing with client");
                manageClient(comm);
            }
        }

        public static TCPServer Clone(TCPServer obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter f = new BinaryFormatter();
                f.Serialize(ms, obj);
                ms.Position = 0;
                return (TCPServer) f.Deserialize(ms);
            }
        }

        public int Port
        {
            get { return this.port; }
        }

        public abstract void manageClient(TcpClient comm);

        public Message getMessage()
        {
            try {
                BinaryFormatter bf = new BinaryFormatter();
                Message message = (Message)bf.Deserialize(comm.GetStream());
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
