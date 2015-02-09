using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Windows.ApplicationModel.Background;
using Windows.Foundation;
using Windows.System;
using Windows.UI;
using Windows.UI.Xaml.Shapes;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Numerics;

namespace SpaceInvaders
{
    class Game
    {
        private CanvasAnimatedControl _canvas;
        public List<VirtualKey> DownKeys; 

        public Vector2 GameSize { get; set; }

        public List<GameEntity> GameEntities { get; private set; }

        public List<GameEntity> NewGameEntities { get; private set; }

        public Game(Vector2 gameSize)
        {
            GameSize = gameSize;
            GameEntities = new List<GameEntity>();
            NewGameEntities = new List<GameEntity>();
            DownKeys = new List<VirtualKey>();
        }


        public void Update(CanvasTimingInformation timing)
        {
            Debug.WriteLine("Canvas Update {0}", timing.UpdateCount);

            if (NewGameEntities.Count > 0)
            {
                GameEntities.AddRange(NewGameEntities);
                NewGameEntities.Clear();    
            }
            

            // Collidings ?
            GameEntities = new List<GameEntity>(GameEntities.Where(gameEntity => gameEntity.NotCollidingWith(GameEntities)).ToList());


            foreach (GameEntity gameEntity in GameEntities)
            {
                gameEntity.Update(timing);
            }
        }

        private void Draw(CanvasDrawingSession drawingSession, CanvasTimingInformation timing)
        {
            Debug.WriteLine("Canvas Draw {0}", timing.UpdateCount);
            foreach (GameEntity gameEntity in GameEntities)
            {
                gameEntity.Draw(drawingSession, timing);
            }
        }

        public void AttachToControl(CanvasAnimatedControl canvas)
        {
            _canvas = canvas;
            _canvas.Draw += _canvas_Draw;
            _canvas.Update += _canvas_Update;

            GameEntities.Add(new Player(this, GameSize));
            Invader.CreateInvaders(this, 24);
        }

        void _canvas_Update(ICanvasAnimatedControl sender, CanvasAnimatedUpdateEventArgs args)
        {
            Update(args.Timing);
        }

        void _canvas_Draw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            Draw(args.DrawingSession, args.Timing);
        }


