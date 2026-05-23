using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core
{
    public static class StringExtensions
    {
        public static int WordCount(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return 0;
            }

            return text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
