using Bookstore.Data;
using Bookstore.Middleware;
using DotNetEnv;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


//logging
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/logs.txt", rollingInterval: RollingInterval.Day)
    .MinimumLevel.Information() //.Debug, .Information, .Warning, .Error, .Fatal
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

//Odata
builder.Services
    .AddControllers()
    .AddOData(options =>
{
    options.Select().Filter().OrderBy().Count().SetMaxTop(100).Expand();
});

//Connection String
Env.Load();
var connection_string = Environment.GetEnvironmentVariable("CONNECTION_STRING");


//Database
builder.Services.AddDbContext<BookstoreDB>(options =>
    options.UseSqlServer(connection_string)
);

//Authentication
builder.Services.AddDbContext<AuthDB>(options =>
    options.UseSqlServer(connection_string)
);
builder.Services.AddAuthentication();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<AuthDB>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseMiddleware<HandleExceptionsMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapIdentityApi<IdentityUser>();

app.MapControllers();

app.Run();
