using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("sending msg on socket");
            socket.Emit(msgType, msg);
        }

        abstract public void receiveMsg();
    }

    public class StoreCommunicationHandler : CommunicationHandler
    {
        public StoreCommunicationHandler(Uri uri) : base(uri)
        {
            receiveMsg();
        }

        override public void receiveMsg()
        {
            socket.On("info", (data) =>
            {
                Console.WriteLine(data);
                //socket.Emit("response", "received");
                // events.Enqueue(data);
                // ManualResetEvent.Set();
            });
        }
    }

    public class WarehouseCommunicationHandler : CommunicationHandler
    {        
        public WarehouseCommunicationHandler(Uri uri) : base(uri)
        {
            receiveMsg();
        }

        override public void receiveMsg()
        {
            socket.On("ack", (data) =>
            {
                Console.WriteLine(data);
                //socket.Emit("response", "received");
                // events.Enqueue(data);
                // ManualResetEvent.Set();
            });
        }
        

        /*public Socket storeSocket;
        public Uri storeURI;
        //todo
        public WarehouseCommunicationHandler(Uri uri) //: base(uri)
        {
            storeURI = uri;
            storeSocket = createStoreSocket();
            Console.WriteLine(">>>>>>>CREATED SOCKET");

            //receiveMsg();
        }

        protected Socket createStoreSocket()
        {
            var storeSocket = IO.Socket(storeURI);

            storeSocket.On(Socket.EVENT_CONNECT, () =>
            {
                Console.WriteLine("connected to storesocket");
            });

            return storeSocket;
        }
        
        public void sendMsg(string msgType, string msg)
        {
            Console.WriteLine("sending msg on socket from warehouse");
            storeSocket.Emit(msgType, msg);
        }         
         */
    }
}
