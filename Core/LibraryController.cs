using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class LibraryController
    {
        private LibraryConfiguration configuration;

        public LibraryController()
        {
            configuration = new LibraryConfiguration();
        }

        public void ShowConfiguration()
        {
            Console.WriteLine($"Library name: {configuration.LibraryName}");
            Console.WriteLine($"Max books per user: {configuration.MaxBooksPerUser}");
        }
    }
}
