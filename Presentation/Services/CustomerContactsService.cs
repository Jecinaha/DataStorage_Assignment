using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Linq.Expressions;

namespace Business.Services;


public class CustomerContactsService(ICustomerContactsRepository customerContactsRepository) : ICustomerContactsService
{
    private readonly ICustomerContactsRepository _customerContactsRepository = customerContactsRepository;

    public async Task<CustomerContacts> CreateCustomerContactsAsync(CustomerContactsRegistrationForm form)
    {
        var entity = await _customerContactsRepository.GetAsync(x => x.FirstName == form.FirstName);
        entity ??= await _customerContactsRepository.CreateAsync(CustomerContactsFactory.Create(form));

        return CustomerContactsFactory.Create(entity);
    }

    public async Task<IEnumerable<CustomerContacts>> GetAllCustomerContactsAsync()
    {
        var entities = await _customerContactsRepository.GetAllAsync();
        var customerContacts = entities.Select(CustomerContactsFactory.Create);
        return customerContacts ?? [];
    }

    public async Task<CustomerContacts> GetCustomerContactByIdAsync(Expression<Func<CustomerContactsEntity, bool>> expression)
    {
        var entity = await _customerContactsRepository.GetAsync(expression);
        var customerContacts = CustomerContactsFactory.Create(entity);
        return customerContacts ?? null!;
    }

    public async Task<CustomerContacts> UpdateCustomerContactsAsync(CustomerContactsUpdateForm form)
    {
        var entity = await _customerContactsRepository.UpdateAsync(x => x.Id == form.Id, CustomerContactsFactory.Create(form));
        var customerContacts = CustomerContactsFactory.Create(entity);
        return customerContacts ?? null!;
    }

    public async Task<bool> DeleteCustomerContactsAsync(int id)
    {
        var result = await _customerContactsRepository.DeleteAsync(x => x.Id == id);
        return result;
    }
}

