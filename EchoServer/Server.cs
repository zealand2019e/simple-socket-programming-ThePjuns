using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace EchoServer
{
    class Server
    {
        public static void Start()
        {
            Console.WriteLine("starting echo biatch");

            TcpListener serverSocket = new TcpListener(IPAddress.Loopback, 7777);
            //TcpListener serverSocket = new TcpListener(7777);

            // Start server
            serverSocket.Start();

            // accept tcp client
            TcpClient connectionSocket = serverSocket.AcceptTcpClient();
            Console.WriteLine("server activated");

            Stream ns = connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; //enables automatic flushing


            while (true)
            {
                string message = sr.ReadLine();

            Console.WriteLine("received message: " + message);
            if (message != null)
                sw.WriteLine(message.ToUpper());

            if (message.ToLower() == "luk")
            {
                break;
            }
            }
            

            ns.Close();
            Console.WriteLine("net stream closed");
            connectionSocket.Close();
            Console.WriteLine("connection socket closed");
            serverSocket.Stop();
            Console.WriteLine("server stopped");



        }
    }
}