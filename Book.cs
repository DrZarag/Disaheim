using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Disaheim
{
    public class Book : Merchandise

    {
        public string Title;
        public double Price;
        public Book()
        {

        }

        public Book(string itemId)
        {
            ItemId = itemId;
        }
        public Book(string itemId, string title) : this(itemId)
        {
            this.ItemId = itemId;
            this.Title = title;
        }
        public Book(string itemId, string title, double price) : this(itemId, title)
        {
            this.ItemId = itemId;
            this.Title = title;
            this.Price = price;
        }

        public override double GetValue()
        {
            return Price;
        }
        public override string ToString()
        {
            return $"Book;{ItemId};{Title};{Price}";
        }

    }
}