
using System.Windows;
using MainApp.WiewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MainApp;
public partial class App : Application
{
    private IHost _host;

    public App ()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<MainViewModel>();

                services.AddTransient<ProjectsViewModel>();
            })
            .Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }


}
