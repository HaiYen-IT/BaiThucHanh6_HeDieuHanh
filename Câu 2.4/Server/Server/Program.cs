using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace Server
{
    class Program
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
                    int a = Convert.ToInt32(reader.ReadLine());
                    Console.WriteLine("Ban da nhap a = : " + a);
                    int b = Convert.ToInt32(reader.ReadLine());
                    Console.WriteLine("Ban da nhap b = : " + b);
                    int bcnn;

                    for (bcnn = a; bcnn <= a * b; bcnn++)
                    {
                        if (bcnn % a == 0 && bcnn % b == 0)
                        {
                            writer.WriteLine(bcnn);
                            break;
                        }
                    }

                }
                socket.Close();
                listener.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            Console.Read();

        }
    }
}
