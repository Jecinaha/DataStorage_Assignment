

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Data.Entities;

public class ProjectsEntity
{

    [Key]
    public int Id { get; set; } // Primary Key

    public int StatusId { get; set; } // Foreign Key

    public int CustomerId { get; set; } // Foreign Key

    public int ProductId { get; set; } // Foreign Key

    public int UserId { get; set; } // Foreign Key

    [Required]
    [Column(TypeName = "nvarchar(150)")]
    public string Title { get; set; } = null!;

    [Required]
    public string? Description { get; set; }
    
    [Required]
    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }

    [Required]
    [Column(TypeName = "date")]
    public DateTime EndDate { get; set; }
   
    public virtual StatusEntity Status { get; set; } = null!;

    public virtual CustomerEntity Customer { get; set; } = null!;
   
    public virtual ProductEntity Product { get; set; } = null!;
   
    public virtual UserEntity User { get; set; } = null!;
}
