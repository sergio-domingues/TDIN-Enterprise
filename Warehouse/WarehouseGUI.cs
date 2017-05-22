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
                                 
            ShipOrderMessage msg = new ShipOrderMessage()
            {                
                clientName = order.SubItems[0].Text,
                bookTitle = order.SubItems[1].Text,
                qtd = int.Parse(order.SubItems[2].Text),
                id = order.SubItems[4].Text
            };

            //todo WAREHOUSE DB UPDATE ORDER STATUS

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
                        
            //to test -- comment when data received from db
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
            Console.WriteLine(">>>>>>>>", data);

            Order order = JsonConvert.DeserializeObject<Order>(data);
            
            ordersListView.BeginInvoke((Action)(() =>
            {
                ListViewItem lvItem = new ListViewItem(order.clientName);
                lvItem.SubItems.Add(order.bookTitle);
                lvItem.SubItems.Add(order.quantity.ToString());
                lvItem.SubItems.Add(order.status);
                lvItem.SubItems.Add(order.id);

                ordersListView.Items.Add(lvItem);
            }));
        }            
    }
}
