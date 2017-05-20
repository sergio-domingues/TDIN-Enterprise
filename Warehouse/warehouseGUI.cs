using Common;

using System;
using System.Windows.Forms;

namespace Warehouse
{
    public partial class warehouseGUI : Form
    {
        protected WarehouseCommunicationHandler warehouseHandler;

        public warehouseGUI(WarehouseCommunicationHandler warehouseHandler)
        {
            this.warehouseHandler = warehouseHandler;
            InitializeComponent();
        }

        private void shipButton_Click(object sender, EventArgs e)
        {
            //todo get item selected

            // FOR TESTING
            ShipOrderMessage msg = new ShipOrderMessage()
            {
                id = Guid.NewGuid(),
                qtd = 10 + 25
            };

            warehouseHandler.sendMsg("shipping", msg.getJSON());
        }
    }
}
