using Microsoft.Extensions.DependencyInjection;
using NotificationService.Repositories.Notification;

namespace NotificationService.Repositories
{
    public static class RepositoryCollectionExtensions
    {
        public static IServiceCollection AddNotificationRepositories(this IServiceCollection services)
        {
            services.AddTransient<INotificationRepository, NotificationRepository>();
            return services;
        }
    }
}
