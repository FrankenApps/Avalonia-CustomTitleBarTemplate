using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using CustomTitleBarTemplate.ViewModels;
using System.Linq;
using System.Linq.Expressions;

namespace CustomTitleBarTemplate.Views
{
    public class MainWindow : Window
    {
        private ToggleButton darkThemeToggleButton;
        public MainWindow()
        {
            this.InitializeComponent();

            this.AttachDevTools();

            this.DataContext = new MainWindowViewModel(this);

            this.Height = 400;
            this.Width = 600;
            this.Padding = new Thickness(
                            this.OffScreenMargin.Left,
                            this.OffScreenMargin.Top,
                            this.OffScreenMargin.Right,
                            this.OffScreenMargin.Bottom);

            darkThemeToggleButton = this.FindControl<ToggleButton>("DarkThemeToggleButton");
            darkThemeToggleButton.Checked += SetDarkTheme;
            darkThemeToggleButton.Unchecked += SetLightTheme;

            Application.Current.Styles[1] = App.FluentLight;
        }

        private void SetLightTheme(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Cursor = new Cursor(StandardCursorType.Wait);
            Application.Current.Styles[1] = App.FluentLight;
            Application.Current.Resources["MacOsTitleBarBackground"] = new SolidColorBrush { Color = new Color(255, 222, 225, 230) };
            Application.Current.Resources["MacOsWindowTitleColor"] = new SolidColorBrush { Color = new Color(255, 77, 77, 77) };
            Cursor = new Cursor(StandardCursorType.Arrow);
        }

        private void SetDarkTheme(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Cursor = new Cursor(StandardCursorType.Wait);
            Application.Current.Styles[1] = App.FluentDark;
            Application.Current.Resources["MacOsTitleBarBackground"] = new SolidColorBrush { Color = new Color(255, 62, 62, 64) };
            Application.Current.Resources["MacOsWindowTitleColor"] = new SolidColorBrush { Color = new Color(255, 153, 158, 161) };
            Cursor = new Cursor(StandardCursorType.Arrow);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
