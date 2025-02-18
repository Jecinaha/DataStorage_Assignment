using System.Linq.Expressions;
using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(UserRegistrationForm form);
        Task<bool> DeleteUserAsync(int id);
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserAsync(Expression<Func<UserEntity, bool>> expression);
        Task<User> UpdateUserAsync(UserUpdateForm form);
    }
}