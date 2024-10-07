using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // IPAddress localaddr = IPAddress.Parse("127.0.0.1");

            using TcpClient client = new TcpClient("127.0.0.1", 8080);

            NetworkStream stream = client.GetStream();
            
            _= Task.Run(() => ReceiveAsync(stream));

            while(true)
            {
                string message = Console.ReadLine();
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                await stream.WriteAsync(data, 0, data.Length); 
                /*Console.WriteLine(message);*/
            }
        }

        static async Task ReceiveAsync(NetworkStream stream)
        {
            Byte[] data = new byte[256];
            while(true)
            {
                try
                {
                    int bytes = await stream.ReadAsync(data, 0, data.Length);
                    if (bytes == 0) { 
                        break;
                    }

                    string responseData  = System.Text.Encoding.ASCII.GetString(data, 0 , bytes);
                    Console.WriteLine("Received: {0}", responseData);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    break;
                }
            }
        }
    }
};