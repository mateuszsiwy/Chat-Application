using System.Net.Sockets;
using System.Text;

namespace TCPClientLibrary
{
    public class TCPClient
    {
        public string message;
        public string received;
        NetworkStream stream;
        TcpClient client;
        string publicKey = string.Empty;
        public async Task SendAsync()
        {
            // IPAddress localaddr = IPAddress.Parse("127.0.0.1");

            client = new TcpClient("127.0.0.1", 8080);
            publicKey = ReceivePublicKey(client);
            stream = client.GetStream();

            _ = Task.Run(() => ReceiveAsync(stream));

            while (true)
            {
                if (message != null)
                {
                    Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                    await stream.WriteAsync(data, 0, data.Length);
                    message = null;
                }
                
                /*Console.WriteLine(message);*/
                // PROBLEMEM JEST WYKONYWANIE RZECZY Z KONSOLI JAK ODPALAM PRZEZ GUI
            }
        }

        static string ReceivePublicKey(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] data = new byte[2048];
            int i = stream.Read(data, 0, data.Length);
            return Encoding.ASCII.GetString(data, 0, i);
        }
        async Task ReceiveAsync(NetworkStream stream)
        {
            Byte[] data = new byte[256];
            while (true)
            {
                try
                {
                    int bytes = await stream.ReadAsync(data, 0, data.Length);
                    if (bytes == 0)
                    {
                        break;
                    }

                    string responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    received = responseData;
                    //Console.WriteLine("Received: {0}", responseData);
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.ToString());
                    break;
                }
            }
        }
        public void Disconnect()
        {
            if(client != null)
            {
                stream.Close();
                client.Close();
            }
        }
    }
}
