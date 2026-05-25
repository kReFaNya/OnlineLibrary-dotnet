using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" COMPOSITION ");

            LibraryController controller = new LibraryController();
            controller.ShowConfiguration();

            Console.WriteLine();

            Console.WriteLine(" AGGREGATION ");

            Book book1 = new Book(1, "The Witcher", 320, 9.4, new DateTime(2015, 5, 19), true, "Fantasy");
            Book book2 = new Book(2, "Dune", 500, 9.7, new DateTime(1976, 8, 1), false, "Science Fiction");

            Magazine magazine1 = new Magazine(3, "National Geographic", new DateTime(2022, 4, 10), true, 120, "National Geographic Partners");
            Magazine magazine2 = new Magazine(4, "Science Today", new DateTime(2023, 9, 15), true, 45, "Science Publishing");

            LibraryStorage storage = new LibraryStorage();

            storage.AddItem(book1);
            storage.AddItem(book2);
            storage.AddItem(magazine1);
            storage.AddItem(magazine2);

            Console.WriteLine("Items in storage:");

            foreach (LibraryItem item in storage)
            {
                item.ShowShortInfo();
            }

            Console.WriteLine();

            Console.WriteLine(" DICTIONARY SEARCH ");

            LibraryItem foundItem = storage.FindItemById(3);

            if (foundItem != null)
            {
                Console.WriteLine("Found item:");
                foundItem.ShowInfo();
            }
            else
            {
                Console.WriteLine("Item not found");
            }

            Console.WriteLine();

            Console.WriteLine(" POLYMORPHISM ");

            IShow[] showItems = new IShow[]
            {
                book1,
                book2,
                magazine1,
                magazine2
            };

            foreach (IShow showItem in showItems)
            {
                showItem.ShowInfo();
            }

            Console.WriteLine();

            Console.WriteLine(" AVAILABLE ITEMS ");

            foreach (LibraryItem item in storage.GetAvailableItems())
            {
                Console.WriteLine($"{item.GetItemType()}: {item.Title}");
            }

            Console.ReadKey();
        }
    }
}
