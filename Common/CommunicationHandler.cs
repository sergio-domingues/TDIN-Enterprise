using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Windows.Forms;

namespace Common
{
    public abstract class CommunicationHandler
    {
        protected Socket socket { get; set; }
        protected Uri serverUri { get; set; }

        public CommunicationHandler(Uri uri)
        {
            serverUri = uri;
            socket = createSocket();
        }

        protected Socket createSocket()
        {
            var socket = IO.Socket(serverUri);

            socket.On(Socket.EVENT_CONNECT, () =>
            {
                Console.WriteLine("connected");
            });

            return socket;
        }

        public void disconnect()
        {
            socket.Close();

            //socket.disconnect() o socket.close() triggers EVENT_DISCONNECT event handled by this function
            socket.On(Socket.EVENT_DISCONNECT,
               (data) =>
               {
                   Console.WriteLine(data);
               });
        }

        public void sendMsg(string msgType, string msg)
        {
            Console.WriteLine("sending msg on socket " + msgType + " " + msg);
            socket.Emit(msgType, msg);
        }

        abstract public void receiveMsg();
    } 
    
}
