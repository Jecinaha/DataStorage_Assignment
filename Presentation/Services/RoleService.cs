using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;


public class RoleService(IRoleRepository roleRepository) : IRoleService
{
    private readonly IRoleRepository _roleRepository = roleRepository;

    public async Task<Result> CreateRoleAsync(RoleRegistrationForm form)
    {
        if (form == null)
            return Result.BadRequest("Role registration form is required");

        try
        {
            if (await _roleRepository.GetAsync(x => ((RoleEntity)x).RoleName == form.RoleName) != null)
                return Result.AlreadyExists("Role with this email already exists");

            var roleEntity = RoleFactory.Create(form);

            var result = await _roleRepository.CreateAsync(roleEntity);
            return result != null ? Result.Ok() : Result.BadRequest("Role registration failed");
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Result.BadRequest("Role registration failed");

        }
    }

    public async Task<Result<IEnumerable<Role>>> GetAllRoleAsync()
    {
        var roleEntities = await _roleRepository.GetAllAsync();
        var role = roleEntities?.Select(RoleFactory.Create);
        return Result<IEnumerable<Role>>.Ok(role);
    }

    public async Task<IResult> GetRoleByIdAsync(int id)
    {
        var roleEntity = await _roleRepository.GetAsync(x => x.Id == id);

        if (roleEntity == null)
            return Result.NotFound("Role not found");

        var role = RoleFactory.Create(roleEntity);
        return Result<Role>.Ok(role);
    }

    public async Task<IResult> GetRoleByEmailAsync(string roleName)
    {
        var roleEntity = await _roleRepository.GetAsync(x => x.RoleName == roleName);

        if (roleEntity == null)
            return Result.NotFound("Role not found");

        var role = RoleFactory.Create(roleEntity);
        return Result<Role>.Ok(role);
    }
    public async Task<IResult> UpdateRoleAsync(int id, RoleUpdateForm updateForm)
    {
        var roleEntity = await _roleRepository.GetAsync(x => x.Id == id);
        if (roleEntity == null)
            return Result.NotFound("Role not found");

        roleEntity = RoleFactory.Create(roleEntity, updateForm);
        var result = await _roleRepository.UpdateAsync(x => x.Id == id, roleEntity);
        return result != null ? Result.Ok() : Result.BadRequest("Role update failed");
    }

    public async Task<IResult> DeleteRoleAsync(int id)
    {
        var roleEntity = await _roleRepository.GetAsync(x => x.Id == id);
        if (roleEntity == null)
            return Result.NotFound("Role not found");

        var result = await _roleRepository.DeleteAsync(x => x.Id == id);
        return result ? Result.Ok() : Result.BadRequest("Role update failed");
    }

}

