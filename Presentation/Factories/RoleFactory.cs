

using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class RoleFactory
{
    public static RoleRegistrationForm Create() => new();

    public static RoleRegistrationForm Create(RoleRegistrationForm form) => new()
    {
        RoleName = form.RoleName,
     
       
    };

    public static Role Create(RoleEntity entity) => new()
    {
        Id = entity.Id,
        RoleName = entity.RoleName,
    };

    public static RoleUpdateForm Create(Role role) => new()
    {
        Id = role.Id,
        RoleName = role.RoleName,

    };

    public static RoleEntity Create(RoleUpdateForm form) => new()
    {
        Id = form.Id,
        RoleName = form.RoleName,

    };

}
