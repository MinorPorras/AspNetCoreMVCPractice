using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Models;

[Index("Name", Name = "UQ__Statuses__737584F6FA3702AD", IsUnique = true)]
public partial class Status
{
    [Key]
    public int Id { get; set; }

    [StringLength(30)]
    public string Name { get; set; } = null!;

    [Column("Status")]
    public bool Status1 { get; set; }

    [InverseProperty("Statuses")]
    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
