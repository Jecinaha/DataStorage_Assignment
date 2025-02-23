using Data.Entities;
using Business.Models;

namespace Business.Dtos;

public class UserRegistrationForm
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public IEnumerable<ProjectsEntity> Projects { get; set; } = [];
    public Role Role { get; set; } = null!;
}

   
