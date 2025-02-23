using Business.Dtos;
using Business.Models;

namespace Business.Interfaces
{
    public interface IRoleService
    {
        Task<Result> CreateRoleAsync(RoleRegistrationForm form);
        Task<IResult> DeleteRoleAsync(int id);
        Task<Result<IEnumerable<Role>>> GetAllRoleAsync();
        Task<IResult> GetRoleByEmailAsync(string roleName);
        Task<IResult> GetRoleByIdAsync(int id);
        Task<IResult> UpdateRoleAsync(int id, RoleUpdateForm updateForm);
    }
}