        public void AttachKeyEvents(MainPage mainPage)
        {
         
        }
    }

    abstract class GameEntity
    {
        public Vector2 GameSize { get; set; }

        public Vector2 Size { get; set; }

        public abstract Rect SafeBounds { get; }

        public Vector2 Center;

        public abstract void Draw(CanvasDrawingSession drawingSession, CanvasTimingInformation timing);

        public abstract void Update(CanvasTimingInformation timing);

        public bool Intersects(GameEntity entity)
        {
            if (this == entity)
                return false;

            if (entity == null)
                return false;

            if (this.GetType() == typeof (Bullet) && entity.GetType() == typeof (Player)
                || this.GetType() == typeof (Player) && entity.GetType() == typeof (Bullet))
                return false;

            if (this.GetType() == typeof(Invader) && entity.GetType() == typeof(Invader))
                return false;

            if (this.GetType() == typeof (Bullet))
            {
                
            }

            int x1 = (int) Math.Max(SafeBounds.Left, entity.SafeBounds.Left);
            int x2 = (int) Math.Min(SafeBounds.Right, entity.SafeBounds.Right);
            int y1 = (int) Math.Max(SafeBounds.Top, entity.SafeBounds.Top);
            int y2 = (int) Math.Min(SafeBounds.Bottom, entity.SafeBounds.Bottom);
 
            return x2 >= x1 && y2 >= y1;
        }

        public bool NotCollidingWith(IList<GameEntity> gameEntities)
        {
            return gameEntities.Count(e2 => e2.Intersects(this)) == 0;
        }
    }

    class Player : GameEntity
    {
        private Game _currentGame;
        private double lastShooting = 0;

        public Player()
        {
            
        }

        public Player(Game currentGame, Vector2 gameSize)
        {
            _currentGame = currentGame;
            GameSize = gameSize;
            Size = new Vector2() { X = 15, Y = 15 };
            Center = new Vector2() { X = gameSize.X / 2, Y = gameSize.Y / 2 };
        }

        public override Rect SafeBounds
        {
            get
            {
                return new Rect(Center.X - Size.X / 2,
                                        Center.Y - Size.Y / 2,
                                        Size.X,
                                        Size.Y);
            }
        }

        public override void Draw(CanvasDrawingSession drawingSession, CanvasTimingInformation timing)
        {
            drawingSession.FillRectangle(Center.X - Size.X / 2,
                                        Center.Y - Size.Y / 2,
                                        Size.X,
                                        Size.Y, 
                                        Colors.Blue);
        }

        public override void Update(CanvasTimingInformation timing)
        {
            if (_currentGame.DownKeys.Contains(VirtualKey.Left))
            {
                Center.X -= 2;
            }

            if (_currentGame.DownKeys.Contains(VirtualKey.Right))
            {
                Center.X += 2;
            }

            if (_currentGame.DownKeys.Contains(VirtualKey.Space))
            {
                if(timing.TotalTime.TotalMilliseconds - lastShooting < 200)
                    return;


                Bullet bullet = new Bullet(Size, Center);
                _currentGame.NewGameEntities.Add(bullet);
                lastShooting = timing.TotalTime.TotalMilliseconds;
            }
        }
    }

    class Bullet : GameEntity
    {
        private Vector2 _velocity;

        public override Rect SafeBounds
        {
            get
            {
                return new Rect(Center.X - (Size.X / 2),
                                        Center.Y - (Size.Y / 2),
                                        Size.X *2,
                                        Size.Y *2);
            }
        }

        public Bullet(Vector2 gameSize, Vector2 center)
        {
            GameSize = gameSize;
            Size = new Vector2() {X = 5, Y = 5};
            Center = center;
            _velocity = new Vector2(){ X = 0, Y = -6};
        }

        public override void Draw(CanvasDrawingSession drawingSession, CanvasTimingInformation timing)
        {
            //drawingSession.FillRectangle(SafeBounds, Colors.DarkRed);
            drawingSession.FillCircle(Center, Size.X, Colors.MediumVioletRed);
        }

        public override void Update(CanvasTimingInformation timing)
        {
            Center.X += _velocity.X;
            Center.Y += _velocity.Y;
        }
    }

    class Invader : GameEntity
    {
        private Vector2 _velocity;

        private float patrolX = 0;

        public override Rect SafeBounds
        {
            get
            {
                return new Rect(Center.X - Size.X / 2,
                                        Center.Y - Size.Y / 2,
                                        Size.X,
                                        Size.Y);
            }
        }

        public Invader(Vector2 gameSize, Vector2 center)
        {
            GameSize = gameSize;
            Size = new Vector2() { X = 15, Y = 15 };
            Center = center;
            _velocity = new Vector2() { X = 0.3f, Y = -2 };
        }

        public override void Draw(CanvasDrawingSession drawingSession, CanvasTimingInformation timing)
        {
            drawingSession.FillRoundedRectangle(Center.X - Size.X / 2,
                                        Center.Y - Size.Y / 2,
                                        Size.X,
                                        Size.Y, 5, 5, Colors.LimeGreen);
        }

        public override void Update(CanvasTimingInformation timing)
        {
            if (patrolX < 0 || patrolX > 40)
            {
                _velocity.X = -_velocity.X;
            }

            Center.X += _velocity.X;
            patrolX += _velocity.X;
        }

        public static void CreateInvaders(Game game, int numberOfInvaders)
        {
            for (int i = 0; i < numberOfInvaders; i++)
            {
                var x = 30 + (i % 8) * 30;
                var y = 30 + (i % 3) * 30;
                var invader = new Invader(game.GameSize, new Vector2() {X = x, Y = y});
                game.NewGameEntities.Add(invader);
            }
        }
    }


}
