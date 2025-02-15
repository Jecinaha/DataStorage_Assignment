
using Business.Dtos;
using Business.Factories;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Data;
using System.Linq.Expressions;

namespace Business.Services;

public class RoleService(IRoleRepository roleRepository)
{
    private readonly IRoleRepository _roleRepository = roleRepository;

    public async Task<Role> CreateRoleAsync(RoleRegistrationForm form)
    {
        var entity = await _roleRepository.GetAsync(x => x.RoleName == form.RoleName);
        entity ??= await _roleRepository.CreateAsync(RoleFactory.Create(form));

        return RoleFactory.Create(entity);
    }

    public async Task<IEnumerable<Role>> GetAllRoleAsync()
    {
        var entities = await _roleRepository.GetAllAsync();
        var role = entities.Select(RoleFactory.Create);
        return role ?? Enumerable.Empty<Role>();
    }

    public async Task<Role> GetRoleAsync(Expression<Func<RoleEntity, bool>> expression)
    {
        var entity = await _roleRepository.GetAsync(expression);
        var role = RoleFactory.Create(entity);
        return role ?? null!;
    }

    public async Task<Role> UpdateRoleAsync(RoleUpdateForm form)
    {
        var entity = await _roleRepository.UpdateAsync(RoleFactory.Create(form));
        var role = RoleFactory.Create(entity);
        return role ?? null!;
    }

    public async Task<bool> DeleteRoleAsync(int id)
    {
        var result = await _roleRepository.DeleteAsync(x => x.Id == id);
        return result;
    }
}


