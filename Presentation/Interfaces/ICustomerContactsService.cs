using Business.Dtos;
using Business.Models;

namespace Business.Interfaces
{
    public interface ICustomerContactsService
    {
        Task<Result> CreateCustomerContactsAsync(CustomerContactsRegistrationForm form);
        Task<IResult> DeleteCustomerContactsAsync(int id);
        Task<Result<IEnumerable<CustomerContacts>>> GetAllCustomerContactsAsync();
        Task<IResult> GetCustomerContactsByIdAsync(int id);
        Task<IResult> UpdateCustomerContactsAsync(int id, CustomerContactsUpdateForm updateForm);
    }
}