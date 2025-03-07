﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class StatusEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string StatusName { get; set; } = null!;

    public virtual ICollection<ProjectsEntity> Projects { get; set; } = [];
}
