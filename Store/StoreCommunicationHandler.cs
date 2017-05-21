﻿using Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class StoreCommunicationHandler : CommunicationHandler
    {
        public StoreGUI gui { get; set; }

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

            socket.On("orderList", (data) =>
            {
                gui.initialOrdersView((string)data);
            });

            socket.On("acceptOrder", (data) =>
            {
                gui.addOrderView((string) data);

            });

            socket.On("booksList", ( data) =>
            {
                gui.showInitialBooks((JObject) data);
            });
        }
    }
}
