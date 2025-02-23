using Data.Entities;

namespace Business.Dtos;

public class CustomerContactsUpdateForm
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int CustomerId { get; set; }

    public CustomerEntity Customer { get; set; } = null!;
}


