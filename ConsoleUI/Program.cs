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
            Console.WriteLine(" EXTENSION METHOD ");

            string description = "Online library contains books authors and users";
            int wordCount = description.WordCount();

            Console.WriteLine($"Text: {description}");
            Console.WriteLine($"Word count: {wordCount}");

            Console.WriteLine();

            LibraryStorage storage = new LibraryStorage();

            storage.AddBook(new Book(1, "The Witcher", 320, 9.4, new DateTime(2015, 5, 19), true, "Fantasy"));
            storage.AddBook(new Book(2, "Metro 2033", 400, 8.9, new DateTime(2005, 3, 16), true, "Post-apocalyptic"));
            storage.AddBook(new Book(3, "Dune", 500, 9.7, new DateTime(1976, 8, 1), false, "Science Fiction"));
            storage.AddBook(new Book(4, "1984", 280, 9.1, new DateTime(1984, 6, 8), true, "Dystopia"));
            storage.AddBook(new Book(5, "The Hobbit", 310, 9.5, new DateTime(1967, 9, 21), true, "Fantasy"));
            storage.AddBook(new Book(6, "Dracula", 350, 8.2, new DateTime(1869, 5, 26), false, "Horror"));
            storage.AddBook(new Book(7, "Fahrenheit 451", 290, 8.8, new DateTime(1956, 10, 19), true, "Dystopia"));
            storage.AddBook(new Book(8, "Foundation", 410, 9.0, new DateTime(1951, 1, 1), true, "Science Fiction"));
            storage.AddBook(new Book(9, "Neuromancer", 330, 8.7, new DateTime(1989, 7, 1), false, "Cyberpunk"));
            storage.AddBook(new Book(10, "It", 620, 9.3, new DateTime(1991, 9, 15), true, "Horror"));

            Console.WriteLine(" FOREACH STORAGE ");
            Console.WriteLine($"{"ID",-5} {"Title",-20} {"Rating",-10} {"Category"}");

            foreach (Book book in storage)
            {
                Console.WriteLine($"{book.Id,-5} {book.Title,-20} {book.Rating,-10} {book.Category}");
            }

            Console.WriteLine();

            Console.WriteLine(" DICTIONARY SEARCH ");

            Book foundBook = storage.FindBookById(3);

            if (foundBook != null)
            {
                Console.WriteLine($"Book found by ID: {foundBook.Title}, rating: {foundBook.Rating}");
            }
            else
            {
                Console.WriteLine("Book not found");
            }

            Console.WriteLine();

            Console.WriteLine(" LINQ FOR DICTIONARY ");
            Console.WriteLine($"{"Title",-20} {"Rating",-10} {"Category"}");

            List<Book> highRatedBooks = storage.GetHighRatedBooksFromDictionary(9.3);

            foreach (Book book in highRatedBooks)
            {
                Console.WriteLine($"{book.Title,-20} {book.Rating,-10} {book.Category}");
            }

            Console.WriteLine();

            Console.WriteLine(" HASHSET ");

            HashSet<string> categories = new HashSet<string>();

            categories.Add("Fantasy");
            categories.Add("Horror");
            categories.Add("Science Fiction");
            categories.Add("Fantasy");

            Console.WriteLine("Categories after adding duplicate Fantasy:");

            foreach (string category in categories)
            {
                Console.WriteLine(category);
            }

            Console.WriteLine();

            HashSet<string> firstReaderCategories = new HashSet<string>
            {
                "Fantasy",
                "Horror",
                "Dystopia"
            };

            HashSet<string> secondReaderCategories = new HashSet<string>
            {
                "Fantasy",
                "Science Fiction",
                "Dystopia"
            };

            firstReaderCategories.IntersectWith(secondReaderCategories);

            Console.WriteLine("Common categories:");

            foreach (string category in firstReaderCategories)
            {
                Console.WriteLine(category);
            }

            Console.ReadKey();
        }
    }
}
