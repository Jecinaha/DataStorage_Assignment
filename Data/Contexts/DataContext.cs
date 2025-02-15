
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext(DbContextOptions options) : DbContext(options)
{

    public DbSet<CustomerContactsEntity> Contacts { get; set; } = null!;

    public DbSet<CustomerEntity> Customers { get; set; } = null!;

    public DbSet<ProductEntity> Products { get; set; } = null!;

    public DbSet<ProjectsEntity> Projects { get; set; } = null!;

    public DbSet<RoleEntity> Roles { get; set; } = null!;

    public DbSet<StatusEntity> Status { get; set; } = null!;

    public DbSet<UserEntity> Users { get; set; } = null!;

}
