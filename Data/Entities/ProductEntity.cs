
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProductEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(150)")]
    public string ProductName { get; set; } = null!;

    [Required]
    [Column (TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    public virtual ICollection<ProjectsEntity> Projects { get; set; } = [];
}
