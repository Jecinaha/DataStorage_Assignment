﻿using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class CustomerFactory
{
    public static CustomerRegistrationForm Create() => new();

    public static CustomerEntity Create(CustomerRegistrationForm form) => new()
    {
        CustomerName = form.CustomerName,
    };

    public static Customer Create(CustomerEntity entity) => new()
    {
        Id = entity.Id,
        CustomerName = entity.CustomerName,

    };

    public static CustomerEntity Create(CustomerEntity CustomerEntity, CustomerUpdateForm updateForm) => new()
    {
        Id = CustomerEntity.Id,
        CustomerName = updateForm.CustomerName,
     
    };


}
