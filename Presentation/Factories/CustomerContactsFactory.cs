

using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class CustomerContactsFactory
{
    public static CustomerContactsRegistrationForm Create() => new();

    public static CustomerContactsRegistrationForm Create(CustomerContactsRegistrationForm form) => new()
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

    public static CustomerContactsUpdateForm Create(CustomerContacts customerContacts) => new()
    {
        Id = customerContacts.Id,
        FirstName = customerContacts.FirstName,
        LastName = customerContacts.LastName,


    };

    public static CustomerContactsEntity Create(CustomerContactsUpdateForm form) => new()
    {
        Id = form.Id,
        FirstName = form.FirstName,
        LastName = form.LastName,
    };

}
