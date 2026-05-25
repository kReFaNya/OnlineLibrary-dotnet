using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Book : LibraryItem
    {
        public int Pages { get; set; }
        public double Rating { get; set; }
        public string Category { get; set; }

        public Book(int id, string title, int pages, double rating, DateTime releaseDate, bool isAvailable, string category)
            : base(id, title, releaseDate, isAvailable)
        {
            Pages = pages;
            Rating = rating;
            Category = category;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Book: {Title}, Pages: {Pages}, Rating: {Rating}, Category: {Category}");
        }

        public override string GetItemType()
        {
            return "Book";
        }
    }
}
