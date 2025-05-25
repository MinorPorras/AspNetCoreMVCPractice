using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Models;

[Table("Clinical_Procedures")]
[Index("Code", Name = "UQ__Clinical__A25C5AA7396C704C", IsUnique = true)]
public partial class ClinicalProcedure
{
    [Key]
    public int Id { get; set; }

    [StringLength(60)]
    public string Code { get; set; } = null!;

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(200)]
    public string? Description { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    public int? Duration { get; set; }

    [Column("AppUsers_Id")]
    public int AppUsersId { get; set; }

    public bool Status { get; set; }

    [ForeignKey("AppUsersId")]
    [InverseProperty("ClinicalProcedures")]
    public virtual AppUser AppUsers { get; set; } = null!;
}
