using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System;

namespace Server
{
	class Program
	{

		static int port = 26665;
		//static string ip_address = "127.0.0.1";

		static IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, port);
		static Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

		static void Main(string[] args)
		{
			Run();
		}

		static List<TcpClient> clients = new();

		/// <summary>
		/// Main server method
		/// </summary>
		static void Run()
		{
			TcpListener listener = new(endPoint);
			listener.Start();

			// Game 
			while (true)
			{
				// Потребитель выходного канала работает с ограниченной функциональностью из-за отсутствия зависимой службы: Microsoft.VisualStudio.Shell.OutputChannelStore (0.1).

			}

			listener.Stop();
		}


		static void AcceptConnections(TcpListener listener)
		{
			if (listener.Pending())
			{
				var newClient = listener.AcceptTcpClient();
				SendServerInfo(newClient);

			}
		}

		static void SendServerInfo(TcpClient client)
		{
			throw new NotImplementedException();
		}
	}
}