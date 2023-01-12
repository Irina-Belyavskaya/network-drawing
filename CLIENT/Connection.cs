using Microsoft.VisualBasic;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CLIENT
{
    public partial class Connection : Form
    {
        public static string userName = "";
        private string ID = "";

        private string host = "";
        private int port = 0;

        public static TcpClient client = null;
        public static NetworkStream stream = null;

        public Connection()
        {
            InitializeComponent();
        }

        private bool SetParameters ()
        {
            port = Int32.Parse(TBPort.Text);
            if (port == 0)
            {
                MessageBox.Show("Enter port.");
                return false;
            }

            host = TBIPAdress.Text;
            if (host == "")
            {
                MessageBox.Show("Enter IP adress.");
                return false;
            }

            userName = TBUserName.Text;
            if (userName == "")
            {
                MessageBox.Show("Enter your name.");
                return false;
            }

            return true;
        }

        private bool ConnectToServer ()
        {
            try
            {
                // Connection
                client.Connect(host, port);
                stream = client.GetStream();
                stream.ReadTimeout = 100;
                return true;
            }
            catch
            {
                MessageBox.Show("Cannot connect to the server.");
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
                return false;
            }
        }

        private void WorkWithServer (string process)
        {
            client = new TcpClient();

            if (!ConnectToServer())
                return;
            try
            {
                // Send user nickname to server
                Send(userName);

                // Wait until nickname will come to server
                Thread.Sleep(1000);

                // Send answer
                Send(process);

                if (process == "1")
                {
                    Thread.Sleep(500);
                    Send(ID);

                    // Recive connected message
                    string reciveMes = Recive(stream);
                    if ("You connect to Room with ID: " + ID == reciveMes)
                        MessageBox.Show(reciveMes);
                    else
                    {
                        MessageBox.Show(reciveMes);
                        return;
                    }
                }
                else
                {
                    // Recieve id created room
                    ID = Recive(stream);
                    ShowID show = new ShowID(ID);
                    show.ShowDialog();
                }
                Painting WindowPaint = new Painting(process, ID);
                Hide();
                WindowPaint.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Cannot send information to the server.");
                Disconnect();
            }
             
        }

        private string Recive(NetworkStream stream)
        {
            byte[] data = new byte[64];
            StringBuilder builder = new StringBuilder();
            do
            {
                int bytes = stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (stream.DataAvailable);
            return builder.ToString();
        }

        private void Send (string message)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }

        private void Disconnect()
        {
            if (stream != null)
                stream.Close();
            if (client != null)
                client.Close();
            Environment.Exit(0);
        }

        private void BConnect_Click(object sender, EventArgs e)
        {
            if (SetParameters())
            {
                string promt = "Entere ID room  for connection.";
                string title = "Connection";
                string defaultValue = "-";
                ID = Interaction.InputBox(promt, title, defaultValue);
                if (ID != "")
                    WorkWithServer("1");
            }
        }

        private void BCreate_Click(object sender, EventArgs e)
        {
            if (SetParameters())
            {
                WorkWithServer("0");
            }
        }

    }
}
