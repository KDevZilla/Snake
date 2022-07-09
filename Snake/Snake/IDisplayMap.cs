using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace Snake
{
    public abstract  class  IDisplayMap
    {
        public void Render()
        {
            RenderMap();
            RenderSnake();
            RenderFood();
        }
        public abstract void RenderMap();
        public abstract void RenderSnake();
        public abstract void RenderFood();

        protected  Snake _Snake = null;
        protected Snake Snake
        {
            get { return _Snake; }
        }
        protected Map _Map = null;
        protected Map Map
        {
            get { return _Map; }
        }
    
        public abstract void InitialMap();
        public void SetSnake(Snake pSnake)
        {
            _Snake = pSnake ;
        }
        public void SetMap(Map pMap)
        {
            _Map = pMap ;
        }

        
    }
}
