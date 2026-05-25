using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Magazine : LibraryItem
    {
        public int IssueNumber { get; set; }
        public string Publisher { get; set; }

        public Magazine(int id, string title, DateTime releaseDate, bool isAvailable, int issueNumber, string publisher)
            : base(id, title, releaseDate, isAvailable)
        {
            IssueNumber = issueNumber;
            Publisher = publisher;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Magazine: {Title}, Issue: {IssueNumber}, Publisher: {Publisher}");
        }

        public override string GetItemType()
        {
            return "Magazine";
        }
    }
}
