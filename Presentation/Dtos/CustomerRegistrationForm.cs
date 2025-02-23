using Data.Entities;

namespace Business.Dtos;

public class CustomerRegistrationForm
{
    public string CustomerName { get; set; } = null!;

    public ICollection<ProjectsEntity> Projects { get; set; } = [];

    public ICollection<CustomerContactsEntity> Contacts { get; set; } = [];


}





