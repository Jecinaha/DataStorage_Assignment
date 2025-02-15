

using Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class Role
{
    public int Id { get; set; }
    public string RoleName { get; set; } = null!;
}
