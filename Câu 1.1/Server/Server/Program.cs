using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace Server
{
    class cau1
    {
        private const int PORT_NUMBER = 9999;
        static void Main(string[] args)
        {
            try
            {
                IPAddress address = IPAddress.Parse("127.0.0.1");
                TcpListener listener = new TcpListener(address, PORT_NUMBER);
                listener.Start();
                Console.WriteLine("Server started on " + listener.LocalEndpoint);
                Console.WriteLine("Waiting for a connection...");
                Socket socket = listener.AcceptSocket();
                var stream = new NetworkStream(socket);
                var reader = new StreamReader(stream);
                var writer = new StreamWriter(stream);
                writer.AutoFlush = true;
                while (true)
                {   
                    int n = Convert.ToInt32(reader.ReadLine());
                    Console.WriteLine("Ban da nhap n = " + n);
                    int sum = 0;
                    for (int i = 0; i <= n; i++)
                    {
                        sum += (2 * i + 1);
                    }
                    writer.WriteLine(sum);
                }
                socket.Close();
                listener.Stop();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            Console.Read();
            
        }
    }
}
