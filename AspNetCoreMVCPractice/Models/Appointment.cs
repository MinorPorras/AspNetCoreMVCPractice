using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Models;

[Index("Code", Name = "UQ__Appointm__A25C5AA7B3B8B538", IsUnique = true)]
public partial class Appointment
{
    [Key]
    public int Id { get; set; }

    [StringLength(60)]
    public string Code { get; set; } = null!;

    [Column("Appointment_Date", TypeName = "datetime")]
    public DateTime AppointmentDate { get; set; }

    [StringLength(100)]
    public string Description { get; set; } = null!;

    [Column("Pets_Id")]
    public int PetsId { get; set; }

    [Column("Customer_Id")]
    public int CustomerId { get; set; }

    [Column("Vet_Id")]
    public int VetId { get; set; }

    [Column("Appointment_Types_Id")]
    public int AppointmentTypesId { get; set; }

    [Column("Statuses_Id")]
    public int StatusesId { get; set; }

    [ForeignKey("AppointmentTypesId")]
    [InverseProperty("Appointments")]
    public virtual AppointmentType AppointmentTypes { get; set; } = null!;

    [ForeignKey("CustomerId")]
    [InverseProperty("AppointmentCustomers")]
    public virtual AppUser Customer { get; set; } = null!;

    [ForeignKey("PetsId")]
    [InverseProperty("Appointments")]
    public virtual Pet Pets { get; set; } = null!;

    [ForeignKey("StatusesId")]
    [InverseProperty("Appointments")]
    public virtual Status Statuses { get; set; } = null!;

    [ForeignKey("VetId")]
    [InverseProperty("AppointmentVets")]
    public virtual AppUser Vet { get; set; } = null!;
}
