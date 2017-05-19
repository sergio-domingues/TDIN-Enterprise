using Common;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse
{
    public partial class WarehouseGUI : Form
    {
        protected WarehouseCommunicationHandler warehouseHandler;

        public WarehouseGUI(WarehouseCommunicationHandler warehouseHandler)
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
