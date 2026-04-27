using NotificationServiceAPI.Models;

public interface INotificationRepository
{
    Task<List<Notification>> GetAllAsync();
    Task<Notification> GetByIdAsync(int id);
    Task<Notification> AddAsync(Notification notification);
    Task UpdateAsync(Notification notification);
    Task DeleteAsync(int id);
}