using Projet.server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        private ServerTopicsManager serv;

        public Form1(ServerTopicsManager serv)
        {
            this.serv = serv;
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            try {
                int port = int.Parse(portText.Text);
                this.serv.startServer(port);
                this.start.Enabled = false;
                this.stop.Enabled = true;
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            this.serv.stopServer();
            this.stop.Enabled = false;
            this.start.Enabled = true;
        }
    }
}
