using Business.Dtos;
using Business.Factories;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Linq.Expressions;

namespace Business.Services;

    public class ProjectsService(IProjectsRepository projectsRepository)
    {
        private readonly IProjectsRepository _projectsRepository = projectsRepository;

        public async Task<Projects> CreateProjectsAsync(ProjectsRegistrationForm form)
        {
            var entity = await _projectsRepository.GetAsync(x => x.Title == form.Title);
            entity ??= await _projectsRepository.CreateAsync(ProjectsFactory.Create(form));

            return ProjectsFactory.Create(entity);
        }

        public async Task<IEnumerable<Projects>> GetAllProjectsAsync()
        {
            var entities = await _projectsRepository.GetAllAsync();
            var projects = entities.Select(ProjectsFactory.Create);
            return projects ?? [];
        }

        public async Task<Projects> GetProjectAsync(Expression<Func<ProjectsEntity, bool>> expression)
        {
            var entity = await _projectsRepository.GetAsync(expression);
            var projects = ProjectsFactory.Create(entity);
            return projects ?? null!;
        }

        public async Task<Projects> UpdateProjectsAsync(ProjectsUpdateForm form)
        {
            var entity = await _projectsRepository.UpdateAsync(ProjectsFactory.Create(form));
            var project = ProjectsFactory.Create(entity);
            return project ?? null!;
        }

        public async Task<bool> DeleteProjectsAsync(int id)
        {
            var result = await _projectsRepository.DeleteAsync(x => x.Id == id);
            return result;
        }

    }
