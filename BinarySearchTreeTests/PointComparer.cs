using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeTests
{
    public class PointComparer : IComparer<Point>
    {
        public int Compare(Point p1, Point p2)
        {
            if (p1.x == p2.x && p1.y == p2.y)
            {
                return 0;
            }

            if (p1.x > p2.x && p1.y > p2.y)
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
