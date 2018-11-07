using System;
using System.Net;
using System.Net.Sockets;

namespace Servidor
{
	public class Server
    {
        public static TcpListener serverSocket;
        public Client[] Clients = new Client[Const.MAX_PLAYERS];

        public static void InitNetwork()
        {
            serverSocket = new TcpListener(IPAddress.Any, 5555);
            serverSocket.Start();
            serverSocket.BeginAcceptTcpClient(ClientConnectCallback, null);
        }

        private static void ClientConnectedCallback(IAsyncResult result)
        {
            TcpClient client = serverSocket.EndAcceptTcpClient(result)
        }

    }
}
