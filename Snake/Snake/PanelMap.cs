using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Snake
{
    class PanelMap:IDisplayMap
    {
        protected Panel _MainPanel = null;
        protected Panel MainPanel
        {
            get { return _MainPanel; }
        }

        public IDisplayMap  SetPanel(Panel pPanel)
        {
            _MainPanel = pPanel;
            return this;
        }
        // private LabelGrid LGrid = new LabelGrid();
        private RectangleGrid RecGrid = new RectangleGrid();
        bool HasInitial = false;
        PictureBox pictureRender = new PictureBox();
        public override void InitialMap()
        {
            //LGrid = new LabelGrid();
            RecGrid = new RectangleGrid();
            pictureRender = new PictureBox();
            pictureRender.BackColor = Color.White;
            int iMaxRow = this.Map.MaxRow;
            int iMaxCol = this.Map.MaxCol;

            int iRow = 0;
            int iCol = 0;
            int CellHeight = 10;
            int CellWidth = 10;
            MainPanel.Controls.Clear();
            for (iRow = 0; iRow < iMaxRow; iRow++)
            {
                //LGrid.Rows.Add(new LabelRow());

                RecGrid.Rows.Add(new RectangleRow());
                for (iCol = 0; iCol < iMaxCol; iCol++)
                {
                    Rectangle R = new Rectangle();
                    R.Height = CellHeight ;
                    R.Width = CellWidth;
                    R.Y  = CellHeight * iRow;
                    R.X = CellWidth * iCol;
                    RectangleExtend RecExtend = new RectangleExtend(R);
                    RecGrid.Rows[iRow].Cols.Add(RecExtend);
                    /*
                    Label L = new Label();
                    L.AutoSize = false;
                    L.Text = "";
                    L.Height = CellHeight;
                    L.Width = CellWidth;
                 
                    L.Top = iHeight * iRow;
                    L.Left = iHeight * iCol;
                    L.Width = 10;
                    L.BackColor = Color.White;                    
                    */
                   
                    //LGrid.Rows[iRow].Cols.Add(L);
                }
            }


            pictureRender.Height = CellHeight * iMaxRow;
            pictureRender.Width = CellWidth * iMaxCol;
            pictureRender.Top = 0;
            pictureRender.Left = 0;

            pictureRender.Paint += PictureRender_Paint;
            MainPanel.Controls.Add(pictureRender);
            MainPanel.Height = pictureRender.Height;
            MainPanel.Width = pictureRender.Width;

            HasInitial = true;
        }

        private void PictureRender_Paint(object sender, PaintEventArgs e)
        {
            // throw new NotImplementedException();
            int i;
            int j;
            for(i=0;i<RecGrid.Rows.Count;i++)
            {
                for(j=0;j<RecGrid.Rows[i].Cols.Count; j++)
                {
                    RectangleExtend Rec = RecGrid.Rows[i].Cols[j];

                    using(Brush brush=new  SolidBrush(Rec.BackColor))
                    {
                        e.Graphics.FillRectangle(brush, Rec.Rec);
                    }
                }
            }

        }

        private bool IsValidPoint(Point P)
        {
            if (P.X < 0 || P.Y < 0)
                return false;

            if (P.X >= Map.MaxCol)
                return false;

            if (P.Y >= Map.MaxRow)
                return false;

            return true;
        }
        public override void RenderSnake()
        {
            foreach (Point P in Snake.Bokie)
            {
                if (IsValidPoint (P))
                {
                   // LGrid.Rows[P.Y].Cols[P.X].BackColor = Color.Teal;
                    RecGrid.Rows[P.Y].Cols[P.X].BackColor = Color.Teal;
                }
            }

            //LGrid.Rows[Snake.LastPointBokie.Y].Cols[Snake.LastPointBokie.X].BackColor = Color.White;
            RecGrid.Rows[Snake.LastPointBokie.Y].Cols[Snake.LastPointBokie.X].BackColor = Color.White;
            pictureRender.Invalidate();

        }
        public override void RenderFood()
        {
            if (!Util.IsNullPoint(Map.CurrentFoodPoint ))
            {
               // LGrid.Rows[Map.CurrentFoodPoint.Y].Cols[Map.CurrentFoodPoint.X].BackColor = Color.Orange;
                RecGrid.Rows[Map.CurrentFoodPoint.Y].Cols[Map.CurrentFoodPoint.X].BackColor = Color.Orange;
                pictureRender.Invalidate();

            }
        }
        public override  void RenderMap()
        {
            if (!HasInitial)
            {
                this.InitialMap();
            }
            
          
        }
        

     
    }
}
