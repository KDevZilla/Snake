using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing ;

namespace Snake
{
    public class cRandom
    {
        private static Random R = new Random();
        public static Point GetRandomPoint(int MaxRow, int MaxColumn)
        {
            int X = 0;
            int Y = 0;
            X = R.Next(0, MaxColumn);
            Y = R.Next(0, MaxRow);
            Point P = new Point(X, Y);
            return P;
        }
    }
}
