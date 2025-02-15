

using Business.Dtos;
using Business.Factories;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using System.Linq.Expressions;

namespace Business.Services;

public class CustomerService(ICustomerRepository customerRepository)
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<Customer> CreateCustomerAsync(CustomerRegistrationForm form)
    {
        var entity = await _customerRepository.GetAsync(x => x.CustomerName == form.CustomerName);
        entity ??= await _customerRepository.CreateAsync(CustomerFactory.Create(form));

        return CustomerFactory.Create(entity);
    }

    public async Task<IEnumerable<Customer>> GetAllCustomerAsync()
    {
        var entities = await _customerRepository.GetAllAsync();
        var customer = entities.Select(CustomerFactory.Create);
        return customer ?? [];
    }

    public async Task<Customer> GetCustomerByIdAsync(Expression<Func<CustomerEntity, bool>> expression)
    {
        var entity = await _customerRepository.GetAsync(expression);
        var customer = CustomerFactory.Create(entity);
        return customer ?? null!;
    }

    public async Task<Customer> UpdateCustomerAsync(CustomerUpdateForm form)
    {
        var entity = await _customerRepository.UpdateAsync(x => x.Id == form.Id, CustomerFactory.Create(form));
        var customer = CustomerFactory.Create(entity);
        return customer ?? null!;
    }

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        var result = await _customerRepository.DeleteAsync(x => x.Id == id);
        return result;
    }

}


