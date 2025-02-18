using System.Linq.Expressions;
using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces
{
    public interface ICustomerContactsService
    {
        Task<CustomerContacts> CreateCustomerContactsAsync(CustomerContactsRegistrationForm form);
        Task<bool> DeleteCustomerContactsAsync(int id);
        Task<IEnumerable<CustomerContacts>> GetAllCustomerContactsAsync();
        Task<CustomerContacts> GetCustomerContactByIdAsync(Expression<Func<CustomerContactsEntity, bool>> expression);
        Task<CustomerContacts> UpdateCustomerContactsAsync(CustomerContactsUpdateForm form);
    }
}