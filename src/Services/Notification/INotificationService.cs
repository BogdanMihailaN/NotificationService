using NotificationService.Domain.Notification;

namespace NotificationService.Services.Notification
{
    public interface INotificationService
    {
        Task<List<NotificationModel>> GetAllNotificationsAsync();
        Task<NotificationModel> GetNotificationByIdAsync(Guid id);
        Task CreateNotificationAsync(NotificationModel notification);
        Task UpdateNotificationAsync(Guid id, NotificationModel updatedNotification);
        Task DeleteNotificationAsync(Guid id);
    }
}
