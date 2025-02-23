
using Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class RoleRegistrationForm
{
    public string RoleName { get; set; } = null!;
}
