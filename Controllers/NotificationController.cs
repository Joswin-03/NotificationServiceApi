using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotificationServiceAPI.Services.Interfaces;
using NotificationServiceAPI.DTOs;
using NotificationServiceAPI.Models;
using NotificationServiceAPI.Helpers;
using System.Diagnostics;
[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _service;
    private readonly ILogger<NotificationController> _logger;

    public NotificationController(INotificationService service,
                                  ILogger<NotificationController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpPost("send")]
    public async Task<IActionResult> Send(NotificationDTO dto)
    {
        var sw = Stopwatch.StartNew();
        string user = "Admin";

        _logger.LogInformation($"[{user}] Sending notification");
        FileLogger.Log($"[{user}] Sending notification");

        var result = await _service.Send(dto);

        sw.Stop();

        _logger.LogInformation($"[{user}] Send completed in {sw.ElapsedMilliseconds} ms");
        FileLogger.Log($"[{user}] Send completed in {sw.ElapsedMilliseconds} ms");

        return Ok(result);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var sw = Stopwatch.StartNew();
        string user = "Admin";

        _logger.LogInformation($"[{user}] Fetching notifications");
        FileLogger.Log($"[{user}] Fetching notifications");

        var result = await _service.GetAll();

        sw.Stop();

        _logger.LogInformation($"[{user}] Fetch completed in {sw.ElapsedMilliseconds} ms");
        FileLogger.Log($"[{user}] Fetch completed in {sw.ElapsedMilliseconds} ms");

        return Ok(result);
    }

    [HttpPost("retry/{id}")]
    public async Task<IActionResult> Retry(int id)
    {
        var sw = Stopwatch.StartNew();
        string user = "Admin";

        _logger.LogInformation($"[{user}] Retrying notification ID: {id}");
        FileLogger.Log($"[{user}] Retrying notification ID: {id}");

        var result = await _service.Retry(id);

        sw.Stop();

        _logger.LogInformation($"[{user}] Retry completed in {sw.ElapsedMilliseconds} ms");
        FileLogger.Log($"[{user}] Retry completed in {sw.ElapsedMilliseconds} ms");

        return Ok(result);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var sw = Stopwatch.StartNew();
        string user = "Admin";

        _logger.LogInformation($"[{user}] Deleting notification ID: {id}");
        FileLogger.Log($"[{user}] Deleting notification ID: {id}");

        await _service.Delete(id);

        sw.Stop();

        _logger.LogInformation($"[{user}] Delete completed in {sw.ElapsedMilliseconds} ms");
        FileLogger.Log($"[{user}] Delete completed in {sw.ElapsedMilliseconds} ms");

        return Ok("Deleted successfully");
    }
}