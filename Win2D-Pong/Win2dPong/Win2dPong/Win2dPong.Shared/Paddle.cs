using System;
using System.Collections.Generic;
using System.Text;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.UI;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Numerics;

namespace Win2dPong
{
    class Paddle : Win2dMovingObject
    {
        private readonly Rect _screenBounds;
        public Paddle(Vector2 location, Rect screenBounds) : base(location)
        {
            _screenBounds = screenBounds;
            Width = 30;
            Height = 80;
        }

        public bool MoveDown { get; set; }
        public bool MoveUp { get; set; }

        public override void Update()
        {
            if (MoveDown)
            {
                Velocity = new Vector2() {X = 0, Y = -0.2f};
            }

            if (MoveUp)
            {
                Velocity = new Vector2() { X = 0, Y = 0.2f };
            }

            base.Update();
        }

        public override void Draw(CanvasDrawingSession drawing)
        {
            drawing.FillRectangle(new Rect(Location.X, Location.Y, Width, Height), Colors.CornflowerBlue);
        }

        protected override void CheckBounds()
        {
            Location = new Vector2()
            {
                X = Location.X,
                Y = (float) MathUtilities.Clamp(Location.Y, 0, _screenBounds.Height - this.Height)
            };
        }
    }
}
