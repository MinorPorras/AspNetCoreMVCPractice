using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Models;

[Index("Name", Name = "UQ__Species__737584F64A7541B5", IsUnique = true)]
public partial class Species
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [StringLength(30)]
    public string Name { get; set; } = null!;

    public bool Status { get; set; }

    [InverseProperty("Species")]
    public virtual ICollection<Breed> Breeds { get; set; } = new List<Breed>();

    [InverseProperty("Species")]
    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
}
