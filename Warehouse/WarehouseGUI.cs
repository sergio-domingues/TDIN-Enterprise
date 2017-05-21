using Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Warehouse
{    
    public partial class warehouseGUI : Form
    {
        public WarehouseCommunicationHandler warehouseHandler;
        public ArrayList orderList { get; set; }

        public warehouseGUI(WarehouseCommunicationHandler warehouseHandler)
        {            
            this.warehouseHandler = warehouseHandler;
            warehouseHandler.gui = this;
            InitializeComponent();
        }

        private void shipButton_Click(object sender, EventArgs e)
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

            //Console.WriteLine("order:  ", order);
                     
            ShipOrderMessage msg = new ShipOrderMessage()
            {
                id = order.SubItems[4].Text,
                qtd = int.Parse(order.SubItems[2].Text)
            };

            warehouseHandler.sendMsg("shipping", msg.getJSON());


            ordersListView.BeginInvoke((Action)(() =>
            {
                ordersListView.SelectedItems[0].Remove();
            }));
        }

        private void warehouseGUI_Load(object sender, EventArgs e)
        {            
            warehouseHandler.sendMsg("getOrders", "");
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

            orderList = new ArrayList(JsonConvert.DeserializeObject<List<Order>>(data));                       

            ordersListView.BeginInvoke((Action)(() =>
            {
                foreach (Order order in orderList)
                {
                    ListViewItem lvItem = new ListViewItem(order.clientName);
                    lvItem.SubItems.Add(order.bookTitle);
                    lvItem.SubItems.Add(order.quantity.ToString());
                    lvItem.SubItems.Add(order.status);
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
                ListViewItem lvItem = new ListViewItem("cliente");
                lvItem.SubItems.Add("bookTitle");
                lvItem.SubItems.Add(13.ToString());
                lvItem.SubItems.Add("status");
                lvItem.SubItems.Add("id2");

                ordersListView.Items.Add(lvItem);
            }));
        }            
    }
}
