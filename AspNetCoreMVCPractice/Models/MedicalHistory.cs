using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Models;

[Table("Medical_History")]
[Index("Code", Name = "UQ__Medical___A25C5AA73E2CDA93", IsUnique = true)]
public partial class MedicalHistory
{
    [Key]
    public int Id { get; set; }

    [StringLength(60)]
    public string Code { get; set; } = null!;

    [Column("Visit_Date", TypeName = "datetime")]
    public DateTime VisitDate { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? Weight { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public decimal? Height { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public decimal? Temperature { get; set; }

    [Column("Heart_Rate")]
    public int? HeartRate { get; set; }

    [StringLength(200)]
    public string Diagnosis { get; set; } = null!;

    [StringLength(200)]
    public string Treatment { get; set; } = null!;

    [StringLength(500)]
    public string? Notes { get; set; }

    [Column("Pets_Id")]
    public int PetsId { get; set; }

    [Column("AppUsers_Id")]
    public int AppUsersId { get; set; }

    public bool Status { get; set; }

    [ForeignKey("AppUsersId")]
    [InverseProperty("MedicalHistories")]
    public virtual AppUser AppUsers { get; set; } = null!;

    [ForeignKey("PetsId")]
    [InverseProperty("MedicalHistories")]
    public virtual Pet Pets { get; set; } = null!;
}
