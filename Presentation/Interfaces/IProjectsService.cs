using System.Linq.Expressions;
using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces
{
    public interface IProjectsService
    {
        Task<Projects> CreateProjectsAsync(ProjectsRegistrationForm form);
        Task<bool> DeleteProjectsAsync(int id);
        Task<IEnumerable<Projects>> GetAllProjectsAsync();
        Task<Projects> GetProjectAsync(Expression<Func<ProjectsEntity, bool>> expression);
        Task<Projects> UpdateProjectsAsync(ProjectsUpdateForm form);
    }
}