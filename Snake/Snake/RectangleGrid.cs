using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace Snake
{
    public class RectangleGrid
    {
        public List<RectangleRow> Rows = new List<RectangleRow>();

    }
    public class RectangleRow
    {
        public List<RectangleExtend> Cols = new List<RectangleExtend>();
    }
    public class RectangleExtend
    {
        public Color BackColor;
        public Rectangle Rec;
        public RectangleExtend (Rectangle pRec)
        {
            Rec = new Rectangle(pRec.X,
                pRec.Y,
                pRec.Width,
                pRec.Height);
        }
    }
}
