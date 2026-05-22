using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Book
    {
        public string Title { get; set; }
        public int Pages { get; set; }
        public double Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsAvailable { get; set; }

        public Book(string title, int pages, double rating, DateTime releaseDate, bool isAvailable)
        {
            Title = title;
            Pages = pages;
            Rating = rating;
            ReleaseDate = releaseDate;
            IsAvailable = isAvailable;
        }
    }
}
