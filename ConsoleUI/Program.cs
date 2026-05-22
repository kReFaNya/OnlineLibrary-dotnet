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
            Console.WriteLine(" STRUCT TEST ");

            Price price = new Price(100, "USD");

            Console.WriteLine($"Before method: {price.Amount} {price.Currency}");
            ChangePrice(price);
            Console.WriteLine($"After method:  {price.Amount} {price.Currency}");

            Console.WriteLine("\n BOXING / UNBOXING ");

            object boxedNumber = 10;
            int unboxedNumber = (int)boxedNumber;

            Console.WriteLine($"Boxed value: {boxedNumber}");
            Console.WriteLine($"Unboxed value: {unboxedNumber}");

            Stopwatch stopwatch = new Stopwatch();

            ArrayList arrayList = new ArrayList();

            stopwatch.Start();
            for (int i = 0; i < 1000000; i++)
            {
                arrayList.Add(i);
            }
            stopwatch.Stop();

            long arrayListTime = stopwatch.ElapsedMilliseconds;

            List<int> intList = new List<int>();

            stopwatch.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                intList.Add(i);
            }
            stopwatch.Stop();

            long listTime = stopwatch.ElapsedMilliseconds;

            Console.WriteLine($"ArrayList time: {arrayListTime} ms");
            Console.WriteLine($"List<int> time: {listTime} ms");
            Console.WriteLine($"Difference: {arrayListTime - listTime} ms");

            Console.WriteLine("\n BOOK COLLECTION ");

            List<Book> books = new List<Book>
            {
                new Book("The Witcher", 320, 9.4, new DateTime(2015, 5, 19), true),
                new Book("Metro 2033", 400, 8.9, new DateTime(2005, 3, 16), true),
                new Book("Dune", 500, 9.7, new DateTime(1976, 8, 1), false),
                new Book("1984", 280, 9.1, new DateTime(1984, 6, 8), true),
                new Book("The Hobbit", 310, 9.5, new DateTime(1967, 9, 21), true),
                new Book("Dracula", 350, 8.2, new DateTime(1869, 5, 26), false),
                new Book("Fahrenheit 451", 290, 8.8, new DateTime(1956, 10, 19), true),
                new Book("Foundation", 410, 9.0, new DateTime(1951, 1, 1), true),
                new Book("Neuromancer", 330, 8.7, new DateTime(1989, 7, 1), false),
                new Book("It", 620, 9.3, new DateTime(1991, 9, 15), true)
            };

            Console.WriteLine("\n WHERE: Rating > 9.0 ");
            Console.WriteLine($"{"Title",-20} {"Rating",-10} {"Available"}");

            var highRatedBooks = books.Where(book => book.Rating > 9.0);

            foreach (var book in highRatedBooks)
            {
                Console.WriteLine($"{book.Title,-20} {book.Rating,-10} {book.IsAvailable}");
            }

            Console.WriteLine("\n ORDER BY: Pages, Title ");
            Console.WriteLine($"{"Title",-20} {"Pages",-10} {"Rating"}");

            var sortedBooks = books
                .OrderBy(book => book.Pages)
                .ThenBy(book => book.Title);

            foreach (var book in sortedBooks)
            {
                Console.WriteLine($"{book.Title,-20} {book.Pages,-10} {book.Rating}");
            }

            Console.WriteLine("\n SELECT: Titles ");

            var bookTitles = books.Select(book => book.Title);

            foreach (var title in bookTitles)
            {
                Console.WriteLine(title);
            }

            Console.WriteLine("\n FIRST OR DEFAULT ");

            var foundBook = books.FirstOrDefault(book => book.Title == "Dune");

            if (foundBook != null)
            {
                Console.WriteLine($"Book found: {foundBook.Title}, rating: {foundBook.Rating}");
            }
            else
            {
                Console.WriteLine("Book not found");
            }

            Console.ReadKey();
        }

        static void ChangePrice(Price price)
        {
            price.Amount = 999;
            price.Currency = "EUR";

            Console.WriteLine($"Inside method: {price.Amount} {price.Currency}");
        }
    }
}