
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext(DbContextOptions options) : DbContext(options)
{

    public DbSet<CustomerContactsEntity> Contacts { get; set; }

    public DbSet<CustomerEntity> Customers { get; set; }

    public DbSet<ProductEntity> Products { get; set; }

    public DbSet<ProjectsEntity> Projects { get; set; }

    public DbSet<RoleEntity> Roles { get; set; }

    public DbSet<StatusEntity> Status { get; set; }

    public DbSet<UserEntity> Users { get; set; }

}
