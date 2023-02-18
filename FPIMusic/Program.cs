using FPIMusic;
using FPIMusic.DataAccess;
using FPIMusic.Services;
using FPIMusic.Services.Hub;
using FPIMusic.Services.Player;
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
builder.Services.AddDbContext<FPIMusicRepository>(options => options.UseSqlite("Data Source = FPIMusic.db"),ServiceLifetime.Singleton);
builder.Services.AddSingleton<ISettingsRepository, SettingsRepository>();
builder.Services.AddSingleton<ISettingService, SettingService>();
builder.Services.AddSingleton<IRepoUnit, RepoUnit>();
builder.Services.AddSingleton<IService, Service>();
builder.Services.AddSingleton<IScanner, Scanner>();
builder.Services.AddSingleton<IPlayerService, PlayerService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

var app = builder.Build();
var appInitializator = new AppInitializator();
appInitializator.CreateDbIfNotExists(app);
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
app.MapHub<MessageHub>("/synchro");

app.MapControllers();

app.Run();
