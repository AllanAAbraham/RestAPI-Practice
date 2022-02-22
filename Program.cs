using Challenge2.Interfaces;
using Challenge2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// Add dependency injection
builder.Services.AddScoped<ILeaderboardService, LeaderboardService>();

/*  Configuring redis server localhost port number
    builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:4455";
});
*/
var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
