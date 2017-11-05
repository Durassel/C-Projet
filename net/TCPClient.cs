using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Projet.net
{
    [Serializable]
    public class TCPClient : MessageConnection
    {
        private TcpClient client = new TcpClient(); // Client connection to the server
        private IPAddress address; // Address of the server
        private int port; // Port to communicate

        public String Address
        {
            get { return this.address.ToString(); }
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
            //Console.WriteLine("Connection established.");
        }

        public void disconnect()
        {
            client.Close();
            //Console.WriteLine("Connection closed.");
        }

        public Message getMessage()
        {
            try {
                NetworkStream stream = client.GetStream();
                IFormatter formatter = new BinaryFormatter();
                Message message = (Message)formatter.Deserialize(stream);
                //Console.WriteLine("Client receive : " + message);
                return message;
            } catch (Exception e) {
                return null;
            }
        }

        public void sendMessage(Message message)
        {
            //Console.WriteLine("Client send : " + message);
            IFormatter formatter = new BinaryFormatter();
            NetworkStream stream = client.GetStream();
            formatter.Serialize(stream, message);
        }
    }
}
