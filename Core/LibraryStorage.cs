using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class LibraryStorage
    {
        private List<Book> books = new List<Book>();
        private Dictionary<int, Book> booksById = new Dictionary<int, Book>();

        public void AddBook(Book book)
        {
            books.Add(book);

            if (!booksById.ContainsKey(book.Id))
            {
                booksById.Add(book.Id, book);
            }
        }

        public Book FindBookById(int id)
        {
            if (booksById.ContainsKey(id))
            {
                return booksById[id];
            }

            return null;
        }

        public List<Book> GetHighRatedBooksFromDictionary(double minRating)
        {
            return booksById
                .Where(pair => pair.Value.Rating >= minRating)
                .Select(pair => pair.Value)
                .ToList();
        }

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (Book book in books)
            {
                yield return book;
            }
        }
    }
}
