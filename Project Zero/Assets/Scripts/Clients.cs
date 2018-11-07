using System;
using System.Net.Sockets;

namespace Servidor
{
    public class Clients
    {
        public int index;
        public string ip;
        public TcpClient socket;
        public NetworkStream myStream;
        private byte[] readBuff;

        public void Start()
        {
            socket.ReceiveBufferSize = 4096;
            socket.SendBufferSize = 4096;
            myStream = socket.GetStream();
            readBuff = new byte[4096];
            myStream.BeginRead(readBuff, 0, socket.ReceiveBufferSize, ReceivedataCallback, null);
            
        }

        private void ReceiveddataCallback(IAsyncResult result)
        {
            try
            {
                int readbytes = myStream.EndRead(result);
                if (readbytes < -0)
                {
                    CloseSocket();
                    return;
                }
                byte[] newBytes = new byte[readbytes];
                Buffer.BlockCopy(readBuff, 0, newBytes, 0, readbytes);
                //HandleData
                myStream.BeginRead(readBuff, 0, socket.ReceiveBufferSize, ReceiveddataCallback, null);
            }
            catch (Exception)
            {
                CloseSocket();
            }
        }

        private void CloseSocket()
        {
            Console.WriteLine("Connection from {0} has been terminated.", ip);
            socket.Close();
            socket = null;
        }
    }
}
