using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server_App
{
    public partial class Form1 : Form
    {
        byte[] bytes = new byte[] { 127, 0, 0, 1 };
        int portNumber = 5024;
        IPAddress myIP = Dns.GetHostByName(Dns.GetHostName()).AddressList[3];

        Socket connection;
        Stream newtwork_stream;
        BinaryReader br;
        BinaryWriter bw;




        TcpListener listener;
        public Form1()
        {
            InitializeComponent();
            myIP = Dns.GetHostByName(Dns.GetHostName()).AddressList[3];
           listener = new TcpListener(myIP, portNumber);
           


        }

        private void Start_Click(object sender, EventArgs e)
        {
            listener.Start();

        }

        private void Send_Click(object sender, EventArgs e)
        {
            connection = listener.AcceptSocket();
            newtwork_stream = new NetworkStream(connection);
            bw = new BinaryWriter(newtwork_stream);
            bw.Write(textBox1.Text);

        }

        private void End_Click(object sender, EventArgs e)
        {
          connection.Shutdown(SocketShutdown.Both);
        }

        private void Recieve_Click(object sender, EventArgs e)
        {
             connection = listener.AcceptSocket();
             newtwork_stream = new NetworkStream(connection);
             br = new BinaryReader(newtwork_stream);
            MessageBox.Show(br.ReadString());


        }

       
    }
}


