﻿
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Business.Dtos;

public class ProjectsUpdateForm
{
    [Key]
    [Required]
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

    
}
