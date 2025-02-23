using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using System.Linq.Expressions;

namespace Business.Services;

public class CustomerContactsService(ICustomerContactsRepository customerContactsRepository) : ICustomerContactsService
{
    private readonly ICustomerContactsRepository _customerContactsRepository = customerContactsRepository;

    public async Task<Result> CreateCustomerContactsAsync(CustomerContactsRegistrationForm form)
    {
        if (form == null)
            return Result.BadRequest("Contact registration form is required");

        try
        {
            if (await _customerContactsRepository.GetAsync(x => ((CustomerContactsEntity)x).FirstName == form.FirstName) != null)
                return Result.AlreadyExists("Contact with this email already exists");

            var customerContactsEntity = CustomerContactsFactory.Create(form);

            var result = await _customerContactsRepository.CreateAsync(customerContactsEntity);

            return result != null ? Result.Ok() : Result.BadRequest("Contact registration failed");
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Result.BadRequest("Contact registration failed");

        }
    }
    public async Task<Result<IEnumerable<CustomerContacts>>> GetAllCustomerContactsAsync()
    {
        var customerContactsEntities = await _customerContactsRepository.GetAllAsync();
        var customerContacts = customerContactsEntities?.Select(CustomerContactsFactory.Create);
        return Result<IEnumerable<CustomerContacts>>.Ok(customerContacts);
    }

    public async Task<IResult> GetCustomerContactsByIdAsync(int id)
    {
        var customerContactsEntity = await _customerContactsRepository.GetAsync(x => x.Id == id);

        if (customerContactsEntity == null)
            return Result.NotFound("Customer not found");

        var customerContacts = CustomerContactsFactory.Create(customerContactsEntity);
        return Result<CustomerContacts>.Ok(customerContacts);
    }

    public async Task<IResult> UpdateCustomerContactsAsync(int id, CustomerContactsUpdateForm updateForm)
    {
        var CustomerContactsEntity = await _customerContactsRepository.GetAsync(x => x.Id == id);
        if (CustomerContactsEntity == null)
            return Result.NotFound("Customer not found");

        CustomerContactsEntity = CustomerContactsFactory.Create(CustomerContactsEntity, updateForm);
        var result = await _customerContactsRepository.UpdateAsync(x => x.Id == id, CustomerContactsEntity);
        return result != null ? Result.Ok() : Result.BadRequest("Contact update failed");

    }

    public async Task<IResult> DeleteCustomerContactsAsync(int id)
    {
        var customerContactsEntity = await _customerContactsRepository.GetAsync(x => x.Id == id);
        if (customerContactsEntity == null)
            return Result.NotFound("Contact not found");

        var result = await _customerContactsRepository.DeleteAsync(x => x.Id == id);
        return result ? Result.Ok() : Result.BadRequest("Contact update failed");
    }
}
