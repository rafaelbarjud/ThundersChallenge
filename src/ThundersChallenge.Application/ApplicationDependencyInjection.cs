

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ThundersChallenge.Application.Notification;


namespace ThundersChallenge.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped<NotificationContext>();

        return services;
    }
}
