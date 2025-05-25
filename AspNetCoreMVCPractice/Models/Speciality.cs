using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Models;

[Table("Speciality")]
[Index("Name", Name = "UQ__Speciali__737584F6A61C7565", IsUnique = true)]
public partial class Speciality
{
    [Key]
    public int Id { get; set; }

    [StringLength(30)]
    public string Name { get; set; } = null!;
}
