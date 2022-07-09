using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace Snake
{
    public class GameBuilder
    {
        private Map _Map;
        private Map Map
        {
            get { return _Map; }
        }
        private void InitialSnake()
        {
            int iX;
            for (iX = 7; iX >= 0; iX--)
            {

                _MySnake.Bokie.Add(new Point(iX, 10));
            }



        }
        private IDisplayMap _DisplayMap;
        private IDisplayMap DisplayMap
        {
            get{return _DisplayMap ;}
        }

        public GameBuilder setMapSize(int MaxRow, int MaxCol)
        {
            _Map = new Map(MaxRow, MaxCol);
            return this;
        }
        private Snake _MySnake = null;
        private Snake MySnake
        {
            get
            {
                if (_MySnake == null)
                {
                    _MySnake = new Snake();
                    this.InitialSnake();
                }
                return _MySnake;
            }
        }
        public GameBuilder setDisplayMap(IDisplayMap pDisplayMap)
        {
            if (this.Map == null)
            {
                throw new Exception("Map is null. Please set map first.");
            }
            _DisplayMap = pDisplayMap;
            _DisplayMap.SetMap(this.Map);
            _DisplayMap.SetSnake(this.MySnake );
            return this;
        }

        public  Game Build()
        {
            Game NewGame= Game.CreateGame (Map,DisplayMap ,this.MySnake );
            return NewGame;
        }
    }
}
