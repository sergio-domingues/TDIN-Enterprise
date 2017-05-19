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

using Common;

namespace Store
{
    static class Store
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //store & warehouse URIs
            Uri storeUri = new Uri("http://localhost:3500/");
               
            

            //todo on handlers add initial get method to retrieve items for the GUIs

            //handlers
            StoreCommunicationHandler storeHandler = new StoreCommunicationHandler(storeUri);
           // WarehouseCommunicationHandler warehouseHandler = new WarehouseCommunicationHandler(warehouseUri);

            //GUIs
            StoreGUI storeGUI = new StoreGUI(storeHandler);
           // WarehouseGUI warehouseGUI = new WarehouseGUI(warehouseHandler);
            

            //warehouseGUI.Show();
            Application.Run(storeGUI);
        }
    }
}
