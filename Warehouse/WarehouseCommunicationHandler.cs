using Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{   
    public class WarehouseCommunicationHandler : CommunicationHandler
    {
        public warehouseGUI gui { get; set; }

        public WarehouseCommunicationHandler(Uri uri) : base(uri)
        {
            receiveMsg();
        }

        override public void receiveMsg()
        {
            Console.WriteLine("Comm handler: receiveing msgs");
            
            socket.On("ack", (data) =>
            {
                Console.WriteLine(data);
                //socket.Emit("response", "received");
                // events.Enqueue(data);
                // ManualResetEvent.Set();
            });

            socket.On("orderList", (data) =>
            {
                Console.WriteLine(data);
                gui.initialOrdersView((JObject)data);
            });
            
            socket.On("order", (data) =>
            {
                gui.addOrderView((string)data);
            });

            

        }
    }
}
