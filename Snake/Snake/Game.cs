using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Snake
{
    public class Game
    {
        private Snake _Snake = null;
        private Map _Map = null;
        private IDisplayMap _DisplayMap = null;
        private Controller _Control = new Controller();
        public  Snake Snake
        {
            get { return _Snake; }
            protected set
            {
                _Snake = value;
            }
        }
        public  Map Map
        {
            get { return _Map; }
            protected set
            {
                _Map = value;
            }
        }
        public  IDisplayMap DisplayMap
        {
            get { return _DisplayMap; }
            protected  set
            {
                _DisplayMap = value;
            }
        }

        public void InitialSetup()
        {
            DisplayMap.Render();
            _Control.PushEvent += new PlayerPushButtonEvent(Control_PushEvent);
        }
        public Controller Control
        {
            get { return _Control; }

        }
        private void Control_PushEvent(ControlPushButtonArgument E)
        {
            
            switch (E.Button )
            {
                case enButton.Down:
                    Snake.Turn(enDirection.Down);
                    break;
                case enButton.Left :
                    Snake.Turn(enDirection.Left);
                    break;
                case enButton.Right :
                    Snake.Turn(enDirection.Right);
                    break;
                case enButton.Up :
                    Snake.Turn(enDirection.Up);
                    break ;
                case enButton.Pause :
                    this._State = enGameState.Pause;
                    break;
                case enButton.Reset :
                    
                    break;
            }
        }
        public static Game CreateGame(Map pMap, IDisplayMap pDisplayMap, Snake pSnake)
        {
            Game Game = new Game();
            Game.Map = pMap;
            Game.DisplayMap = pDisplayMap;
            Game.Snake = pSnake;                    
            Game.InitialSetup();
            return Game;
        }
       
      
        private enGameState _State;
        public enGameState State
        {
            get { return _State; }
        }
        private bool IsHitTheFood()
        {
            if (Snake.FirstBokie.X == Map.CurrentFoodPoint.X &&
                Snake.FirstBokie.Y == Map.CurrentFoodPoint.Y)
            {
                        
                return true;
            }
            return false;
        }
        private bool IsHitTheWall()
        {
            if (Snake.FirstBokie.X < 0)
            {
                return true;
            }

            if (Snake.FirstBokie.X >= Map.MaxCol)
            {
                return true;
            }

            if (Snake.FirstBokie.Y < 0)
            {
                return true;
            }

            if (Snake.FirstBokie.Y >= Map.MaxRow)
            {
                return true;
            }

            

            return false;
        }
        private int _Score = 0;
        public int Score
        {
            get { return _Score; }
        }
        private void PutRandomFood()
        {
            bool IsValidPoint = false;

            while (!IsValidPoint)
            {
                Point FoodPoint  = cRandom.GetRandomPoint(Map.MaxRow, Map.MaxCol);
                if (!Snake.IsBokieContainThisPoint(FoodPoint))
                {
                    IsValidPoint = true;
                    
                    Map.PutFoodPoint(FoodPoint);
                }
                
                
            }

        }
        private void AddScore()
        {
            _Score += 9;
        }
        private void AddSnake()
        {
            Snake.AddNewBokieAtTail();

        }
        public void Loop()
        {
            if (State != enGameState.End)
            {
                Snake.Craw();                                
            }

            if (IsHitTheFood())
            {
                AddScore();
                AddSnake();
                Map.ClearFoodPoint();       
            }

            if (Util.IsNullPoint(Map.CurrentFoodPoint))
            {
                PutRandomFood();
            }
            if (IsHitTheWall())
            {
                _State = enGameState.End;
            }

            if (Snake.IsHitItSelf)
            {
                _State = enGameState.End;
            }

            DisplayMap.Render();

        }
       
    }
}
