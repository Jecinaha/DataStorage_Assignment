using Business.Dtos;
using Business.Models;

namespace Business.Interfaces
{
    public interface IStatusService
    {
        Task<IResult> CreateDefaultStatuses();
        Task<Result> CreateStatusAsync(StatusRegistrationForm form);
        Task<IResult> DeleteStatusAsync(int id);
        Task<Result<IEnumerable<Status>>> GetAllStatusAsync();
        Task<IResult> GetStatusByIdAsync(int id);
        Task<IResult> UpdateStatusAsync(int id, StatusUpdateForm updateForm);
    }
}