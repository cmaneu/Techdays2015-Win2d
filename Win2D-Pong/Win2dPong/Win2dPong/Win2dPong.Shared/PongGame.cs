using System;
using System.Collections.Generic;
using System.Text;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml.Input;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Numerics;

namespace Win2dPong
{
    class PongGame
    {

        private Paddle _paddle;
        private CanvasAnimatedControl _canvasControl;

        public PongGame(CanvasAnimatedControl canvasControl)
        {
            _canvasControl = canvasControl;
            _paddle = new Paddle(new Vector2() { X = 0, Y = 0 }, new Rect(0, 0, _canvasControl.ActualWidth, _canvasControl.ActualHeight));

            _canvasControl.Input.PointerPressed += OnCanvasPointerPressed;
            _canvasControl.Input.PointerReleased += OnCanvasPointerReleased;

        }

        private void OnCanvasPointerReleased(object sender, PointerEventArgs args)
        {
            
            _paddle.MoveUp = false;
            _paddle.MoveDown = false;
        }

        private void OnCanvasPointerPressed(object sender, PointerEventArgs args)
        {
            if (args.CurrentPoint.Position.X < _canvasControl.ActualWidth / 2)
            {
                _paddle.MoveUp = true;
                _paddle.MoveDown = false;
            }
            else
            {
                _paddle.MoveUp = false;
                _paddle.MoveDown = true;
            }
        }

        private void OnCanvasTapped(object sender, TappedRoutedEventArgs e)
        {
            e.Handled = true;
            Point pointerPosition = e.GetPosition(_canvasControl);
            if (pointerPosition.X < _canvasControl.ActualWidth / 2)
            {
                _paddle.MoveUp = true;
                _paddle.MoveDown = false;
            }
            else
            {
                _paddle.MoveUp = false;
                _paddle.MoveDown = true;
            }
        }

        private void OnPointerReleased(object sender, PointerRoutedEventArgs e)
        {
            e.Handled = true;
            _paddle.MoveUp = false;
            _paddle.MoveDown = false;
        }

        private void OnPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            e.Handled = true;
            var pointerPosition = e.GetCurrentPoint(_canvasControl).Position;
            if (pointerPosition.X < _canvasControl.ActualWidth / 2)
            {
                _paddle.MoveUp = true;
                _paddle.MoveDown = false;
            }
            else
            {
                _paddle.MoveUp = false;
                _paddle.MoveDown = true;
            }
        }

        private void OnManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            _paddle.MoveUp = false;
            _paddle.MoveDown = false;
        }

        private void OnManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            if (e.Position.X < _canvasControl.ActualWidth/2)
            {
                _paddle.MoveUp = true;
                _paddle.MoveDown = false;
            }
            else
            {
                _paddle.MoveUp = false;
                _paddle.MoveDown = true;
            }
        }


        public void Update()
        {
            _paddle.Update();
            _paddle.MoveUp = false;
            _paddle.MoveDown = false;
        }

        public void Draw(CanvasDrawingSession drawSession)
        {
            _paddle.Draw(drawSession);
        }
    }
}
