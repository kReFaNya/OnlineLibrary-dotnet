using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class LibraryConfiguration
    {
        public string LibraryName { get; set; }
        public int MaxBooksPerUser { get; set; }

        public LibraryConfiguration()
        {
            LibraryName = "Online Library";
            MaxBooksPerUser = 5;
        }
    }
}
