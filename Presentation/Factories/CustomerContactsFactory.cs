using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class CustomerContactsFactory
{

    public static CustomerContactsRegistrationForm Create(int customerContactsId) => new();

    public static CustomerContactsEntity Create(CustomerContactsRegistrationForm form) => new()
    {
        FirstName = form.FirstName,
        LastName = form.LastName,
    };

    public static CustomerContacts Create(CustomerContactsEntity entity) => new()
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        LastName = entity.LastName,
    };

    public static CustomerContactsEntity Create(CustomerContactsEntity customerContactsEntity, CustomerContactsUpdateForm updateForm) => new()
    {
        Id = customerContactsEntity.Id,
        FirstName = updateForm.FirstName,
        LastName = updateForm.LastName,
    };
}
