using MongoDB.Driver;
using NotificationService.Domain.Notification;
using NotificationService.Infrastructure;

namespace NotificationService.Repositories.Notification
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly MongoDbService _mongoDbService;

        public NotificationRepository(MongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        public async Task<List<NotificationModel>> GetAllNotificationsAsync()
        {
            var collection = _mongoDbService.GetNotificationCollection();
            return await collection.Find(_ => true).ToListAsync();
        }

        public async Task<NotificationModel> GetNotificationByIdAsync(Guid id)
        {
            var collection = _mongoDbService.GetNotificationCollection();
            return await collection.Find(notification => notification.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateNotificationAsync(NotificationModel notification)
        {
            var collection = _mongoDbService.GetNotificationCollection();
            await collection.InsertOneAsync(notification);
        }

        public async Task UpdateNotificationAsync(Guid id, NotificationModel updatedNotification)
        {
            var collection = _mongoDbService.GetNotificationCollection();
            updatedNotification.Id = id;
            await collection.ReplaceOneAsync(notification => notification.Id == id, updatedNotification);
        }

        public async Task DeleteNotificationAsync(Guid id)
        {
            var collection = _mongoDbService.GetNotificationCollection();
            await collection.DeleteOneAsync(notification => notification.Id == id);
        }
    }
}
