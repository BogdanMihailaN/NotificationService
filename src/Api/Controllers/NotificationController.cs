using Microsoft.AspNetCore.Mvc;
using NotificationService.Domain.Notification;
using NotificationService.Services.Notification;

namespace NotificationService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotificationsAsync()
        {
            var notifications = await _notificationService.GetAllNotificationsAsync();
            return Ok(notifications);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationByIdAsync(Guid id)
        {
            var notification = await _notificationService.GetNotificationByIdAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            return Ok(notification);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotificationAsync([FromBody] NotificationModel newNotification)
        {
            await _notificationService.CreateNotificationAsync(newNotification);
            return Ok(newNotification);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotificationAsync(Guid id, [FromBody] NotificationModel updatedNotification)
        {
            await _notificationService.UpdateNotificationAsync(id, updatedNotification);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificationAsync(Guid id)
        {
            await _notificationService.DeleteNotificationAsync(id);
            return NoContent();
        }
    }
}
