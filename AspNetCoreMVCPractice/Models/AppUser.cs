using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Models;

[Index("Code", Name = "UQ__AppUsers__A25C5AA7FBEEB125", IsUnique = true)]
[Index("Email", Name = "UQ__AppUsers__A9D10534BAD98058", IsUnique = true)]
public partial class AppUser
{
    [Key]
    public int Id { get; set; }

    [StringLength(60)]
    public string Code { get; set; } = null!;

    [StringLength(60)]
    public string FullName { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [StringLength(15)]
    public string Phone { get; set; } = null!;

    [Column("Roles_Id")]
    public int RolesId { get; set; }

    public bool Status { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Appointment> AppointmentCustomers { get; set; } = new List<Appointment>();

    [InverseProperty("Vet")]
    public virtual ICollection<Appointment> AppointmentVets { get; set; } = new List<Appointment>();

    [InverseProperty("AppUsers")]
    public virtual ICollection<ClinicalProcedure> ClinicalProcedures { get; set; } = new List<ClinicalProcedure>();

    [InverseProperty("AppUsers")]
    public virtual ICollection<InventoryMovement> InventoryMovements { get; set; } = new List<InventoryMovement>();

    [InverseProperty("Customer")]
    public virtual ICollection<InvoicesMaster> InvoicesMasterCustomers { get; set; } = new List<InvoicesMaster>();

    [InverseProperty("GeneratedByNavigation")]
    public virtual ICollection<InvoicesMaster> InvoicesMasterGeneratedByNavigations { get; set; } = new List<InvoicesMaster>();

    [InverseProperty("AppUsers")]
    public virtual ICollection<MedicalHistory> MedicalHistories { get; set; } = new List<MedicalHistory>();

    [InverseProperty("AppUsers")]
    public virtual ICollection<MedicineTreatment> MedicineTreatments { get; set; } = new List<MedicineTreatment>();

    [InverseProperty("AppUsers")]
    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();

    [ForeignKey("RolesId")]
    [InverseProperty("AppUsers")]
    public virtual Role Roles { get; set; } = null!;
}
