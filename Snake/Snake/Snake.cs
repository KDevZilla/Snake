using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Snake
{
    public class Snake
    {
        private List<Point> _Bokie = null;
        private bool _IsHitItSelf = false;
        public bool IsHitItSelf
        {
            get
            {
                return _IsHitItSelf;
            }
        }
        public void AddNewBokieAtTail()
        {
            Point P = new Point(LastPointBokie.X, LastPointBokie.Y);
            Bokie.Add(P);
        }
        public bool IsBokieContainThisPoint(Point pP)
        {
            foreach (Point P in Bokie)
            {
                if (P.X == pP.X &&
                    P.Y == pP.Y)
                {
                    return true;
                }
            }
            return false;
        }
        public List<Point> Bokie
        {
            get
            {
                if (_Bokie == null)
                {
                    _Bokie = new List<Point>();
                }
                return _Bokie;
            }
           
        }
        public Point LatestBokie
        {
            get
            {
                return Bokie[Bokie.Count - 1];
            }
        }
        public Point FirstBokie
        {
            set
            {
                Bokie[0] = value;
            }
            get
            {
                return Bokie[0];
            }
        }
        private Point _LastPointBokie;
        public Point LastPointBokie
        {
            get
            {
                return _LastPointBokie;
            }
        }
        private enDirection _CurrentDirection = enDirection.Right;
        public void Turn(enDirection pCurrentDirection)
        {
            _CurrentDirection = pCurrentDirection;
        }
        private void CheckHitItSelf()
        {
            int i = 0;
            int j = 0;
            for (i = Bokie.Count - 1; i > 0; i--)
            {
                if (Bokie[i].X == FirstBokie.X &&
                    Bokie[i].Y == FirstBokie.Y)
                {
                    _IsHitItSelf = true;
                    break;
                }

            }
        }
        public void Craw()
        {
            int i;

            _LastPointBokie = Bokie[Bokie.Count - 1];

            for (i = Bokie.Count - 1; i > 0; i--)
            {                
                Bokie[i] = new Point(Bokie [i - 1].X, Bokie[i - 1].Y);

            }
            int TempX = FirstBokie.X;
            int TempY = FirstBokie.Y;
            switch (_CurrentDirection)
            {
                case enDirection.Up:
                    TempY--;
                    break;
                case enDirection.Down:
                    TempY++;
                    break;
                case enDirection.Left:
                    TempX--;
                    break;
                case enDirection.Right:
                    TempX++;
                    break;
            }

            FirstBokie = new Point(TempX, TempY);
            this.CheckHitItSelf();
        }
        
    }
}
