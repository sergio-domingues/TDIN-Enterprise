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
            ListViewItem book;

            try
            {
                book = listView1.SelectedItems[0];
            }
            catch (Exception exception)
            {
                return;
            }


            SellMessage msg = new SellMessage()
            {
                bookTitle = book.SubItems[0].Text,
                clientName = "TODO NOME DA TEXTBOX",
                //todo ir buscar quantidade
                quantity = 10,
                /* TODO usar qtd para calcular totalprice */
                totalPrice = 10 * int.Parse(book.SubItems[2].Text)
            };

            commHandler.sendMsg("sell", msg.getJSON());
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            ListViewItem book;

            try
            {
                book = listView1.SelectedItems[0];
            }
            catch (Exception exception)
            {
                return;
            }

            OrderMessage msg = new OrderMessage()
            {
                bookTitle = book.SubItems[0].Text,
                clientName = "TODO NOME DA TEXTBOX",
                //todo ir buscar quantidade e enviar com + 10
                quantity = 10,             
                address = "TODO",
                emailAddress = "TODO",
                id = Guid.NewGuid().ToString(),
                status = "waiting expedition"
            };

            commHandler.sendMsg("order", msg.getJSON());
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {            
            ListViewItem order;

            try
            {
                order = ordersListView.SelectedItems[0];
            }
            catch (Exception exception)
            {
                return;
            }

            // TODO (check tasks done below)
            //update stock [ ]
            //update order [X]
            //send email   [ ]

            //  order.SubItems
            //updt book stock GUI  there is a method ehre for this
            
            ListViewItem book = listView1.FindItemWithText(order.Name);
            
            ShipOrderMessage msg = new ShipOrderMessage()
            {
                bookTitle = order.SubItems[0].Text,
                qtd = int.Parse(order.SubItems[1].Text),
                id = order.SubItems[2].Text
            };

            commHandler.sendMsg("checkStockOrders", msg.getJSON());

            ordersListView.BeginInvoke((Action)(() =>
            {
                ordersListView.SelectedItems[0].Remove();
            }));
        }

        public void updateBookStock(JObject json)
        {
            listView1.BeginInvoke((Action)(() =>
                {
                    listView1.FindItemWithText(json["title"].ToString()).SubItems[1].Text = json["stock"].ToString();
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
            //to test  COMMENT AFTER DB DATA
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
            Console.WriteLine(">>>>>>>>", data);

            JObject shipOrder = JObject.Parse(data);


            ordersListView.BeginInvoke((Action)(() =>
            {
                ListViewItem lvItem = new ListViewItem(shipOrder["bookTitle"].ToString());
                lvItem.SubItems.Add(shipOrder["qtd"].ToString());
                lvItem.SubItems.Add(shipOrder["id"].ToString());

                ordersListView.Items.Add(lvItem);
            }));
        }

    }
}
