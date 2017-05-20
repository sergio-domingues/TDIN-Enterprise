using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse2
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

            Uri warehouseUri = new Uri("http://localhost:4000/");

            //todo on handlers add initial get method to retrieve items for the GUIs

            WarehouseCommunicationHandler warehouseHandler = new WarehouseCommunicationHandler(warehouseUri);

            warehouseGUI warehouseGUI = new warehouseGUI(warehouseHandler);

            Application.Run(warehouseGUI);
        }
    }
}
