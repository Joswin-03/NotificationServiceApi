using System.IO;

namespace NotificationServiceAPI.Helpers
{
    public static class FileLogger
    {
        private static readonly string logPath = "logs/log.txt";

        public static void Log(string message)
        {
            var directory = Path.GetDirectoryName(logPath);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            using (StreamWriter sw = new StreamWriter(logPath, true))
            {
                sw.WriteLine($"{DateTime.Now:HH:mm:ss} - {message}");
            }
        }
    }
}