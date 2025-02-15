

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Data.Entities;

public class ProjectsEntity
{

    [Key]
    public int Id { get; set; }


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

    public int StatusId { get; set; }
    public StatusEntity Status { get; set; } = null!;

    public int CustumerId { get; set; }
    public CustomerEntity Custumer { get; set; } = null!;

    public int ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;

    public int UserId { get; set; }
    public UserEntity User { get; set; } = null!;


}
