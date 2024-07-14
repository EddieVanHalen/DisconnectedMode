using System.Windows;
using DisconnectedMode.View;
using DisconnectedMode.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;

namespace DisconnectedMode;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static ServiceCollection Collection { get; private set; } = null!;
    public static ServiceProvider Provider { get; private set; } = null!;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        Collection = new ServiceCollection();

        Collection.AddSingleton<MainView>();
        Collection.AddSingleton<MainViewModel>();
        Collection.AddSingleton<MainPageViewModel>();
        Collection.AddSingleton<ConfigurationBuilder>();

        Provider = Collection.BuildServiceProvider();

        var view = Provider.GetService<MainView>()!;

        view.ShowDialog();
    }
}