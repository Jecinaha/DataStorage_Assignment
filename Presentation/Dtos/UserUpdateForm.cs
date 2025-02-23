
using Data.Entities;

namespace Business.Dtos;

public class UserUpdateForm
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public ICollection<ProjectsEntity> Projects { get; set; } = [];
    public RoleEntity Role { get; set; } = null!;

}
