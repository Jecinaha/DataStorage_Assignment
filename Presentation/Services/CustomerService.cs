using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<Result> CreateCustomerAsync(CustomerRegistrationForm form)
    {
        if (form == null)
            return Result.BadRequest("Customer registration form is required");

        try
        {
            if (await _customerRepository.GetAsync(x => x.CustomerName == form.CustomerName) != null)
                return Result.AlreadyExists("Customer with this email already exists");

            var customerEntity = CustomerFactory.Create(form);

            var result = await _customerRepository.CreateAsync(customerEntity);

            return result != null ? Result.Ok() : Result.BadRequest("Customer registration failed");
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Result.BadRequest("Customer registration failed");

        }
    }
    public async Task<Result<IEnumerable<Customer>>> GetAllCustomerAsync()
    {
        var customereEntities = await _customerRepository.GetAllAsync();
        var customer = customereEntities?.Select(CustomerFactory.Create);
        return Result<IEnumerable<Customer>>.Ok(customer);
    }

    public async Task<IResult> GetCustomerByIdAsync(int id)
    {
        var customEntity = await _customerRepository.GetAsync(x => x.Id == id);

        if (customEntity == null)
            return Result.NotFound("Customer not found");

        var customer = CustomerFactory.Create(customEntity);
        return Result<Customer>.Ok(customer);
    }

    public async Task<IResult> UpdateCustomerAsync(int id, CustomerUpdateForm updateForm)
    {
        var CustomerEntity = await _customerRepository.GetAsync(x => x.Id == id);
        if (CustomerEntity == null)
            return Result.NotFound("Customer not found");

        CustomerEntity = CustomerFactory.Create(CustomerEntity, updateForm);
        var result = await _customerRepository.UpdateAsync(x => x.Id == id, CustomerEntity);
        return result != null ? Result.Ok() : Result.BadRequest("Customer update failed");

    }

    public async Task<IResult> DeleteCustomerAsync(int id)
    {
       var customerENtity = await _customerRepository.GetAsync(x => x.Id == id);
        if (customerENtity == null)
            return Result.NotFound("Customer not found");

        var result = await _customerRepository.DeleteAsync(x => x.Id == id);
        return result ? Result.Ok() : Result.BadRequest("Customer update failed");
    }
}
