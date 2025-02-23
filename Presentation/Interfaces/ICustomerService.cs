using System.Linq.Expressions;
using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces
{
    public interface ICustomerService
    {
        Task<Result> CreateCustomerAsync(CustomerRegistrationForm form);
        Task<Result<IEnumerable<Customer>>> GetAllCustomerAsync();
        Task<IResult> GetCustomerByIdAsync(int id);
        Task<IResult> UpdateCustomerAsync(int id, CustomerUpdateForm updateForm);

        Task<IResult> DeleteCustomerAsync(int id);
    }
}



