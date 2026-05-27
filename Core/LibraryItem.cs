using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class LibraryItem : IShow
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsAvailable { get; set; }

        protected LibraryItem()
        {
        }

        protected LibraryItem(int id, string title, DateTime releaseDate, bool isAvailable)
        {
            Id = id;
            Title = title;
            ReleaseDate = releaseDate;
            IsAvailable = isAvailable;
        }

        public virtual void ShowShortInfo()
        {
            Console.WriteLine($"ID: {Id}, Title: {Title}, Available: {IsAvailable}");
        }

        public abstract void ShowInfo();

        public abstract string GetItemType();
    }
}
