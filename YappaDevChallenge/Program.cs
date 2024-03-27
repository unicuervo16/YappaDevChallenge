using Microsoft.EntityFrameworkCore;
using Serilog.Events;
using Serilog;
using YappaDevChallenge.Context;

var builder = WebApplication.CreateBuilder(args);

// Añadir CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWebApp",
        policyBuilder =>
        {
            policyBuilder.WithOrigins("http://127.0.0.1:5500") // Ajusta esto a la URL de tu aplicación web
                         .AllowAnyHeader()
                         .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Configuro Serilog para registro de errores
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/YappaClientsErrors.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilitar CORS
app.UseCors("AllowWebApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
