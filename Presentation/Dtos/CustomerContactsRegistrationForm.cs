using Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class CustomerContactsRegistrationForm
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int CustomerId { get; set; }

    public CustomerEntity Customer { get; set; } = null!;


}
