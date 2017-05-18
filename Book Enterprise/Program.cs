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
            
            Application.Run(new Form1(commHandler));
        }       
    }
}
