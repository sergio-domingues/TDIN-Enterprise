using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Book
    {
        public string Title, BookId, Image;
        public int Stock, Price;

        public Book(string bookTitle, int price, int quantity, string id, string image)
        {
            this.Title = bookTitle;
            this.Stock = quantity;
            this.Price = price;
            this.BookId = id;
            this.Image = image;
        }

        
    }
}
