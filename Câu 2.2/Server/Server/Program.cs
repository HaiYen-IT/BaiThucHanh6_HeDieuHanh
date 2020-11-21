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
                    string str = reader.ReadLine();
                    string[] n = str.Split("|".ToCharArray());
                    int a = Convert.ToInt32(n[0]);
                    int b = Convert.ToInt32(n[1]);
                    Console.WriteLine("Ban da nhap a = " + a + ", b = " + b);
                    int tong = a * a * a + b * b * b;
                    writer.WriteLine(tong);



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

