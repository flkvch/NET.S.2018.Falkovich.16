using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeTests
{
    public class Book : IComparable<Book>
    {
        private string name;
        private string author;
        private int pages;

        public Book(string author, string name, int pages)
        {
            this.name = name;
            this.author = author;
            this.pages = pages;
        }

        public override bool Equals(object other)
        {
            if (other == null)
            {
                return false;
            }

            return name == (other as Book).name && author == (other as Book).author && pages == (other as Book).pages;
        }

        public int CompareTo(Book other)
        {
            if (other is null)
            {
                return 1;
            }

            if (pages == other.pages)
            {
                return 0;
            }

            if (pages > other.pages)
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
