namespace NotificationServiceAPI.Models

{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}