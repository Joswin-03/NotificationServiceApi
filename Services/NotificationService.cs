using Microsoft.Extensions.Logging;
using NotificationServiceAPI.DTOs;
using NotificationServiceAPI.Helpers;
using NotificationServiceAPI.Models;
using NotificationServiceAPI.Repositories.Interfaces;
using NotificationServiceAPI.Services.Interfaces;

namespace NotificationServiceAPI.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repo;
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(INotificationRepository repo,
                                   ILogger<NotificationService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<Notification> Send(NotificationDTO dto)
        {
            var notification = new Notification
            {
                Message = dto.Message,
                Status = "Sent",
                CreatedDate = DateTime.Now
            };

            return await _repo.AddAsync(notification);
        }

        public async Task<List<Notification>> GetAll()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Notification> Retry(int id)
        {
            var notification = await _repo.GetByIdAsync(id);

            if (notification == null)
                throw new Exception("Not found");

            notification.Status = "Sent";
            await _repo.UpdateAsync(notification);
            if (notification == null)
            {
                FileLogger.Log("[Admin] WARNING: Invalid notification ID");
                throw new Exception("Notification not found");
            }
            return notification;
        }
        public async Task Delete(int id)
        {
            _logger.LogInformation($"Deleting notification {id}");

            await _repo.DeleteAsync(id);

            _logger.LogInformation("Delete successful");
        }
    }
}