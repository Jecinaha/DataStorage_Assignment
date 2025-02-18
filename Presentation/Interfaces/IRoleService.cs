using System.Linq.Expressions;
using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces
{
    public interface IRoleService
    {
        Task<Role> CreateRoleAsync(RoleRegistrationForm form);
        Task<bool> DeleteRoleAsync(int id);
        Task<IEnumerable<Role>> GetAllRoleAsync();
        Task<Role> GetRoleAsync(Expression<Func<RoleEntity, bool>> expression);
        Task<Role> UpdateRoleAsync(RoleUpdateForm form);
    }
}