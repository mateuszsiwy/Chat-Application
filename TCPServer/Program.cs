using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TCPServer
{
    class Program
    {
        static TcpClient client1;
        static TcpClient client2;
        static void Main(string[] args)
        {
            IPAddress localaddr = IPAddress.Parse("127.0.0.1");
            TcpListener server = new TcpListener(localaddr, 8080);
            server.Start();

            Console.WriteLine("Waiting for connection...");
            client1 = server.AcceptTcpClient();
            Console.WriteLine("user1 connected!");

            client2 = server.AcceptTcpClient();
            Console.WriteLine("user2 connected!");

            Thread thread1 = new Thread(HandleClient1);
            Thread thread2 = new Thread(HandleClient2);

            thread1.Start();
            thread2.Start();
        }

        static void HandleClient1()
        {
            try
            {
                NetworkStream stream1 = client1.GetStream();
                Byte[] bytes = new byte[256];
                int i;

                while ((i = stream1.Read(bytes, 0, bytes.Length)) != 0)
                {
                    string data = Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Received from user1: {0}", data);

                    byte[] msg = Encoding.ASCII.GetBytes(data);
                    NetworkStream stream2 = client2.GetStream();
                    stream2.Write(msg, 0, msg.Length);
                    Console.WriteLine("Sent to user2: {0}", data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in HandleClient1: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (client1 != null)
                {
                    client1.Close();
                    Console.WriteLine("User1 connection closed.");
                }
            }
        }

        static void HandleClient2()
        {
            try
            {
                NetworkStream stream2 = client2.GetStream();
                Byte[] bytes = new byte[256];
                int i;

                while ((i = stream2.Read(bytes, 0, bytes.Length)) != 0)
                {
                    string data = Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Received from user2: {0}", data);

                    byte[] msg = Encoding.ASCII.GetBytes(data);
                    NetworkStream stream1 = client1.GetStream();
                    stream1.Write(msg, 0, msg.Length);
                    Console.WriteLine("Sent to user1: {0}", data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in HandleClient2: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                if (client2 != null)
                {
                    client2.Close();
                    Console.WriteLine("User2 connection closed.");
                }
            }
        }
    }
};