using NotificationService.Domain.Notification;
using NotificationService.Repositories.Notification;

namespace NotificationService.Services.Notification
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task CreateNotificationAsync(NotificationModel notification)
        {
            await _notificationRepository.CreateNotificationAsync(notification);
        }

        public async Task DeleteNotificationAsync(Guid id)
        {
            await _notificationRepository.DeleteNotificationAsync(id);
        }

        public async Task<List<NotificationModel>> GetAllNotificationsAsync()
        {
            return await _notificationRepository.GetAllNotificationsAsync();
        }

        public async Task<NotificationModel> GetNotificationByIdAsync(Guid id)
        {
            return await _notificationRepository.GetNotificationByIdAsync(id);
        }

        public async Task UpdateNotificationAsync(Guid id, NotificationModel updatedNotification)
        {
            await _notificationRepository.UpdateNotificationAsync(id, updatedNotification);
        }
    }
}
