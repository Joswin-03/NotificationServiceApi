using System.Diagnostics;

namespace NotificationServiceAPI.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            Console.WriteLine($"[REQUEST] {context.Request.Method} {context.Request.Path}");

            await _next(context);

            stopwatch.Stop();

            Console.WriteLine($"[RESPONSE] {context.Response.StatusCode} in {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}