using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace CustomTitleBarTemplate.Views.CustomTitleBars
{
    public class WindowsTitleBar : UserControl
    {
        private Button minimizeButton;
        private Button maximizeButton;
        private Path maximizeIcon;
        private Button closeButton;
        private Image windowIcon;

        private bool isWindowStateSubscribed = false;

        public WindowsTitleBar()
        {
            this.InitializeComponent();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) == false)
            {
                this.IsVisible = false;
            }
            else
            {
                minimizeButton = this.FindControl<Button>("MinimizeButton");
                maximizeButton = this.FindControl<Button>("MaximizeButton");
                maximizeIcon = this.FindControl<Path>("MaximizeIcon");
                closeButton = this.FindControl<Button>("CloseButton");
                windowIcon = this.FindControl<Image>("WindowIcon");

                minimizeButton.Click += MinimizeWindow;
                maximizeButton.Click += MaximizeWindow;
                closeButton.Click += CloseWindow;
                windowIcon.DoubleTapped += CloseWindow;
            }
        }

        private void CloseWindow(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Window hostWindow = (Window)this.VisualRoot;
            hostWindow.Close();
        }

        private void MaximizeWindow(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Window hostWindow = (Window)this.VisualRoot;

            if (hostWindow.WindowState == WindowState.Normal)
            {
                if (isWindowStateSubscribed == false)
                {
                    SubscribeToWindowState();
                }
                hostWindow.SystemDecorations = SystemDecorations.None;
                hostWindow.WindowState = WindowState.Maximized;
                hostWindow.CanResize = false;
            }
            else
            {
                hostWindow.WindowState = WindowState.Normal;
            }
        }

        private void MinimizeWindow(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Window hostWindow = (Window)this.VisualRoot;
            hostWindow.WindowState = WindowState.Minimized;
        }

        private void SubscribeToWindowState()
        {
            Window hostWindow = (Window)this.VisualRoot;
            hostWindow.GetObservable(Window.WindowStateProperty).Subscribe(s =>
            {
                if (s != WindowState.Maximized)
                {
                    maximizeIcon.Data = Avalonia.Media.Geometry.Parse("M2048 2048v-2048h-2048v2048h2048zM1843 1843h-1638v-1638h1638v1638z");
                    hostWindow.SystemDecorations = SystemDecorations.Full;
                    hostWindow.CanResize = true;
                }
                if (s == WindowState.Maximized)
                {
                    maximizeIcon.Data = Avalonia.Media.Geometry.Parse("M2048 1638h-410v410h-1638v-1638h410v-410h1638v1638zm-614-1024h-1229v1229h1229v-1229zm409-409h-1229v205h1024v1024h205v-1229z");
                    hostWindow.CanResize = false;
                }
            });
            isWindowStateSubscribed = true;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
