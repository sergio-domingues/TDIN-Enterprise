using Common;
using Store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Book_Enterprise
{
    public partial class OrderCliForm : Form
    {
        string bookTitle;
        public StoreCommunicationHandler commHandler { get; set; }

        public OrderCliForm(string bookTitle)
        {
            this.bookTitle = bookTitle;
            InitializeComponent();
        }

        private void OrderCliForm_Load(object sender, EventArgs e)
        {
            bookLabel.Text = bookTitle;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            OrderMessage msg = new OrderMessage()
            {
                bookTitle = bookTitle,
                clientName = nameTextBox.Text,
                quantity = (int)numericUpDown1.Value + 10,
                address = addressTextBox.Text,
                emailAddress = emailTextBox.Text,
                id = Guid.NewGuid().ToString(),
                status = "Your order is waiting expedition due to the lack of stock, we ask you to be patient"
            };

            commHandler.sendMsg("order", msg.getJSON());
            Hide();
        }
    }
}
