
using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Linq.Expressions;

namespace Business.Services;

public class StatusService(IStatusRepository statusRepository) : IStatusService
{
    private readonly IStatusRepository _statusRepository = statusRepository;

    public async Task<Result> CreateStatusAsync(StatusRegistrationForm form)
    {
        if (form == null)
            return Result.BadRequest("Status registration form is required");

        try
        {
            if (await _statusRepository.GetAsync(x => ((StatusEntity)x).StatusName == form.StatusName) != null)
                return Result.AlreadyExists("Status with this email already exists");

            var statusEntity = StatusFactory.Create(form);

            var result = await _statusRepository.CreateAsync(statusEntity);
            return result != null ? Result.Ok() : Result.BadRequest("Status registration failed");
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Result.BadRequest("Status registration failed");

        }
    }

    public async Task<Result<IEnumerable<Status>>> GetAllStatusAsync()
    {
        var statusEntities = await _statusRepository.GetAllAsync();
        var status = statusEntities?.Select(StatusFactory.Create);
        return Result<IEnumerable<Status>>.Ok(status);
    }

    public async Task<IResult> GetStatusByIdAsync(int id)
    {
        var statusEntity = await _statusRepository.GetAsync(x => x.Id == id);

        if (statusEntity == null)
            return Result.NotFound("Status not found");

        var status = StatusFactory.Create(statusEntity);
        return Result<Status>.Ok(status);
    }

    public async Task<IResult> UpdateStatusAsync(int id, StatusUpdateForm updateForm)
    {
        var statusEntity = await _statusRepository.GetAsync(x => x.Id == id);
        if (statusEntity == null)
            return Result.NotFound("Status not found");

        statusEntity = StatusFactory.Create(statusEntity, updateForm);
        var result = await _statusRepository.UpdateAsync(x => x.Id == id, statusEntity);
        return result != null ? Result.Ok() : Result.BadRequest("Status update failed");
    }

    public async Task<IResult> DeleteStatusAsync(int id)
    {
        var statusEntity = await _statusRepository.GetAsync(x => x.Id == id);
        if (statusEntity == null)
            return Result.NotFound("Status not found");

        var result = await _statusRepository.DeleteAsync(x => x.Id == id);
        return result ? Result.Ok() : Result.BadRequest("Status update failed");
    }


}
