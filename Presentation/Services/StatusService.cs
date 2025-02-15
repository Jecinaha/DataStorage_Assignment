
using Business.Dtos;
using Business.Factories;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Linq.Expressions;

namespace Business.Services;

public class StatusService(IStatusRepository statusRepository)
{
    private readonly IStatusRepository _statusRepository = statusRepository;

    public async Task<Status> CreateStatusAsync(StatusRegistrationForm form)
    {
        var entity = await _statusRepository.GetAsync(x => x.StatusName == form.StatusName);
        entity ??= await _statusRepository.CreateAsync(StatusFactory.Create(form));

        return StatusFactory.Create(entity);
    }

    public async Task<IEnumerable<Status>> GetAllStatusAsync()
    {
        var entities = await _statusRepository.GetAllAsync();
        var status = entities.Select(StatusFactory.Create);
        return status ?? [];
    }

    public async Task<Status> GetStatusAsync(Expression<Func<StatusEntity, bool>> expression)
    {
        var entity = await _statusRepository.GetAsync(expression);
        var status = StatusFactory.Create(entity);
        return status ?? null!;
    }

    public async Task<Status> UpdateStatusAsync(StatusUpdateForm form)
    {
        var entity = await _statusRepository.UpdateAsync(x => x.Id == form.Id, StatusFactory.Create(form));
        var status = StatusFactory.Create(entity);
        return status ?? null!;
    }

    public async Task<bool> DeleteStatusAsync(int id)
    {
        var result = await _statusRepository.DeleteAsync(x => x.Id == id);
        return result;
    }

}
