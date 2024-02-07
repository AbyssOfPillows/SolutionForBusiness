using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using SecurityOfficerTerminal.ViewModels;
using SecurityOfficerTerminal.Views;

namespace SecurityOfficerTerminal
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
                AuthWindow authWindow = new AuthWindow();
                authWindow.DataContext = new AuthWindowViewModel(authWindow);
                desktop.MainWindow = authWindow;
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}