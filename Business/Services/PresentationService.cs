using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var ServiceCollection = new ServiceCollection();

ServiceCollection.AddDbContext<DataContext>(options => options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\projectc#\DataStorage_Assignment\Data\DataBases\DataBase.mdf;Integrated Security=True;Connect Timeout=30");

var ServiceProvider = ServiceCollection.BuildServiceProvider();