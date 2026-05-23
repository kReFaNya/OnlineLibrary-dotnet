using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public double Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsAvailable { get; set; }
        public string Category { get; set; }

        public Book(int id, string title, int pages, double rating, DateTime releaseDate, bool isAvailable, string category)
        {
            Id = id;
            Title = title;
            Pages = pages;
            Rating = rating;
            ReleaseDate = releaseDate;
            IsAvailable = isAvailable;
            Category = category;
        }
    }
}
