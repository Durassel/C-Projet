using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace Projet.net
{
    class TCPClient : MessageConnection
    {
        private TcpClient client = new TcpClient();
        private IPAddress address;
        private int port;

        public IPAddress Address
        {
            get { return this.address; }
        }

        public int Port
        {
            get { return this.port; }
        }

        public void setServer(string address, int port)
        {
            this.address = IPAddress.Parse(address);
            this.port = port;
        }

        public void connect()
        {
            client.Connect(this.address, this.port);
            Console.WriteLine("Connection established");
        }

        public void disconnect()
        {
            client.Close();
        }

        public Message getMessage()
        {
            BinaryFormatter bf = new BinaryFormatter();
            Message message = (Message) bf.Deserialize(client.GetStream());
            Console.WriteLine("Client receive : " + message);
            return message;
        }

        public void sendMessage(Message message)
        {
            Console.WriteLine("Client send : " + message);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(client.GetStream(), message);
        }
    }
}
