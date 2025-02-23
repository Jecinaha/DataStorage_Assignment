using Business.Dtos;
using Business.Models;

namespace Business.Interfaces
{
    public interface IProjectsService
    {
        Task<IResult> CreateProjectsAsync(ProjectsForm form);
        Task<IResult> DeleteProjectsAsync(int id);
        Task<Result<IEnumerable<Project>>> GetAllProjectsAsync();
        Task<IResult> GetProjectsByTitleAsync(string email);
        Task<IResult> GetProjectsByIdAsync(int id);
        Task<IResult> UpdateProjectsAsync(int id, ProjectsForm updateForm);
    }
}