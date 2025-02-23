using Data.Entities;
namespace Business.Dtos;

public class ProjectsRegistrationForm
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public StatusEntity Status { get; set; } = null!;
    public CustomerEntity Customer { get; set; } = null!;
    public ProductEntity Product { get; set; } = null!;
    public UserEntity User { get; set; } = null!;
}


 