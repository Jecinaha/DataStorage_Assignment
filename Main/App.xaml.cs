using Main.ViewModels;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace Main;
public partial class App : Application
{
    private IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
               .ConfigureServices((context, services) =>
            {
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<MainWindow>();

                services.AddSingleton<ProjectViewModel>();
                
            })
            .Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}
