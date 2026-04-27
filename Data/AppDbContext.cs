using NotificationServiceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace NotificationServiceAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Notification> Notifications { get; set; }
    }
}