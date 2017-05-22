using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Order
    {
        public string BookTitle, ClientName, Address, Email, State, OrderId;
        public int Quantity;

        public Order(string bookTitle, string clientName, int quantity, string address, string emailAddress, string status, string id)
        {
            this.BookTitle = bookTitle;
            this.ClientName = clientName;
            this.Quantity = quantity;
            this.Address = address;
            this.Email = emailAddress;
            this.OrderId = id;
            this.State = status;
        }
        
        public string[] getOrderAttrs ()
        {
            return new string[] { BookTitle, ClientName, Quantity.ToString(), Address, Email, OrderId.ToString(), State };
        }

    }
}
