using System.Reflection;
using Bearfood_API.Users;
using Microsoft.EntityFrameworkCore;

namespace Bearfood_API;

public static class Startup
{
    public static void AddServices(this IServiceCollection services)
    {
        var serviceType = typeof(IService);
        var types = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t is {IsClass: true, IsAbstract: false} && t.GetInterfaces().Contains(serviceType));

        foreach (var type in types)
        {
            services.AddScoped(type);
        }
    }

    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<UserDbContext>();
        context.Database.Migrate();
    }
    
}