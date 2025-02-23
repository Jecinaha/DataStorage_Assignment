using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ProjectsFactory
{
    public static ProjectsEntity Create(ProjectsRegistrationForm form) => new()
    {
        Title = form.Title,
        Description = form.Description,
        StartDate = form.StartDate,
        EndDate = form.EndDate,
    };

    public static Projects Create(ProjectsEntity entity) => new()
    {
        Id = entity.Id,
        Title = entity.Title,
        Description = entity.Description,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,
        Status = StatusFactory.Create(entity.Status),
        Customer = CustomerFactory.Create(entity.Customer),
        Product = ProductFactory.Create(entity.Product),
        User = UserFactory.Create(entity.User)

    };

    public static ProjectsEntity Create(ProjectsEntity projectsEntity, ProjectsUpdateForm updateForm) => new()
    {
            Id = projectsEntity.Id,
            Title = projectsEntity.Title,
            Description = projectsEntity.Description,
            StartDate = projectsEntity.StartDate,
            EndDate = projectsEntity.EndDate,
            Status = projectsEntity.Status,
            Customer = projectsEntity.Customer,
            Product = projectsEntity.Product,
            User = projectsEntity.User

    };
 }