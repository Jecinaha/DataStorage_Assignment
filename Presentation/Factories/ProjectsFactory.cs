using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ProjectsFactory
{
    public static ProjectsEntity Create(ProjectsForm form) => new()
    {
        Title = form.Title,
        Description = form.Description,
        StartDate = form.StartDate,
        EndDate = form.EndDate,
        CustomerId = form.Customer?.Id,
        UserId = form.User?.Id,
        ProductId = form.Product?.Id,
        StatusId = form.Status?.Id
    };

    public static Project Create(ProjectsEntity entity) => new()
    {
        Id = entity.Id,
        Title = entity.Title,
        Description = entity.Description,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,
        Status = entity.Status != null ? StatusFactory.Create(entity.Status) : null,
        Customer = entity.Customer != null ? CustomerFactory.Create(entity.Customer) : null,
        Product = entity.Product != null ? ProductFactory.Create(entity.Product) : null,
        User = entity.User != null ? UserFactory.Create(entity.User) : null,

    };

    public static ProjectsEntity CreateUpdate(int id, ProjectsForm updateForm) => new()
    {
        Id = id,
        Title = updateForm.Title,
        Description = updateForm.Description,
        StartDate = updateForm.StartDate,
        EndDate = updateForm.EndDate,
        StatusId = updateForm.Status?.Id,
        CustomerId = updateForm.Customer?.Id,
        ProductId = updateForm.Product?.Id,
        UserId = updateForm.User?.Id
    };

    public static ProjectsForm Create() => new();
}