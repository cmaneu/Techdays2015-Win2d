using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Graphics.Canvas.Numerics;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SpaceInvaders
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            this.Loaded += MainPage_Loaded;
        }

        private Game _game;


        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            _game = new Game(new Vector2() { X = (float)this.ActualWidth, Y = (float)this.ActualHeight });
            _game.AttachToControl(Canvas);
            this.Focus(FocusState.Keyboard);
            _game.AttachKeyEvents(this);
        }

        private void OnLeftPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (_game.DownKeys.Contains(VirtualKey.Left))
                return;

            _game.DownKeys.Add(VirtualKey.Left);
        }

        private void OnLeftPointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (!_game.DownKeys.Contains(VirtualKey.Left))
                return;

            _game.DownKeys.Remove(VirtualKey.Left);
        }

        private void OnRightPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (_game.DownKeys.Contains(VirtualKey.Right))
                return;

            _game.DownKeys.Add(VirtualKey.Right);
        }

        private void OnRightPointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (!_game.DownKeys.Contains(VirtualKey.Right))
                return;

            _game.DownKeys.Remove(VirtualKey.Right);
        }

        private void OnBulletPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (_game.DownKeys.Contains(VirtualKey.Space))
                return;

            _game.DownKeys.Add(VirtualKey.Space);
        }

        private void OnBulletPointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (!_game.DownKeys.Contains(VirtualKey.Space))
                return;

            _game.DownKeys.Remove(VirtualKey.Space);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }
    }
}
