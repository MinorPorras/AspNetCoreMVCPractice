using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Models;

[Table("Appointment_Types")]
[Index("Name", Name = "UQ__Appointm__737584F6A4108FFB", IsUnique = true)]
[Index("Code", Name = "UQ__Appointm__A25C5AA782F0FD5D", IsUnique = true)]
public partial class AppointmentType
{
    [Key]
    public int Id { get; set; }

    [StringLength(60)]
    public string Code { get; set; } = null!;

    [StringLength(30)]
    public string Name { get; set; } = null!;

    public bool Status { get; set; }

    [InverseProperty("AppointmentTypes")]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
