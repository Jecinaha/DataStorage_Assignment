using Data.Entities;

namespace Business.Models;

public class Role
{
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;

    public IEnumerable<User> Users { get; set; } = [];


}
