using System.Linq;
using Serilog;
using Jot;
using Microsoft.Extensions.Logging;

using System.Threading.Tasks;
using DragonArchiver.Core.Services;
using DragonArchiver.Core.ViewModels;
using Microsoft.Extensions.DependencyInjection;


namespace DragonArchiver.Core;

public interface IAppBootstrapper<TViewModel> where TViewModel : class
{
    void ConfigureServices(IServiceCollection services);
    void ConfigureViews(IServiceCollection services);
    void ConfigureViewModels(IServiceCollection services);
    Task<bool> LoadConfigurations();
}

public class DragonArchiverBootstrapper : IAppBootstrapper<ShellViewModel>
{
    private readonly Tracker _tracker = new Tracker();
    private LoggerFactory _loggerFactory;
    private bool _isStarting = true;

    public void ConfigureIoc(IServiceCollection services)
    {
        _loggerFactory = CreateLoggerFactory(BootstrapService.DefaultLogFileName);

        
        ConfigureJotTracker(_tracker, services);

        _isStarting = false;
    }


    public void ConfigureServices(IServiceCollection services)
    {
        var windowManager = new WindowManager(new ViewLocator());

        services.AddSingleton<IWindowManager>(windowManager);
        services.AddSingleton<IFileSelectService, FileSelectService>();
        services.AddSingleton<IDiskExploreService, DiskExploreService>();
        services.AddSingleton<IThemeService, ThemeService>();
    }

    public void ConfigureViews(IServiceCollection services)
    {
        var viewTypes = GetType().Assembly.GetTypes().Where(x => x.Name.EndsWith("View"));

        foreach (var viewType in viewTypes)
            services.AddTransient(viewType);

        //builder.RegisterType<ShellView>().OnActivated(x => _tracker.Track(x.Instance));
    }

    public void ConfigureViewModels(IServiceCollection services)
    {
        var vmTypes = GetType()
            .Assembly
            .GetTypes()
            .Where(x => x.Name.EndsWith("ViewModel"))
            .Where(x => !x.IsAbstract && !x.IsInterface);

        foreach (var vmType in vmTypes)
            services.AddTransient(vmType);

        services.AddSingleton<ShellViewModel>();
        services.AddSingleton<EditorsViewModel>();
        services.AddSingleton<ProjectTreeViewModel>();
        services.AddSingleton<MenuViewModel>();
        services.AddSingleton<StatusViewModel>();
    }

   

    private LoggerFactory CreateLoggerFactory(string logName)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Error()
            .WriteTo.File(logName, rollingInterval: RollingInterval.Month,
                outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}{NewLine}")
            .CreateLogger();

        var factory = new LoggerFactory();
        factory.AddSerilog(Log.Logger);
        return factory;
    }

    public async Task<bool> LoadConfigurations() => true;

    //protected override void OnUnhandledException(DispatcherUnhandledExceptionEventArgs e)
    //{
    //    base.OnUnhandledException(e);

    //    Log.Error(e.Exception, "Unhandled exception");

    //    if (!_isStarting)
    //    {
    //        _container?.Resolve<IWindowManager>()?.ShowMessageBox($"{e.Exception.Message}", "Unhandled Exception", MessageBoxButton.OK, MessageBoxImage.Error);
    //        e.Handled = true;
    //    }
    //}
}