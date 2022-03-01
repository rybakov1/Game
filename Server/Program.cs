using System.Net;
using System.Net.Sockets;
using Game.NetworkMessages;

namespace Game.Server
{

#pragma warning disable CS8618
	class Msgs
	{
		public Message inMsg;
		public Message outMsg;
	}
#pragma warning restore CS8618


	class Program
	{

		static int port = 26665;
		static TcpListener listener;
		static Dictionary<TcpClient, Msgs> clients = new();

		static void Main(string[] args)
		{
			Run();
		}

		// Main server method
		static void Run()
		{
			IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, port);
			listener = new(endPoint);
			listener.Start();

			while (true)
			{
				AcceptConnections(ref clients); // adds new connections
				ReceiveInputs(ref clients); // gets incoming messages from all connections
				DoGameLogic(ref clients); // processes all messages, creates outgoing messages
				SendResults(ref clients); // sends outgoing messages to all connections
			}
		}

		/// <summary>
		/// Adds new connections.
		/// </summary>
		/// <param name="clients"></param>
		static void AcceptConnections(ref Dictionary<TcpClient, Msgs> clients)
		{
			if (listener.Pending())
			{
				var newClient = listener.AcceptTcpClient();
				clients.Add(newClient, new Msgs());
			}
		}

		/// <summary>
		/// Gets incoming messages from all connections.
		/// </summary>
		/// <param name="clients"></param>
		static void ReceiveInputs(ref Dictionary<TcpClient, Msgs> clients)
		{
			var clientList = clients.ToList();

			foreach (var client in clientList)
			{
				client.Value.inMsg = (Message)client.Key.GetStream().Read();
			}
		}

		/// <summary>
		/// Processes all messages, creates outgoing messages.
		/// </summary>
		/// <param name="clients"></param>
		/// <exception cref="NotImplementedException"></exception>
		static void DoGameLogic(ref Dictionary<TcpClient, Msgs> clients)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Sends outgoing messages to all connections.
		/// </summary>
		/// <param name="clients"></param>
		static void SendResults(ref Dictionary<TcpClient, Msgs> clients)
		{
			var clientList = clients.ToList();

			foreach (var client in clientList)
			{
				client.Key.GetStream().Write((byte[])client.Value.outMsg);
			}
		}
	}
}