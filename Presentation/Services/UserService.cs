
using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;


namespace Business.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<Result> CreateUserAsync(UserRegistrationForm form)
    {
        if (form == null)
            return Result.BadRequest("User registration form is required");

        try
        {
            if (await _userRepository.GetAsync(x => ((UserEntity)x).Email == form.Email) != null)
                return Result.AlreadyExists("User with this email already exists");

            var userEntity = UserFactory.Create(form);

            var result = await _userRepository.CreateAsync(userEntity);
            return result != null ? Result.Ok() : Result.BadRequest("User registration failed");
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Result.BadRequest("User registration failed");

        }
    }

    public async Task<Result<IEnumerable<User>>> GetAllUsersAsync()
    {
        var userEntities = await _userRepository.GetAllAsync();
        var users = userEntities?.Select(UserFactory.Create);
        return Result<IEnumerable<User>>.Ok(users);
    }

    public async Task<IResult> GetUsersByIdAsync(int id)
    {
        var userEntity = await _userRepository.GetAsync(x => x.Id == id);

        if (userEntity == null)
            return Result.NotFound("User not found");

        var user = UserFactory.Create(userEntity);
        return Result<User>.Ok(user);
    }

    public async Task<IResult> GetUserByEmailAsync(string email)
    {
        var userEntity = await _userRepository.GetAsync(x => x.Email == email);

        if (userEntity == null)
            return Result.NotFound("User not found");

        var user = UserFactory.Create(userEntity);
        return Result<User>.Ok(user);
    }
    public async Task<IResult> UpdateUserAsync(int id, UserUpdateForm updateForm)
    {
        var userEntity = await _userRepository.GetAsync(x => x.Id == id);
        if (userEntity == null)
            return Result.NotFound("User not found");

        userEntity = UserFactory.Create(userEntity, updateForm);
        var result = await _userRepository.UpdateAsync(x => x.Id == id, userEntity);
        return result != null ? Result.Ok() : Result.BadRequest("User update failed");
    }

    public async Task<IResult> DeleteUserAsync(int id)
    {
        var userEntity = await _userRepository.GetAsync(x => x.Id == id);
        if (userEntity == null)
            return Result.NotFound("User not found");

        var result = await _userRepository.DeleteAsync(x => x.Id == id);
        return result ? Result.Ok() : Result.BadRequest("User update failed");
    }

}
