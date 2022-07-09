using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Snake
{
    public class Map
    {
        private int _MaxRow = 0;
        private int _MaxCol = 0;
        public int MaxRow
        {
            get { return _MaxRow; }
        }
        public int MaxCol
        {
            get { return _MaxCol; }
        }
        public Map(int pMaxRow, int pMaxCol)
        {
            _MaxRow = pMaxRow;
            _MaxCol = pMaxCol;
        }
        private Point _CurrentFoodPoint = Util.GetNullPoint();
        public Point CurrentFoodPoint
        {
            get { return _CurrentFoodPoint; }
        }
        public void PutFoodPoint(Point P)
        {
            _CurrentFoodPoint = P;
        }
        public void ClearFoodPoint()
        {
            _CurrentFoodPoint = Util.GetNullPoint();
        }
    }

}
