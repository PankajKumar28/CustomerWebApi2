using BusinessLib;
using DataLib.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SharedLib;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var configurationBuilder = new ConfigurationBuilder().SetBasePath().AddJsonFile("appsettings.json").AddEnvironmentVariables();
string codeBase = Assembly.GetExecutingAssembly().CodeBase;
UriBuilder uri = new UriBuilder(codeBase);
string path = Uri.UnescapeDataString(uri.Path);
string directory = Path.GetDirectoryName(path);
builder.Services.AddDbContext<DBContextProvider>(options =>
        { options.UseSqlite($"Data Source={directory}/data.db"); });

builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen();

var app = builder.Build();

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
