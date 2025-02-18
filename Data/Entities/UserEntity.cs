
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class UserEntity

{
    [Key]
    public int Id { get; set; } // Primary Key

    public int RoleId { get; set; } // Foreign Key

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string FirstName { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string LastName { get; set; } = null!;

    [Required]
    [Column(TypeName = "varchar(150)")]
    public string Email { get; set; } = null!;

    public virtual ICollection<ProjectsEntity> Projects { get; set; } = [];

    public virtual RoleEntity Role { get; set; } = null!;

}