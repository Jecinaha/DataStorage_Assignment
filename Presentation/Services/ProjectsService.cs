using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services;

public class ProjectsService(IProjectsRepository projectsRepository) : IProjectsService
{
    private readonly IProjectsRepository _projectsRepository = projectsRepository;


    public async Task<IResult> CreateProjectsAsync(ProjectsForm form)
    {
        if (form == null)
            return Result.BadRequest("Project registration form is required");

        try
        {
            if (await _projectsRepository.GetAsync(x => x.Title == form.Title) != null)
                return Result.AlreadyExists("Project with this title already exists");
            var projectsEntity = ProjectsFactory.Create(form);

            var result = await _projectsRepository.CreateAsync(projectsEntity);
            return result != null ? Result.Ok() : Result.BadRequest("Project registration failed");
        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Result.BadRequest("Project registration failed");

        }
    }

    public async Task<Result<IEnumerable<Project>>> GetAllProjectsAsync()
    {
        var projectsEntity = await _projectsRepository.GetAllAsync();
        var projects = projectsEntity?.Select(ProjectsFactory.Create);
        return Result<IEnumerable<Project>>.Ok(projects);
    }

    public async Task<IResult> GetProjectsByIdAsync(int id)
    {
        var projectsEntity = await _projectsRepository.GetAsync(x => x.Id == id);

        if (projectsEntity == null)
            return Result.NotFound("Projects not found");

        var projects = ProjectsFactory.Create(projectsEntity);
        return Result<Project>.Ok(projects);
    }

    public async Task<IResult> GetProjectsByTitleAsync(string title)
    {
        var projectsEntity = await _projectsRepository.GetAsync(x => x.Title == title);

        if (projectsEntity == null)
            return Result.NotFound("Project not found");

        var projects = ProjectsFactory.Create(projectsEntity);
        return Result<Project>.Ok(projects);
    }
    public async Task<IResult> UpdateProjectsAsync(int id, ProjectsForm updateForm)
    {
        var projectsEntity = await _projectsRepository.GetAsync(x => x.Id == id);
        if (projectsEntity == null)
            return Result.NotFound("Project not found");

        projectsEntity = ProjectsFactory.CreateUpdate(id, updateForm);
        var result = await _projectsRepository.UpdateAsync(x => x.Id == id, projectsEntity);
        return result != null ? Result.Ok() : Result.BadRequest("Project update failed");
    }

    public async Task<IResult> DeleteProjectsAsync(int id)
    {
        var projectsEntity = await _projectsRepository.GetAsync(x => x.Id == id);
        if (projectsEntity == null)
            return Result.NotFound("Project not found");

        var result = await _projectsRepository.DeleteAsync(x => x.Id == id);
        return result ? Result.Ok() : Result.BadRequest("Projects update failed");
    }


}
