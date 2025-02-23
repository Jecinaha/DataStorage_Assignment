

using Data.Entities;

namespace Business.Dtos;

public class CustomerUpdateForm
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = null!;

    public ICollection<ProjectsEntity> Projects { get; set; } = [];

    public ICollection<CustomerContactsEntity> Contacts { get; set; } = [];

   

}
