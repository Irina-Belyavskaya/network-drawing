using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace SERVER
{
    public class ClientObject
    {
        public string Id { get; private set; }
        public string userName;

        public NetworkStream ClientStream { get; private set; }
        public TcpClient client;
        private ServerObject server;

        private int isConnect;

        private byte Command;      
        private int sizeData;

        public ClientObject(TcpClient tcpClient, ServerObject serverObject)
        {
            client = tcpClient;
            server = serverObject;
        }
        public void Process()
        {
            try
            {
                ClientStream = client.GetStream();

                // Recive user Name
                userName = GetMessage();

                // Recive answer to question: Create(0) or Connect(1)?
                string message = GetMessage();
                isConnect = Int16.Parse(message);

                // Connect
                if (isConnect == 1)
                {
                    // Recive Room ID
                    Id = GetMessage();

                    // Add client to room
                    if (server.AddClientToRoom(Id, this))
                    {
                        // Send connected message
                        string MesCreate = "You connect to Room with ID: " + Id;
                        byte[] data = Encoding.Unicode.GetBytes(MesCreate);
                        ClientStream.Write(data, 0, data.Length);

                        Console.WriteLine(userName + " connected to the room.");
                    } 
                    else
                    {
                        string MesCreate = "Room doesn`t exist with such ID: " + Id;
                        byte[] data = Encoding.Unicode.GetBytes(MesCreate);
                        ClientStream.Write(data, 0, data.Length);

                        Console.WriteLine(userName + " cant`t connect to the non-existent room.");
                    }

                    
                }
                // Create
                else
                {
                    Id = Guid.NewGuid().ToString();
                    // Send ID to client (ID ctreated room)
                    byte[] data = Encoding.Unicode.GetBytes(Id);
                    ClientStream.Write(data, 0, data.Length);
                    
                    // Add client who create room to list
                    server.AddRoom(Id, this);

                    Console.WriteLine(userName + " created the room.");
                }
                bool isClose = false;
                while (!isClose)
                {
                    try
                    {
                        byte[] data = ReciveBytes();
                        switch (Command)
                        {
                            case (byte)Commands.ClientConnected:
                                server.BroadcastMessage(data, data.Length, Id, client);
                                break;
                            case (byte)Commands.ClientDisconnected:
                                server.RemoveClient(Id, this);
                                server.BroadcastMessage(data, data.Length, Id, client);
                                Console.WriteLine(userName + " left the room.");
                                Close();
                                isClose = true;
                                break;
                            case (byte)Commands.ReciveBitmap:
                                if (sizeData != 0)
                                    server.BroadcastMessage(data, data.Length, Id, client);
                                break;
                            default:
                                break;
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private byte[] ReciveBytes()
        {
            byte[] byteArray = new byte[10000000];
            byte[] Data = new byte[10000000]; 
            int bytes = 0;
            Command = 0;
            bool isGetFirstParameters = false;
            while (ClientStream.DataAvailable)
            {
                bytes = ClientStream.Read(byteArray, 0, byteArray.Length);
                if (!isGetFirstParameters)
                {
                    Command = byteArray[0];
                    byte[] Size = new byte[4];
                    Size[0] = byteArray[1];
                    Size[1] = byteArray[2];
                    Size[2] = byteArray[3];
                    Size[3] = byteArray[4];
                    sizeData = BitConverter.ToInt32(Size, 0);
                    Data = new byte[sizeData + 5];
                    Array.Copy(byteArray, Data, sizeData + 5);
                    isGetFirstParameters = true;
                } else
                {
                    Array.Resize(ref Data,Data.Length + (sizeData - Data.Length));
                    Array.Resize(ref byteArray, (sizeData - Data.Length));
                    Data = Data.Concat(byteArray).ToArray();
                }                
            }
            
            return Data;
        }
        private string GetMessage()
        {
            byte[] data = new byte[64]; 
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = ClientStream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (ClientStream.DataAvailable);

            return builder.ToString();
        }

        public void Close()
        {
            if (ClientStream != null)
                ClientStream.Close();
            if (client != null)
                client.Close();
        }
    }
}
