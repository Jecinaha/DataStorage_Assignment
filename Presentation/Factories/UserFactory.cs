
using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class UserFactory
{
    public static UserRegistrationForm Create() => new();

    public static UserEntity Create(UserRegistrationForm form) => new()
    {
        FirstName = form.FirstName,
        LastName = form.LastName,
        Email = form.Email.ToLower(),
        RoleId = form.Role.Id
    };

    public static User Create(UserEntity entity) => new()
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        LastName = entity.LastName,
        Email = entity.Email,
        Role = RoleFactory.Create(entity.Role)
    };

    public static UserEntity Create(UserEntity userEntity, UserUpdateForm updateForm) => new()
    {
        Id = userEntity.Id,
        FirstName = updateForm.FirstName,
        LastName = updateForm.LastName,
        Email = userEntity.Email,
    };


}