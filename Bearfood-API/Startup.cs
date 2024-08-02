using System.Reflection;

namespace Bearfood_API;

public static class Startup
{
    public static void AddServices(IServiceCollection services)
    {
        var serviceType = typeof(IService);
        var types = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t is {IsClass: true, IsAbstract: false} && t.GetInterfaces().Contains(serviceType));

        foreach (var type in types)
        {
            services.AddScoped(type);
        }
    }

}