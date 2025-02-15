
using Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class CustomerRegistrationForm
{
    [Required]
    [Column(TypeName = "nvarchar(150)")]
    public string CustomerName { get; set; } = null!;

}
