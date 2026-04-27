using Microsoft.EntityFrameworkCore;
using NotificationServiceAPI.Data;
using NotificationServiceAPI.Repositories;
using NotificationServiceAPI.Repositories.Interfaces;
using NotificationServiceAPI.Services;
using NotificationServiceAPI.Services.Interfaces;
using NotificationServiceAPI.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// 🔥 Configure Serilog (File Logging)
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// DB
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// DI
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationService, NotificationService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔥 Custom Middleware
app.UseMiddleware<RequestLoggingMiddleware>();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();