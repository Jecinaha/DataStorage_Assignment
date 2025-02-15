using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ProjectsFactory
{
    public static ProjectsRegistrationForm Create() => new();

    public static ProjectsRegistrationForm Create(ProjectsRegistrationForm form) => new()
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
    };

    public static ProjectsUpdateForm Create(Projects projects) => new()
    {
        Id = projects.Id,
        Title = projects.Title,
        Description = projects.Description,
        StartDate = projects.StartDate,
        EndDate = projects.EndDate,
    };

    public static ProjectsEntity Create(ProjectsUpdateForm form) => new()
    {
        Id = form.Id,
        Title = form.Title,
        Description = form.Description,
        StartDate = form.StartDate,
        EndDate = form.EndDate,

    };

}
