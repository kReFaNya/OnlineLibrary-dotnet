using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Core
{
    public class BookFileService
    {
        public void SaveToJson(List<Book> books, string filePath)
        {
            string json = JsonConvert.SerializeObject(books, Formatting.Indented);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(json);
            }
        }

        public List<Book> LoadFromJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("JSON file does not exist.");
                return new List<Book>();
            }

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string json = reader.ReadToEnd();

                    List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);

                    if (books == null)
                    {
                        return new List<Book>();
                    }

                    return books;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while reading JSON: " + ex.Message);
                return new List<Book>();
            }
        }

        public void ExportAvailableBooksToXml(List<Book> books, string filePath)
        {
            var availableBooks = books
                .Where(book => book.IsAvailable)
                .Select(book =>
                    new XElement("Book",
                        new XAttribute("Id", book.Id),
                        new XElement("Title", book.Title),
                        new XElement("Pages", book.Pages),
                        new XElement("Rating", book.Rating),
                        new XElement("Category", book.Category),
                        new XElement("ReleaseDate", book.ReleaseDate.ToShortDateString())
                    )
                );

            XDocument document = new XDocument(
                new XElement("AvailableBooks", availableBooks)
            );

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                document.Save(stream);
            }
        }
    }
}
