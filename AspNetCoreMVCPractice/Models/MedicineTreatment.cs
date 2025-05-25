using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Models;

[Table("Medicine_Treatments")]
[Index("Code", Name = "UQ__Medicine__A25C5AA79D476C44", IsUnique = true)]
public partial class MedicineTreatment
{
    [Key]
    public int Id { get; set; }

    [StringLength(60)]
    public string Code { get; set; } = null!;

    [Column("Treatment_Date")]
    public DateOnly? TreatmentDate { get; set; }

    [Column("Pets_Id")]
    public int PetsId { get; set; }

    [Column("Medicines_Id")]
    public int MedicinesId { get; set; }

    [StringLength(200)]
    public string Description { get; set; } = null!;

    [Column("AppUsers_Id")]
    public int AppUsersId { get; set; }

    public bool Status { get; set; }

    [ForeignKey("AppUsersId")]
    [InverseProperty("MedicineTreatments")]
    public virtual AppUser AppUsers { get; set; } = null!;

    [ForeignKey("MedicinesId")]
    [InverseProperty("MedicineTreatments")]
    public virtual Medicine Medicines { get; set; } = null!;

    [ForeignKey("PetsId")]
    [InverseProperty("MedicineTreatments")]
    public virtual Pet Pets { get; set; } = null!;
}
