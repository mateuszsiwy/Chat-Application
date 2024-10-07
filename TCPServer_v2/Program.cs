using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace TCPServer
{
    class Program
    {
        static List<TcpClient> clients = new List<TcpClient>();
        static List<Thread> threads = new List<Thread>();
        static Dictionary<TcpClient, string> named = new Dictionary<TcpClient, string>();
        static List<string> activeUsers = new List<string>();
        static void Main(string[] args)
        {
            IPAddress localaddr = IPAddress.Parse("127.0.0.1");
            TcpListener server = new TcpListener(localaddr, 8080);
            server.Start();

            RSAKeyManager.GenerateAndSaveKeys(out string publicKey, out string privateKey);

            while(true)
            {
                TcpClient client = server.AcceptTcpClient();
                clients.Add(client);
                named.Add(client, "");
                Console.WriteLine("new user connected!");
                SendPublicKey(client, publicKey);
                Thread temp = new Thread(()=> HandleClient1(client));
                //SendAllUserNamesToClient(client);

                temp.Start();
                threads.Add(temp);
                //SendAllUserNamesToClient(client);
               
            }
        }

        static void SendPublicKey(TcpClient client, string publicKey)
        {
            NetworkStream stream = client.GetStream();
            byte[] data = Encoding.ASCII.GetBytes(publicKey);
            stream.Write(data, 0, data.Length);
            Console.WriteLine(publicKey);
        }

        static void UpdateClientList(string newUserName, bool add)
        {
            if (add)
            {
                activeUsers.Add(newUserName);
            }
            else
            {
                activeUsers.Remove(newUserName);
            }

            string userList = string.Join(",", activeUsers);
            byte[] messageBytes = Encoding.ASCII.GetBytes("USERLIST:"+userList);

            foreach(TcpClient client in clients)
            {
                NetworkStream stream = client.GetStream();
                stream.Write(messageBytes, 0, messageBytes.Length);
            }
        }
        
        static byte[] CombineMessage(string prefix, byte[] msg)
        {
            byte[] prefixBytes = Encoding.ASCII.GetBytes(prefix);
            byte[] combined = new byte[prefixBytes.Length + msg.Length];
            Buffer.BlockCopy(prefixBytes, 0, combined, 0, prefixBytes.Length);
            Buffer.BlockCopy(msg, 0, combined, prefixBytes.Length, msg.Length);
            return combined;
        }
        static void HandleClient1(TcpClient client)
        {
            try
            {
                NetworkStream stream1 = client.GetStream();
                Byte[] bytes = new byte[256];
                int i;

                i = stream1.Read(bytes, 0, bytes.Length);
                string clientName = Encoding.ASCII.GetString(bytes, 0, i);
                named[client] = clientName;

                UpdateClientList(clientName, true);

                while ((i = stream1.Read(bytes, 0, bytes.Length)) != 0)
                {
                    string data = Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Received from user1: {0}", data);

                    bool isPrivate = false;

                    foreach(TcpClient receiver in clients)
                    {
                        if (data.StartsWith(named[receiver]))
                        {
                            NetworkStream streamPrivate = receiver.GetStream();
                            string prefixPrivate = $"PRIVATE FROM {named[client]} TO ";
                            byte[] msgPrivate = Encoding.ASCII.GetBytes(data);
                            byte[] combinedPrivate = CombineMessage(prefixPrivate, msgPrivate);
                            streamPrivate.Write(combinedPrivate, 0, combinedPrivate.Length);
                            stream1.Write(combinedPrivate, 0, combinedPrivate.Length);
                            Console.WriteLine("Sent private message from user {0} to user {1}", named[client], named[receiver]);
                            isPrivate = true;
                        }
                    }

                    byte[] msg = Encoding.ASCII.GetBytes(data);
                    string prefix = $"{named[client]}";
                    byte[] combined = CombineMessage(prefix, msg);
                    if(isPrivate)
                    {
                        continue;
                    }
                        foreach (TcpClient clientSend in clients)
                        {
                            NetworkStream streamSend = clientSend.GetStream();
                            streamSend.Write(combined, 0, combined.Length);
                            Console.WriteLine("Sent to user: {0}", data);
                        }
                    
                    
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in HandleClient1: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (clients != null)
                {
                    foreach(TcpClient clientStop in clients)
                    {
                        UpdateClientList(named[clientStop], false);
                        clientStop.Close();
                        Console.WriteLine("User connection closed.");
                    }
                    
                }
            }
        }

        
    }

};