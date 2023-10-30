using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disaheim
{
    public class BookRepository
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }
        public Book GetBook(string itemId)
        {
            Book book = null;
            foreach (Book b in books)
            {
                if (b.ItemId == itemId)
                {
                    book = b;
                    break;
                }
            }
            return book;
        }
        public double GetTotalValue()
        {
            Utility utility = new();
            double total = 0.00;
            foreach (Book b in books)
            {
                total += utility.GetValueOfBook(b);
            }
            return total;
        }

    }
}
