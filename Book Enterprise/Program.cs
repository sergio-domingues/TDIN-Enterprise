using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.WebSockets;
using System.Threading;
using SocketIOClient;
using System.Net.Sockets;
using Quobject.SocketIoClientDotNet.Client;
using System.Collections.Generic;

namespace Book_Enterprise
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Uri serverUri = new Uri("http://localhost:3000/");

            CommunicationHandler commHandler = new CommunicationHandler(serverUri);
            
            //sendMsg(socket);

            Application.Run(new Form1(commHandler));
        }
       
        static async Task Cli()
        {
            //("ws://localhost:3000/socket.io/?EIO=2&transport=websocket");

            ClientWebSocket ws = new ClientWebSocket();
            var uri = new Uri("ws://localhost:3000/socket.io/?EIO=2&transport=websocket");

            await ws.ConnectAsync(uri, CancellationToken.None);

            var buffer = new byte[1024];
            while (true)
            {
                var segment = new ArraySegment<byte>(buffer);

                var result = await ws.ReceiveAsync(segment, CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await ws.CloseAsync(WebSocketCloseStatus.InvalidMessageType, "I don't do binary", CancellationToken.None);
                    return;
                }

                int count = result.Count;
                while (!result.EndOfMessage)
                {
                    if (count >= buffer.Length)
                    {
                        await ws.CloseAsync(WebSocketCloseStatus.InvalidPayloadData, "That's too long", CancellationToken.None);
                        return;
                    }

                    segment = new ArraySegment<byte>(buffer, count, buffer.Length - count);
                    result = await ws.ReceiveAsync(segment, CancellationToken.None);
                    count += result.Count;
                }

                var message = Encoding.UTF8.GetString(buffer, 0, count);
                Console.WriteLine(">" + message);
            }        
        }
    }
}
