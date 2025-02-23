using Business.Dtos;

namespace Business.Interfaces
{
    public interface IProjectsService
    {
        Task<IResult> CreateProjectsAsync(ProjectsRegistrationForm form);
        Task<IResult> DeleteProjectsAsync(int id);
        Task<IResult> GetAllProjectsAsync();
        Task<IResult> GetProjectsByTitleAsync(string email);
        Task<IResult> GetProjectsByIdAsync(int id);
        Task<IResult> UpdateProjectsAsync(int id, ProjectsUpdateForm updateForm);
    }
}