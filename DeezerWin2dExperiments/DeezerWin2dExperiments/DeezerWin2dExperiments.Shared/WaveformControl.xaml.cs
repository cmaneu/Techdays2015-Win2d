using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Graphics.Canvas;

namespace DeezerWin2dExperiments
{
    public sealed partial class WaveformControl : UserControl
    {
        Waveform wf = new Waveform();

        public static readonly DependencyProperty WaveformDataProperty = DependencyProperty.Register(
          "WaveformData", typeof(string), typeof(WaveformControl), new PropertyMetadata(default(string), OnWaveformDataChanged));

        public string WaveformData
        {
            get { return (string)GetValue(WaveformDataProperty); }
            set { SetValue(WaveformDataProperty, value); }
        }


        public static readonly DependencyProperty ForegroundColorProperty = DependencyProperty.Register(
            "ForegroundColor", typeof (Color), typeof (WaveformControl), new PropertyMetadata(default(Color)));

        public Color ForegroundColor
        {
            get { return (Color) GetValue(ForegroundColorProperty); }
            set { SetValue(ForegroundColorProperty, value); }
        }

        public static readonly DependencyProperty Foreground2ColorProperty = DependencyProperty.Register(
            "Foreground2Color", typeof (Color), typeof (WaveformControl), new PropertyMetadata(default(Color)));

        public Color Foreground2Color
        {
            get { return (Color) GetValue(Foreground2ColorProperty); }
            set { SetValue(Foreground2ColorProperty, value); }
        }

        private static void OnWaveformDataChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            WaveformControl currentControl = d as WaveformControl;
            currentControl.Update();
        }

        private void Update()
        {
            wf = new Waveform();
            wf.LoadMapFromString(WaveformData);
            Canvas.Invalidate();
            Canvas.ClearColor = Colors.Transparent;
        }

        public WaveformControl()
        {
            this.InitializeComponent();
        }


        private void Canvas_OnDraw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            if (wf != null)
            {
                wf.Draw(args.DrawingSession, sender.ActualWidth, sender.ActualHeight, ForegroundColor, Foreground2Color, true);
            }
        }

    }
}
