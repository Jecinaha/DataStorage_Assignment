
using System.ComponentModel.DataAnnotations;
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


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectsEntity>()
            .HasKey(x => new { x.Id, x.StatusId, x.CustomerId, x.ProductId, x.UserId });

        modelBuilder.Entity<ProjectsEntity>()
            .HasOne(x => x.Status)
            .WithMany()
            .HasForeignKey(x => x.StatusId);
        modelBuilder.Entity<ProjectsEntity>()
            .HasOne(x => x.Customer)
            .WithMany()
            .HasForeignKey(x => x.CustomerId);
        modelBuilder.Entity<ProjectsEntity>()
            .HasOne(x => x.Product)
            .WithMany()
            .HasForeignKey(x => x.ProductId);
        modelBuilder.Entity<ProjectsEntity>()
            .HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CustomerEntity>()
            .HasKey(x => new { x.Id, x.CustomerContactsId});

        modelBuilder.Entity<CustomerEntity>()
           .HasOne(x => x.CustomerContacts)
           .WithMany()
           .HasForeignKey(x => x.CustomerContactsId);
   
        base.OnModelCreating(modelBuilder);

    }
}

