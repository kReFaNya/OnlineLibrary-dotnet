using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void Book_ShouldSaveCorrectTitle()
        {
            // Arrange
            Book book = new Book(1, "Dune", 500, 9.7, new DateTime(1976, 8, 1), true, "Science Fiction");

            // Act
            string title = book.Title;

            // Assert
            Assert.AreEqual("Dune", title);
        }

        [TestMethod]
        public void Book_RatingShouldBeGreaterThanNine()
        {
            // Arrange
            Book book = new Book(1, "The Witcher", 320, 9.4, DateTime.Now, true, "Fantasy");

            // Act
            bool result = book.Rating > 9.0;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Linq_ShouldFilterAvailableBooks()
        {
            // Arrange
            List<Book> books = new List<Book>
            {
                new Book(1, "Book A", 100, 8.0, DateTime.Now, true, "Fantasy"),
                new Book(2, "Book B", 200, 9.0, DateTime.Now, false, "Horror"),
                new Book(3, "Book C", 300, 9.5, DateTime.Now, true, "Drama")
            };

            // Act
            List<Book> availableBooks = books
                .Where(book => book.IsAvailable)
                .ToList();

            // Assert
            Assert.AreEqual(2, availableBooks.Count);
        }

        [TestMethod]
        public void Linq_ShouldFindHighRatedBooks()
        {
            // Arrange
            List<Book> books = new List<Book>
            {
                new Book(1, "Book A", 100, 8.0, DateTime.Now, true, "Fantasy"),
                new Book(2, "Book B", 200, 9.8, DateTime.Now, true, "Horror"),
                new Book(3, "Book C", 300, 9.6, DateTime.Now, true, "Drama")
            };

            // Act
            List<Book> highRatedBooks = books
                .Where(book => book.Rating > 9.5)
                .ToList();

            // Assert
            Assert.AreEqual(2, highRatedBooks.Count);
        }

        [TestMethod]
        public void Book_CategoryShouldNotBeEmpty()
        {
            // Arrange
            Book book = new Book(1, "Metro 2033", 400, 8.9, DateTime.Now, true, "Post-apocalyptic");

            // Act
            bool result = !string.IsNullOrWhiteSpace(book.Category);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
