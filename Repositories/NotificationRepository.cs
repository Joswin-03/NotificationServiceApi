using Microsoft.EntityFrameworkCore;
using NotificationServiceAPI.Data;
using NotificationServiceAPI.Models;

namespace NotificationServiceAPI.Repositories.Interfaces
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly AppDbContext _context;

        public NotificationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Notification>> GetAllAsync()
        {
            return await _context.Notifications.ToListAsync();
        }

        public async Task<Notification> GetByIdAsync(int id)
        {
            return await _context.Notifications.FindAsync(id);
        }

        public async Task<Notification> AddAsync(Notification notification)
        {
            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
            return notification;
        }

        public async Task UpdateAsync(Notification notification)
        {
            _context.Notifications.Update(notification);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);

            if (notification == null)
                throw new Exception("Notification not found");

            _context.Notifications.Remove(notification);
            await _context.SaveChangesAsync();
        }
    }
}