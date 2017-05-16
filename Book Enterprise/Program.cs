using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net; //For our IPAddress
using System.Net.Sockets; //For our TcpClient
using System.Windows.Forms;

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
           

            TcpClient client = new TcpClient();
            client.Connect(IPAddress.Loopback, 3000); //Connect to the server on our local host IP address, listening to port 3000

            NetworkStream clientStream = client.GetStream();

            Console.WriteLine("Starting to read info");

            while (clientStream.DataAvailable) //While the network stream say's there is data to be read
            {
                byte[] inMessage = new byte[4096];
                int bytesRead = 0;
                try
                {
                    bytesRead = clientStream.Read(inMessage, 0, 4096);
                }
                catch { /*Catch exceptions and handle them here*/ }

                ASCIIEncoding encoder = new ASCIIEncoding();
                Console.WriteLine(encoder.GetString(inMessage, 0, bytesRead));
            }                      

            client.Close();

            System.Threading.Thread.Sleep(10000); //Sleep for 10 seconds

            Application.Run(new Form1());
        }
    }
}
