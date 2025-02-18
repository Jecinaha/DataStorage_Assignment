using System.Linq.Expressions;
using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces
{
    public interface IStatusService
    {
        Task<Status> CreateStatusAsync(StatusRegistrationForm form);
        Task<bool> DeleteStatusAsync(int id);
        Task<IEnumerable<Status>> GetAllStatusAsync();
        Task<Status> GetStatusAsync(Expression<Func<StatusEntity, bool>> expression);
        Task<Status> UpdateStatusAsync(StatusUpdateForm form);
    }
}