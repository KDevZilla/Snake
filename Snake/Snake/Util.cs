using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    public class Util
    {
        public static  bool IsNullPoint(System.Drawing.Point P)
        {
            if (P.X == -1)
                return true;
            if (P.Y == -1)
                return true;

            return false;
        }
        public static System.Drawing.Point  GetNullPoint()
        {
            return new System.Drawing.Point(-1, -1);
        }
    }
}
