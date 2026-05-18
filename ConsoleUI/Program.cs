using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" SYSTEM INFORMATION ");

            Console.WriteLine("Operating System: " + Environment.OSVersion);

            long memory = GC.GetTotalMemory(false);

            Console.WriteLine("Used Memory: " + memory + " bytes");

            Console.WriteLine();

            // Book object
            Book book = new Book
            {
                Title = "The Witcher",
                Pages = 320,
                Rating = 9.4,
                ReleaseDate = new DateTime(2015, 5, 19),
                IsAvailable = true
            };

            // Author object
            Author author = new Author
            {
                FullName = "Andrzej Sapkowski",
                Age = 76,
                Salary = 15000.50,
                BirthDate = new DateTime(1948, 6, 21),
                IsAlive = true
            };

            // User object
            User user = new User
            {
                Username = "kReaGeN",
                BooksReserved = 2,
                Balance = 120.75,
                RegistrationDate = DateTime.Now,
                IsPremium = true
            };

            Console.WriteLine(" BOOK ");
            Console.WriteLine($"Title: {book.Title}");
            Console.WriteLine($"Pages: {book.Pages}");
            Console.WriteLine($"Rating: {book.Rating}");
            Console.WriteLine($"Release Date: {book.ReleaseDate}");
            Console.WriteLine($"Available: {book.IsAvailable}");

            Console.WriteLine();

            Console.WriteLine(" AUTHOR ");
            Console.WriteLine($"Full Name: {author.FullName}");
            Console.WriteLine($"Age: {author.Age}");
            Console.WriteLine($"Salary: {author.Salary}");
            Console.WriteLine($"Birth Date: {author.BirthDate}");
            Console.WriteLine($"Alive: {author.IsAlive}");

            Console.WriteLine();

            Console.WriteLine(" USER ");
            Console.WriteLine($"Username: {user.Username}");
            Console.WriteLine($"Books Reserved: {user.BooksReserved}");
            Console.WriteLine($"Balance: {user.Balance}");
            Console.WriteLine($"Registration Date: {user.RegistrationDate}");
            Console.WriteLine($"Premium: {user.IsPremium}");

            Console.ReadKey();
        }
    }
}
