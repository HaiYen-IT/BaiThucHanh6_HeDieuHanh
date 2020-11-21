using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace Client
{
    class Program
    {
        private const int PORT_NUMBER = 9999;
        static void Main(string[] args)
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect("127.0.0.1", PORT_NUMBER);
                Stream stream = client.GetStream();
                Console.WriteLine("Connected to Server");
                while (true)
                {
                    var reader = new StreamReader(stream);
                    var writer = new StreamWriter(stream);
                    writer.AutoFlush = true;
                    Console.Write("Nhap a: ");
                    string a = Console.ReadLine();
                    Console.Write("Nhap b: ");
                    string b = Console.ReadLine();
                    writer.WriteLine(a);
                    writer.WriteLine(b);
                    Console.WriteLine("Uoc chung lon nhat la: " + reader.ReadLine());

                }
                stream.Close();
                client.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            Console.Read();

        }
    }
}
