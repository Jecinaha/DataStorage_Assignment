using System.Linq.Expressions;
using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomerAsync(CustomerRegistrationForm form);
        Task<bool> DeleteCustomerAsync(int id);
        Task<IEnumerable<Customer>> GetAllCustomerAsync();
        Task<Customer> GetCustomerByIdAsync(Expression<Func<CustomerEntity, bool>> expression);
        Task<Customer> UpdateCustomerAsync(CustomerUpdateForm form);
    }
}