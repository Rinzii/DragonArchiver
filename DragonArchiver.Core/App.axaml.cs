using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using DragonArchiver.Core.ViewModels;
using DragonArchiver.Core.Views;

namespace DragonArchiver.Core
{
    public partial class App : Application
    {
        public override void Initialize() => AvaloniaXamlLoader.Load(this);

        public override void OnFrameworkInitializationCompleted()
        {
            var services = new ServiceCollection();
            var bootstrapper = new DragonArchiverBootstrapper();
            bootstrapper.ConfigureIoc(services);
            bootstrapper.ConfigureServices(services);
            bootstrapper.ConfigureViews(services);
            bootstrapper.ConfigureViewModels(services);
            //await bootstrapper.LoadConfigurations();

            var provider = services.BuildServiceProvider();

            Ioc.Default.ConfigureServices(provider);

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var shellViewModel = provider.GetService<ShellViewModel>();
                var shellView = provider.GetService<ShellView>();
                shellView!.DataContext = shellViewModel;
                desktop.MainWindow = shellView;

            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}