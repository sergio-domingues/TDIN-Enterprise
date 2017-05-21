using Common;
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
        }
    }
}
