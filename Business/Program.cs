using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Data.Interfaces;
using Business.Interfaces;
using System.Text.Json;
using System.Text.Encodings.Web;

JsonSerializerOptions options = new()
{
    WriteIndented = true,
    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles,
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
};


var services = new ServiceCollection()
.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\projectc#\DataStorage_Assignment\Data\DataBases\DataBase.mdf;Integrated Security=True;Connect Timeout=30"))
.AddScoped<ICustomerRepository>()
.AddScoped<IProjectsRepository>()
.AddScoped<IUserRepository>()
.AddScoped<ICustomerService>()
.AddScoped<IProjectsService>()
.AddScoped<IUserService>();

var serviceProvider = services.BuildServiceProvider();

var customerService = serviceProvider.GetRequiredService<ICustomerService>();
var customer = await customerService.GetAllCustomerAsync();




