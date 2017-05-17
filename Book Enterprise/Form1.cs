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
    public partial class Form1 : Form
    {
        protected CommunicationHandler commHandler;

        public Form1(CommunicationHandler handler)
        {
            commHandler = handler;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            commHandler.sendMsg();
        }
    }
}
