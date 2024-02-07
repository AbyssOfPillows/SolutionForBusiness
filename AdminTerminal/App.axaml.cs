using AdminTerminal.ViewModels;
using AdminTerminal.Views;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AdminTerminal;

namespace AdminTerminal
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                AuthWindow authWindow = new();
                desktop.MainWindow = authWindow;
                desktop.MainWindow.DataContext = new AuthWindowViewModel(authWindow);
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}