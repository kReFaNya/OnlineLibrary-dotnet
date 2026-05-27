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
            string jsonPath = "books.json";
            string xmlPath = "available_books.xml";
            string logPath = "log.txt";

            List<Book> books = new List<Book>
            {
                new Book(1, "The Witcher", 320, 9.4, new DateTime(2015, 5, 19), true, "Fantasy"),
                new Book(2, "Dune", 500, 9.7, new DateTime(1976, 8, 1), false, "Science Fiction"),
                new Book(3, "The Hobbit", 310, 9.5, new DateTime(1967, 9, 21), true, "Fantasy"),
                new Book(4, "Dracula", 350, 8.2, new DateTime(1869, 5, 26), false, "Horror"),
                new Book(5, "Foundation", 410, 9.0, new DateTime(1951, 1, 1), true, "Science Fiction")
            };

            BookFileService fileService = new BookFileService();

            using (ResourceManager resourceManager = new ResourceManager(logPath))
            {
                Console.WriteLine(" JSON SERIALIZATION ");

                fileService.SaveToJson(books, jsonPath);
                resourceManager.WriteLog("Books saved to JSON file.");

                Console.WriteLine("Books saved to JSON file.");

                Console.WriteLine();

                Console.WriteLine(" JSON DESERIALIZATION ");

                List<Book> loadedBooks = fileService.LoadFromJson(jsonPath);
                resourceManager.WriteLog("Books loaded from JSON file.");

                foreach (Book book in loadedBooks)
                {
                    Console.WriteLine(book.Id + ". " + book.Title + " - " + book.Category + " - Available: " + book.IsAvailable);
                }

                Console.WriteLine();

                Console.WriteLine(" XML EXPORT ");

                fileService.ExportAvailableBooksToXml(loadedBooks, xmlPath);
                resourceManager.WriteLog("Available books exported to XML file.");

                Console.WriteLine("Available books exported to XML file.");

                Console.WriteLine();

                Console.WriteLine(" FILE VALIDATION ");

                List<Book> missingBooks = fileService.LoadFromJson("missing_file.json");

                Console.WriteLine("Loaded books from missing file: " + missingBooks.Count);

                resourceManager.WriteLog("File validation completed.");
            }

            Console.WriteLine();

            Console.WriteLine("ResourceManager disposed automatically by using block.");

            Console.ReadKey();
        }
    }
}
