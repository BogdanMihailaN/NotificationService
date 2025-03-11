using MongoDB.Bson.Serialization.Attributes;
using NotificationService.Domain.Enums;
using System.Text.Json.Serialization;

namespace NotificationService.Domain.Notification
{
    public class NotificationModel
    {
        [BsonId]
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public NotificationType Type { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
