using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Data.Contexts;
using Data.Repositories;
using Business.Services;
using Business.Interfaces;
using PresentationApp;
using Data.Interfaces;

var service = new ServiceCollection()
    .AddDbContext<DataContext>(x =>
        x.UseSqlite("Data Source=database.db"))
    .AddScoped<IProjectsRepository, ProjectsRepository>()
    .AddScoped<IRoleRepository, RoleRepository>()
    .AddScoped<IProductRepository, ProductRepository>()
    .AddScoped<IUserRepository, UserRepository>()
    .AddScoped<IStatusRepository, StatusRepository>()
    .AddScoped<ICustomerRepository, CustomerRepository>()
    .AddScoped<ICustomerContactsRepository, CustomerContactsRepository>()
    .AddScoped<IProjectsService, ProjectsService>()
    .AddScoped<ICustomerService, CustomerService>()
    .AddScoped<IUserService, UserService>()
    .AddScoped<IStatusService, StatusService>()
    .AddScoped<IProductService, ProductService>()
    .AddScoped<ICustomerContactsService, CustomerContactsService>()
    .AddScoped<IRoleService, RoleService>()
    .AddScoped<IMenuDialogs, MenuDialogs>();
    
var serviceProvider = service.BuildServiceProvider();

var context = serviceProvider.GetRequiredService<DataContext>();
context.Database.Migrate();

var menuDialog = serviceProvider.GetRequiredService<IMenuDialogs>();
menuDialog.Run();





