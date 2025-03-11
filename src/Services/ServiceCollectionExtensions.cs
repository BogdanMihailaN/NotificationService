using Microsoft.Extensions.DependencyInjection;
using NotificationService.Services.Notification;

namespace NotificationService.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNotificationServices(this IServiceCollection services)
        {
            services.AddTransient<INotificationService, Notification.NotificationService>();
            return services;
        }
    }
}
