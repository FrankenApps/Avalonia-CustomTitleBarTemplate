using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Styling;
using CustomTitleBarTemplate.ViewModels;
using System.Runtime.InteropServices;

namespace CustomTitleBarTemplate.Views
{
    public partial class MainWindow : Window
    {
        private ToggleButton darkThemeToggleButton;

        public MainWindow()
        {
            this.InitializeComponent();

            #if DEBUG
            this.AttachDevTools();
            #endif


            // Do not use a custom title bar on Linux, because there are too many possible options.
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) == true)
            {
                UseNativeTitleBar();
            }

            this.DataContext = new MainWindowViewModel(this);

            this.Height = 400;
            this.Width = 600;
            this.Padding = new Thickness(
                            this.OffScreenMargin.Left,
                            this.OffScreenMargin.Top,
                            this.OffScreenMargin.Right,
                            this.OffScreenMargin.Bottom);

            darkThemeToggleButton = this.FindControl<ToggleButton>("DarkThemeToggleButton");
            darkThemeToggleButton.IsCheckedChanged += DarkThemeToggleButton_IsCheckedChanged;

            Application.Current.RequestedThemeVariant = ThemeVariant.Light;
        }

        private void DarkThemeToggleButton_IsCheckedChanged(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (darkThemeToggleButton.IsChecked == true)
            {
                SetDarkTheme();
                return;
            }

            SetLightTheme();
        }

        private void SetLightTheme()
        {
            Cursor = new Cursor(StandardCursorType.Wait);
            Application.Current.RequestedThemeVariant = ThemeVariant.Light;
            Application.Current.Resources["MacOsTitleBarBackground"] = new SolidColorBrush { Color = new Color(255, 222, 225, 230) };
            Application.Current.Resources["MacOsWindowTitleColor"] = new SolidColorBrush { Color = new Color(255, 77, 77, 77) };
            Cursor = new Cursor(StandardCursorType.Arrow);
        }

        private void SetDarkTheme()
        {
            Cursor = new Cursor(StandardCursorType.Wait);
            Application.Current.RequestedThemeVariant = ThemeVariant.Dark;
            Cursor = new Cursor(StandardCursorType.Arrow);
        }

        private void UseNativeTitleBar()
        {
            ExtendClientAreaChromeHints = Avalonia.Platform.ExtendClientAreaChromeHints.SystemChrome;
            ExtendClientAreaTitleBarHeightHint = -1;
            ExtendClientAreaToDecorationsHint = false;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
