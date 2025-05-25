using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Models;

[Keyless]
[Table("VetSpeciality")]
public partial class VetSpeciality
{
    [Column("ID_Vet")]
    public int IdVet { get; set; }

    [Column("ID_Speciality")]
    public int IdSpeciality { get; set; }

    [ForeignKey("IdSpeciality")]
    public virtual Speciality IdSpecialityNavigation { get; set; } = null!;

    [ForeignKey("IdVet")]
    public virtual AppUser IdVetNavigation { get; set; } = null!;
}
