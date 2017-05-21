using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Order
    {
        public string bookTitle, clientName, address, emailAddress, status, id;
        public int quantity;

        public Order(string bookTitle, string clientName, int quantity, string address, string emailAddress, string status, string id)
        {
            this.bookTitle = bookTitle;
            this.clientName = clientName;
            this.quantity = quantity;
            this.address = address;
            this.emailAddress = emailAddress;
            this.id = id;
            this.status = status;
        }
        
        public string[] getOrderAttrs ()
        {
            return new string[] { bookTitle, clientName, quantity.ToString(), address, emailAddress, id.ToString(), status };
        }

    }
}
