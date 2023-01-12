using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CLIENT
{
    public partial class Painting : Form
    {
        private bool isMousePressed = false;
        private ArrayPoints arrayPoints = new ArrayPoints(2);

        Bitmap bitmap = new Bitmap(100, 100);
        Graphics graphics;

        Pen pen = new Pen(Color.Black, 3f);

        private static Mutex mutex = new Mutex();
        Log log = Log.GetInstance();

        bool EndOfThread = false;
        Thread receiveThread;

        bool isCreate = false;

        private delegate void SafeCallDelegate(string text);

        public Painting(string process, string ID)
        {
            InitializeComponent();
            isCreate = process == "0";
            SetSettings();
            richTextBox.Text = richTextBox.Text + "ROOM ID: " + ID + Environment.NewLine;
            richTextBox.Text = richTextBox.Text + "Hi," + Connection.userName + "!" + Environment.NewLine;
            richTextBox.Text = richTextBox.Text + "Welcome in Online Paint!" + Environment.NewLine;
            log.WriteInLog("Program started", Connection.userName);
            
            receiveThread = new Thread(new ThreadStart(Receiver));
            receiveThread.Start();

            if (!isCreate)
            {
                Sender((byte)Commands.ClientConnected);
            }
        }

        private void SetSettings()
        {
            Rectangle rectangle = Screen.PrimaryScreen.Bounds;
            bitmap = new Bitmap(rectangle.Width, rectangle.Height);
            graphics = Graphics.FromImage(bitmap);

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void BClear_Click(object sender, EventArgs e)
        {
            mutex.WaitOne();
            graphics.Clear(pictureBox.BackColor);
            pictureBox.Image = bitmap;
            Sender((byte)Commands.ReciveBitmap);
            mutex.ReleaseMutex();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            isMousePressed = true;
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            isMousePressed = false;
            arrayPoints.ResetPoints();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMousePressed)
            {
                return;
            }
            arrayPoints.SetPoint(e.X, e.Y);
            if (arrayPoints.GetCountPoints() >= 2)
            {
                mutex.WaitOne();
                graphics.DrawLines(pen, arrayPoints.GetPoints());
                pictureBox.Image = bitmap;
                arrayPoints.SetPoint(e.X, e.Y);
                try
                {
                    Sender((byte)Commands.ReciveBitmap);
                }
                catch (Exception ex)
                {
                    log.WriteInLog("Sender : " + ex.ToString(), Connection.userName);
                    Disconnect();
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
        }

        private void BWhite_Click(object sender, EventArgs e)
        {
            pen.Color = ((Button)sender).BackColor;
        }

        private void BChooseColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog.Color;
                ((Button)sender).BackColor = colorDialog.Color;
            }
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = trackBar.Value;
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "JPG(*.JPG)|*.jpg";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (pictureBox.Image != null)
                {
                    pictureBox.Image.Save(saveFileDialog.FileName);
                }
            }
        }

        private void Sender(byte SendCommand)
        {
            byte[] byteArray = new byte[5];
            byteArray[0] = SendCommand;
            byte[] data = new byte[10];
            byte[] size = new byte[4];
            int i = 0;
            switch (SendCommand)
            {
                case (byte)Commands.ClientConnected:
                    data = Encoding.Unicode.GetBytes(Connection.userName);
                    size = BitConverter.GetBytes(data.Length);
                    i = 1;
                    foreach (byte b in size)
                    {
                        byteArray[i] = b;
                        i++;
                    }
                    byteArray = byteArray.Concat(data).ToArray();
                    Connection.stream.Write(byteArray, 0, byteArray.Length);
                    break;
                case (byte)Commands.ClientDisconnected:
                    data = Encoding.Unicode.GetBytes(Connection.userName);
                    size = BitConverter.GetBytes(data.Length);
                    i = 1;
                    foreach (byte b in size)
                    {
                        byteArray[i] = b;
                        i++;
                    }
                    byteArray = byteArray.Concat(data).ToArray();
                    Connection.stream.Write(byteArray, 0, byteArray.Length);
                    break;
                case (byte)Commands.ReciveBitmap:
                    TypeConverter bitmapConverter = TypeDescriptor.GetConverter(bitmap.GetType());
                    data = (byte[])bitmapConverter.ConvertTo(bitmap, typeof(byte[]));
                    size = BitConverter.GetBytes(data.Length);
                    i = 1;
                    foreach (byte b in size)
                    {
                        byteArray[i] = b;
                        i++;
                    }
                    byteArray = byteArray.Concat(data).ToArray();
                    Connection.stream.Write(byteArray, 0, byteArray.Length);
                    break;
                default:
                    break;
            }
            
        }

        private void Receiver()
        {
            while (!EndOfThread)
            {
                bool isGetFirstParameters = false;
                byte Command = 0;
                byte[] Data = new byte[10000000];
                int sizeData = 0;
                try
                {
                    byte[] byteArray = new byte[10000000];

                    int bytes = 0;
                    while (Connection.stream.DataAvailable) 
                    {
                        bytes = Connection.stream.Read(byteArray, 0, byteArray.Length);
                        if (!isGetFirstParameters)
                        {
                            Command = byteArray[0];
                            byte[] Size = new byte[4];
                            Size[0] = byteArray[1];
                            Size[1] = byteArray[2];
                            Size[2] = byteArray[3];
                            Size[3] = byteArray[4];
                            sizeData = BitConverter.ToInt32(Size, 0);
                            Data = new byte[sizeData];
                            for (int i = 0; i < sizeData; i++)
                            {
                                Data[i] = byteArray[i + 5];
                            }
                            isGetFirstParameters = true;
                        }
                        else
                        {
                            Array.Resize(ref Data, Data.Length + (sizeData - Data.Length));
                            Array.Resize(ref byteArray, (sizeData - Data.Length));
                            Data = Data.Concat(byteArray).ToArray();
                        }
                    }
                    


                    switch (Command)
                    {
                        case (byte)Commands.ClientConnected:
                            StringBuilder builder = new StringBuilder();
                            builder.Append(Encoding.Unicode.GetString(Data, 0, sizeData));
                            string mes = builder.ToString() + " connected to the room.";
                            WriteTextSafe(mes);
                            mutex.WaitOne();
                            Sender((byte)Commands.ReciveBitmap);
                            mutex.ReleaseMutex();
                            break;
                        case (byte)Commands.ClientDisconnected:
                            builder = new StringBuilder();
                            builder.Append(Encoding.Unicode.GetString(Data, 0, sizeData));
                            mes = builder.ToString() + " left the room.";
                            WriteTextSafe(mes);
                            break;
                        case (byte)Commands.ReciveBitmap:
                            mutex.WaitOne();
                            MemoryStream ms = new MemoryStream(Data, 0, sizeData);
                            bitmap = new Bitmap(ms);
                            graphics = Graphics.FromImage(bitmap);
                            pictureBox.Image = bitmap;
                            mutex.ReleaseMutex();
                            break;
                        default:
                            break;
                    }

                    
                }
                catch (Exception ex)
                {
                    log.WriteInLog("Reciver : " + ex.ToString(), Connection.userName);
                }

            }
        }

        private void WriteTextSafe(string text)
        {
            if (richTextBox.InvokeRequired)
            {
                var d = new SafeCallDelegate(WriteTextSafe);
                richTextBox.Invoke(d, new object[] { text });
            }
            else
            {
                richTextBox.Text = richTextBox.Text + text + Environment.NewLine;
            }
        }

        private void Disconnect()
        {
            EndOfThread = true;
            receiveThread.Join();
            if (Connection.stream != null)
            { 
                Connection.stream.Close();
            }
            if (Connection.client != null)
            {
                Connection.client.Close();
            }
            
            mutex.Dispose();
        }

        private void Painting_FormClosed(object sender, FormClosedEventArgs e)
        {
            Sender((byte)Commands.ClientDisconnected);
            Disconnect();
            Form ifrm = Application.OpenForms[0];
            ifrm.Close();
        }
    
    }
}
