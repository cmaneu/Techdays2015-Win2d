using System;
using System.Collections.Generic;
using Windows.UI;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Numerics;

namespace Win2dPong
{
    abstract class Win2dMovingObject
    {
        public Vector2 Location { get; set; }
        public Vector2 Velocity { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }


        public Win2dMovingObject(Vector2 location)
        {
            Location = location;
            Velocity = new Vector2 {X = 0, Y = 0};
        }

        public virtual void Update()
        {
            Location = System.Numerics.Vector2.Add(Location, Velocity);
            CheckBounds();
        }

        public abstract void Draw(CanvasDrawingSession drawing);


        protected abstract void CheckBounds();

    }
}
