using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class RoleFactory
{
        public static RoleRegistrationForm Create() => new();

        public static RoleEntity Create(RoleRegistrationForm form) => new()
        {
            RoleName = form.RoleName,

        };

        public static Role Create(RoleEntity entity) => new()
        {
            Id = entity.Id,
            RoleName = entity.RoleName,

        };

        public static RoleEntity Create(RoleEntity roleEntity, RoleUpdateForm updateForm) => new()
        {
            Id = roleEntity.Id,
            RoleName = updateForm.RoleName,

        };


    }
