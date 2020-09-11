using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;

namespace EchoClient
{
    class Client
    {
        public static void Start()
        {
            TcpClient socket = null;

            int port = 7777;
            IPAddress localAddress = IPAddress.Parse("10.200.165.17");

            socket = new TcpClient(localAddress.ToString(), port);

            Stream ns = socket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.WriteLine("Nej");
            sw.Flush();

            string line = sr.ReadLine();

            Console.WriteLine(line);

        }
    }
}
