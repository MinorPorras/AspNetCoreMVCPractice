using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Models;

[Index("Code", Name = "UQ__Pets__A25C5AA7A4BE0556", IsUnique = true)]
public partial class Pet
{
    [Key]
    public int Id { get; set; }

    [StringLength(60)]
    public string Code { get; set; } = null!;

    [StringLength(40)]
    public string Name { get; set; } = null!;

    [Column("Birth_Date")]
    public DateOnly? BirthDate { get; set; }

    [Column("Species_Id")]
    public int SpeciesId { get; set; }

    [Column("Breeds_Id")]
    public int BreedsId { get; set; }

    [Column("AppUsers_Id")]
    public int AppUsersId { get; set; }

    public bool Status { get; set; }

    [ForeignKey("AppUsersId")]
    [InverseProperty("Pets")]
    public virtual AppUser AppUsers { get; set; } = null!;

    [InverseProperty("Pets")]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    [ForeignKey("BreedsId")]
    [InverseProperty("Pets")]
    public virtual Breed Breeds { get; set; } = null!;

    [InverseProperty("Pets")]
    public virtual ICollection<MedicalHistory> MedicalHistories { get; set; } = new List<MedicalHistory>();

    [InverseProperty("Pets")]
    public virtual ICollection<MedicineTreatment> MedicineTreatments { get; set; } = new List<MedicineTreatment>();

    [ForeignKey("SpeciesId")]
    [InverseProperty("Pets")]
    public virtual Species Species { get; set; } = null!;
}
