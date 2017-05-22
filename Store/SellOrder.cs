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
    public partial class SellOrder : Form
    {
        ListViewItem book;
        public StoreCommunicationHandler commHandler;
        public SellOrder(ListViewItem book)
        {
            this.book = book;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SellMessage msg = new SellMessage()
            {
                bookTitle = book.SubItems[0].Text,
                clientName = textBox1.Text,
                quantity = (int)numericUpDown1.Value > int.Parse(book.SubItems[1].Text) ? int.Parse(book.SubItems[1].Text) : (int)numericUpDown1.Value,                   
                totalPrice = (int)numericUpDown1.Value * int.Parse(book.SubItems[2].Text)
            };

            commHandler.sendMsg("sell", msg.getJSON());
            Hide();
        }

        private void SellOrder_Load(object sender, EventArgs e)
        {
            label1.Text = book.SubItems[0].Text;
        }
    }
}
