using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class User
    {
        public string Username { get; set; }
        public int BooksReserved { get; set; }
        public double Balance { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsPremium { get; set; }
    }
}
