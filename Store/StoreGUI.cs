using Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
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
        private ArrayList booksList { get; set; }

        public StoreGUI(StoreCommunicationHandler handler)
        {
            commHandler = handler;
            commHandler.gui = this;
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

        public void showInitialBooks(JObject books)
        {
            var booksArray = (JArray) books["data"];

            booksList = new ArrayList(JsonConvert.DeserializeObject<List<Book>>(booksArray.ToString()));

            ordersListView.BeginInvoke((Action)(() =>
            {
                foreach (Book book in booksList)
                {
                    ListViewItem lvItem = new ListViewItem(book.Title);
                    lvItem.SubItems.Add(book.Stock.ToString());
                    lvItem.SubItems.Add(book.Price.ToString());

                    listView1.Items.Add(lvItem);
                }
            }));
        }

        
    }
}
