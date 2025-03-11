using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using NotificationService.Domain.Notification;

namespace NotificationService.Infrastructure
{
    public class MongoDbService
    {
        private readonly IMongoDatabase _database;

        public MongoDbService(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("MongoDbSettings:ConnectionString"));

            BsonSerializer.RegisterSerializer(typeof(Guid), new GuidSerializer(GuidRepresentation.Standard));

            _database = client.GetDatabase(configuration.GetValue<string>("MongoDbSettings:DatabaseName"));
        }

        public IMongoCollection<NotificationModel> GetNotificationCollection()
        {
            return _database.GetCollection<NotificationModel>("notifications");
        }
    }
}
