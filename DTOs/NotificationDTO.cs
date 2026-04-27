using System.ComponentModel.DataAnnotations;

namespace NotificationServiceAPI.DTOs
{
    public class NotificationDTO
    {
        [Required]
        public string Message { get; set; } = string.Empty;
    }
}