using FakeStoreApp;
using FakeStoreApp.Authentication;
using FakeStoreApp.entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
//var attachmentOptions = builder.Configuration.GetSection("Attachments").Get<AttachmentOptions>();
//builder.Services.AddSingleton(attachmentOptions);  

//oprion patterns:
builder.Services.Configure<AttachmentOptions>(builder.Configuration.GetSection("Attachments"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication().AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("Basic", null);
builder.Services.AddLogging(cfg =>
{
    cfg.AddDebug();
    cfg.AddConsole();
});
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FakeStoreDbContext>(cfg => cfg.UseSqlServer(connectionString));

var app = builder.Build();
// serilog
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(config)
    .CreateLogger();

Log.Information("Application Starting");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
