using Microsoft.Extensions.DependencyInjection;

namespace NotificationService.Infrastructure
{
    public static class InfrastructureCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<MongoDbService>();
            return services;
        }
    }
}
