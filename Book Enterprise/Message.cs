using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Book_Enterprise
{
    [Serializable]
    public abstract class Message
    {
        public string bookTitle, clientName;
        public int quantity;

        public Message(string bookTitle, string clientName, int quantity)
        {
            this.bookTitle = bookTitle;
            this.clientName = clientName;
            this.quantity = quantity;
        }

        public Message() { }
    }

    [Serializable]
    public class SellMessage : Message
    {
        public int totalPrice;

        public SellMessage() : base() {}

        public SellMessage(string bookTitle, string clientName, int quantity, int totalPrice) : base(bookTitle, clientName, quantity)
        {
            this.totalPrice = totalPrice;
        }

        public string getJSON()
        {
            //todo
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            Console.WriteLine(JsonConvert.SerializeObject(this, Formatting.Indented));

            return json;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }

    [Serializable]
    public class OrderMessage : Message
    {
        public string address, emailAddress;
        public Guid id;

        public OrderMessage() : base() { }

        public OrderMessage(string bookTitle, string clientName, int quantity, string address, string emailAddress, Guid id) : base(bookTitle, clientName, quantity)
        {
            this.address = address;
            this.emailAddress = emailAddress;
            this.id = id;
        }

        public string getJSON()
        {
            //todo
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            Console.WriteLine(JsonConvert.SerializeObject(this, Formatting.Indented));

            return json;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }

}
