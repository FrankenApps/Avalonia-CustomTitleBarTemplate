using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Themes.Fluent;
using Avalonia.Themes.Simple;
using CustomTitleBarTemplate.Views;

namespace CustomTitleBarTemplate
{
    public class App : Application
    {
        public static FluentTheme FluentTheme = new FluentTheme();

        public static SimpleTheme SimpleTheme = new SimpleTheme();

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
