using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SERVER
{
    public class ServerObject
    {
        private const int DEFAULT_PORT = 7000;
        public struct Room
        {
            public string RoomID;
            public List<ClientObject> RoomClients;
        }

        private List<Room> _rooms = new List<Room>();
        TcpListener ServerSocket;

        public void AddRoom(string ID,ClientObject clientObject)
        {
            Room room = new Room();
            room.RoomID = ID;
            room.RoomClients = new List<ClientObject>();
            room.RoomClients.Add(clientObject);
            _rooms.Add(room);
        }
        public bool AddClientToRoom(string ID,ClientObject clientObject)
        {
            foreach (Room room in _rooms)
            {
                if (room.RoomID == ID)
                {
                    room.RoomClients.Add(clientObject);
                    return true;
                }
            }
            return false;
        }
        public void Listen()
        {
            try
            {
                ServerSocket = new TcpListener(IPAddress.Any, DEFAULT_PORT);
                ServerSocket.Start();
                Console.WriteLine("The server is running. Waiting for connections...");

                while (true)
                {
                    TcpClient tcpClient = ServerSocket.AcceptTcpClient();

                    ClientObject clientObject = new ClientObject(tcpClient, this);
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Disconnect();
            }
        }
        public void BroadcastMessage(byte[] data,int size, string ID, TcpClient CurrentClient)
        {
            // Search the right room
            foreach (Room room in _rooms)
            {
                if (room.RoomID == ID)
                {
                    // Send message about new user
                    for (int i = 0; i < room.RoomClients.Count; i++)
                    {
                        if (room.RoomClients[i].client != CurrentClient)
                            room.RoomClients[i].ClientStream.Write(data, 0, size);
                    }
                    break;
                }
            }
        }
        public void RemoveClient(string ID, ClientObject RemovableClient)
        {
            foreach (Room room in _rooms)
            {
                if (room.RoomID == ID)
                {
                    if (room.RoomClients.Count != 0)
                        room.RoomClients.Remove(RemovableClient);
                    if (room.RoomClients.Count == 0)
                        _rooms.Remove(room);
                    break;
                }
            }
        }
        public void Disconnect()
        {
            ServerSocket.Stop();
            foreach (Room room in _rooms)
            {
                for (int i = 0; i < room.RoomClients.Count; i++)
                {
                    room.RoomClients[i].Close(); //отключение клиента
                }
            }
            
            Environment.Exit(0); //завершение процесса
        }
    }
}
