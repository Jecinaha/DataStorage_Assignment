
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class CustomerEntity
{
    [Key]
    public int Id { get; set; } // Primary Key


    [Required]
    [Column(TypeName = "nvarchar(150)")]
    public string CustomerName { get; set; } = null!;

    public virtual ICollection<ProjectsEntity> Projects { get; set; } = [];

    public virtual ICollection<CustomerContactsEntity> Contacts { get; set; } = [];


}
  


