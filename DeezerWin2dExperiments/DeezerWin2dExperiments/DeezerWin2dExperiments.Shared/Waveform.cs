using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Numerics;

namespace DeezerWin2dExperiments
{
    class Waveform
    {

        private List<int> _map;
        public List<int> LoadMapFromString(string content)
        {
            if (content.Length <= 0)
                return null;

            List<int> map = new List<int>();

            byte[] charBytes = Encoding.UTF8.GetBytes(content.ToCharArray());

            foreach (var value in charBytes)
            {
                var v = value <= 90 ? value - 65 : value - 71;
                map.Add(v);
            }

            _map = map;
            return map;
        }

        public void Draw(CanvasDrawingSession drawingSession, double width, double height, Color foregroundColor, Color foreground2Color, bool halfWaveform = false)
        {
            int min, max;
            var mid = Math.Floor(height / 2);

            for (int i = 0; i < width; i++)
            {
                double a = Math.Floor(i * _map.Count / width);
                var b = Math.Ceiling((i + 2) * _map.Count / width);

                if ((b - a) < 4)
                {
                    b = a + 1;
                }

                if (_map.Count != 4)
                {
                    min = 99;
                    max = 0;
                }
                else
                {
                    min = 37;
                    max = 44;
                }

                //min = _map.Min();
                //max = _map.Max();
                for (int j = (int)a; j < b && j < _map.Count; j++)
                {

                    if (_map[j] > max) max = _map[j];
                    if (_map[j] < min) min = _map[j];
                }

                var pt1 = max * 0.9;
                var pt2 = min * 0.8;

                if (pt2 < 1)
                {
                    pt2 = 1;
                }

                var x1 = i;
                float y1 = (float)(-pt1 + mid);

                float y2 = (float)((-pt1 + (pt1 * 2)) + mid);
                var x2 = i + 1;

                
                //drawingSession.DrawLine(new Vector2 { X = i, Y = y1 }, new Vector2 { X = i, Y = y2 }, foreground2Color);
                // Top horizon
                //drawingSession.DrawLine(new Vector2 { X = i, Y = y2 }, new Vector2 { X = i, Y = 150 }, Colors.Coral);
                // Bottom horizon
                //drawingSession.DrawLine(new Vector2 { X = i, Y = 0 }, new Vector2 { X = i, Y = y1 }, Colors.Blue);

                

                y2 = (float)((-pt2 + (pt2 * 2)) + mid);
                if(!halfWaveform)
                {
                    drawingSession.DrawLine(new Vector2 { X = i, Y = (float)(-pt2 + mid) }, new Vector2 { X = i, Y = y2 }, foregroundColor);
                    
                }
                //else
                {
                // CORRECT
                    //drawingSession.DrawLine(new Vector2 { X = i, Y = (float) mid }, new Vector2 { X = i, Y = y1 }, Colors.ForestGreen);
                    drawingSession.DrawLine(new Vector2 { X = i, Y = (float)height }, new Vector2 { X = i, Y = (float)(y1 + mid) }, foregroundColor);
                }
            }
        }
    }
}
