using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeTests
{
    public class BookComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x.name.Length == y.name.Length)
            {
                return 0;
            }

            if (x.name.Length > y.name.Length)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
