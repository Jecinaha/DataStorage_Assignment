using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Data.Contexts;
using Data.Repositories;
using Business.Services;
using Business.Interfaces;
using PresentationApp;
using Data.Interfaces;

var service = new ServiceCollection()
    .AddDbContext<DataContext>(x => x.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\projectc#\\DataStorage_Assignment\\Data\\DataBases\\Data.mdf;Integrated Security=True;Connect Timeout=30"))
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
var menuDialog = serviceProvider.GetRequiredService<IMenuDialogs>();
menuDialog.ShowMainMenu();





