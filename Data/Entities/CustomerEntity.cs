
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class CustomerEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(150)")]
    public string CustomerName { get; set; } = null!;

    public ICollection<CustomerContactsEntity> Contacts { get; set; } = [];

    public ICollection<ProjectsEntity> Projects { get; set; } = [];
}

