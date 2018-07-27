using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeTests
{
    public class IntLengthComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (Math.Log10(x) == Math.Log10(y))
            {
                return 0;
            }

            if (Math.Log10(x) > Math.Log10(y))
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
