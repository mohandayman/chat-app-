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

namespace Client_App
{
    public partial class Form1 : Form
    {
        TcpClient client;
       
        int portNumber;

        IPAddress myIP = Dns.GetHostByName(Dns.GetHostName()).AddressList[3];
        NetworkStream nStream;

        BinaryWriter binaryWriter;
        BinaryReader binaryReader;

        public Form1()
        {
            InitializeComponent();
             portNumber = 5024;


        }

        private void Start_Click(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient();
                client.Connect(myIP, portNumber) ;
            }catch (SocketException ex) {
                MessageBox.Show("The Exeption is : " + ex.Message);
            }

        }

        private void Send_Click(object sender, EventArgs e)
        {
            try
            {

                nStream = client.GetStream();
                binaryWriter = new BinaryWriter(nStream);
                binaryWriter.Write(textBox1.Text);
                binaryWriter.Close();
            }
            catch(NullReferenceException ex)
            { MessageBox.Show(ex.Message); }
            

        }

        private void Disconnect_Click(object sender, EventArgs e)
        {
            nStream.Close();
            client.Close();

        }

        private void Recieve_Click(object sender, EventArgs e)
        {
            nStream = client.GetStream();
            binaryReader = new BinaryReader(nStream);
            MessageBox.Show(binaryReader.ReadString());
            binaryReader.Close();
        }
    }
}
