using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Common
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

        abstract public string getJSON();
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

        override public string getJSON()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            Console.WriteLine(JsonConvert.SerializeObject(this, Formatting.Indented));

            return json;
        }

    }

    [Serializable]
    public class OrderMessage : Message
    {
        public string address, emailAddress, id;

        public OrderMessage() : base() { }

        public OrderMessage(string bookTitle, string clientName, int quantity, string address, string emailAddress, string id) : base(bookTitle, clientName, quantity)
        {
            this.address = address;
            this.emailAddress = emailAddress;
            this.id = id;
        }

        override public string getJSON()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            Console.WriteLine(JsonConvert.SerializeObject(this, Formatting.Indented));

            return json;
        }
    }

    [Serializable]
    public class ShipOrderMessage
    {
        public string id;
        public int qtd;

        public ShipOrderMessage() { }

        public string getJSON()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            Console.WriteLine(JsonConvert.SerializeObject(this, Formatting.Indented));

            return json;
        }
    }

}
