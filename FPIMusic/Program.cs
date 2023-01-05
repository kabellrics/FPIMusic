using FPIMusic.DataAccess;
using FPIMusic.Services;
using FPIMusic.Services.Settings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
const string AllowAllHeadersPolicy = "AllowAllHeadersPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowAllHeadersPolicy,
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
// Add services to the container.
builder.Services.AddDbContext<FPIMusicRepository>();
builder.Services.AddTransient<ISettingsRepository, SettingsRepository>();
builder.Services.AddTransient<ISettingService, SettingService>();
builder.Services.AddTransient<IRepoUnit, RepoUnit>();
builder.Services.AddTransient<IService, Service>();
builder.Services.AddTransient<IScanner, Scanner>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All });
app.Use(async (context, next) =>
{
    var forwardedPath = context.Request.Headers["X-Forwarded-Path"].FirstOrDefault();
    if (!string.IsNullOrEmpty(forwardedPath))
    {
        context.Request.PathBase = forwardedPath;
    }

    await next();
});
app.UseCors(AllowAllHeadersPolicy);
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
