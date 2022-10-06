using HelloWorld.Interfaces;
using HelloWorld.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HelloWorld;

public static class Startup
{
    public static ServiceProvider Services { get; private set; }

    public static void ConfigureServices()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<INetworkServices, NetworkServices>();
        serviceCollection.AddSingleton<IPersonStore, PersonsStore>();
        Services = serviceCollection.BuildServiceProvider();
    }
}