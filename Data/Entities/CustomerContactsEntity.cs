
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class CustomerContactsEntity
{
    [Key]
    public int Id { get; set; } // Primary Key

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string FirstName { get; set; } = null!;

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string LastName { get; set; } = null!;


    public int CustomerId { get; set; } // Foreign Key

    public virtual CustomerEntity Customer { get; set; } = null!;




}
