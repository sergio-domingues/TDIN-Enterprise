using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Enterprise
{
    public class CommunicationHandler
    {
       protected Socket socket { get; set; }
       protected Uri serverUri { get; set; }

       public CommunicationHandler(Uri uri){
            serverUri = uri;
            socket = createSocket();
            receiveMsg();
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


        public void sendMsg(string msgType, string msg)
        {            
            socket.Emit(msgType, msg);
        }
        public void receiveMsg()
        {
            socket.On("info", (data) =>
            {
                Console.WriteLine(data);
                //socket.Emit("response", "received");
                // events.Enqueue(data);
                // ManualResetEvent.Set();
            });
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

    }
}
