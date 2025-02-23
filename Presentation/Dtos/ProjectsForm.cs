using Business.Models;
using Data.Entities;
namespace Business.Dtos;

public class ProjectsForm
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Status Status { get; set; } = null!;
    public Product Product { get; set; } = null!;
    public Customer Customer { get; set; } = null!;
    public User User { get; set; } = null!;
}


 