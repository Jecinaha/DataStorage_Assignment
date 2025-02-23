using Business.Dtos;
using Business.Models;

namespace Business.Interfaces
{
    public interface IUserService
    {
        Task<Result> CreateUserAsync(UserRegistrationForm form);
        Task<IResult> DeleteUserAsync(int id);
        Task<Result<IEnumerable<User>>> GetAllUsersAsync();
        Task<IResult> GetUserByEmailAsync(string email);
        Task<IResult> GetUsersByIdAsync(int id);
        Task<IResult> UpdateUserAsync(int id, UserUpdateForm updateForm);
    }
}