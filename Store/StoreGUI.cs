using Common;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
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

        public ArrayList acceptOrdersList { get; set; }

        public StoreGUI(StoreCommunicationHandler handler)
        {
            commHandler = handler;
            commHandler.gui = this;
            InitializeComponent();
        }

        private void StoreGUI_Load(object sender, EventArgs e)
        {
            commHandler.sendMsg("getOrders", "");
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
            // TODO
            //update stock
            //update order
            //send email

            ListViewItem order;

            try
            {
                order = ordersListView.SelectedItems[0];
            }
            catch (Exception exception)
            {
                return;
            }

            ordersListView.BeginInvoke((Action)(() =>
            {
                ordersListView.SelectedItems[0].Remove();
            }));
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

        
        public void initialOrdersView(string data)
        {
            //to test
            data = @"[{ bookTitle : 'bookTitle', " +
                "clientName : 'clientName', " +
                "quantity : 15, " +
                "address : 'address', " +
                "emailAddress : 'emailAddress', " +
                "id : 'id'," +
                "status : 'status'}]";

            acceptOrdersList = new ArrayList(JsonConvert.DeserializeObject<List<Order>>(data));

            ordersListView.BeginInvoke((Action)(() =>
            {
                foreach (Order order in acceptOrdersList)
                {
                    ListViewItem lvItem = new ListViewItem(order.bookTitle);
                    lvItem.SubItems.Add(order.quantity.ToString());
                    lvItem.SubItems.Add(order.id.ToString());

                    ordersListView.Items.Add(lvItem);
                }
            }));
        }

        public void addOrderView(string data)
        {
            //todo use data param

            ordersListView.BeginInvoke((Action)(() =>
            {
                ListViewItem lvItem = new ListViewItem("bookTitle");
                lvItem.SubItems.Add(13.ToString());
                lvItem.SubItems.Add("id2");

                ordersListView.Items.Add(lvItem);
            }));
        }

    }
}
