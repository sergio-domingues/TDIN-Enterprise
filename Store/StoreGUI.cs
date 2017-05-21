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

namespace Store
{
    public partial class StoreGUI : Form
    {
        protected StoreCommunicationHandler commHandler;

        public StoreGUI(StoreCommunicationHandler handler)
        {
            commHandler = handler;            
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void sellButton_Click(object sender, EventArgs e)
        {
            //TODO get item clicked

            SellMessage msg = new SellMessage()
            {
                bookTitle = "titulo",
                clientName = "nome",
                quantity = 5,
                totalPrice = 15
            };

            commHandler.sendMsg("sell", msg.getJSON());
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            //TODO get item clicked

            OrderMessage msg = new OrderMessage()
            {
                bookTitle = "titulo",
                clientName = "nome",
                quantity = 5,
                address = "address",
                emailAddress = "emailaddress",
                id = Guid.NewGuid().ToString()
            };

            commHandler.sendMsg("order", msg.getJSON());
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            //TODO 
        }
    }
}
