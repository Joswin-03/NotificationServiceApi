using NotificationServiceAPI.Models;
using NotificationServiceAPI.DTOs;

namespace NotificationServiceAPI.Services.Interfaces
{
    public interface INotificationService
    {
        Task<Notification> Send(NotificationDTO dto);
        Task<List<Notification>> GetAll();
        Task<Notification> Retry(int id);
        Task Delete(int id);
    }
}