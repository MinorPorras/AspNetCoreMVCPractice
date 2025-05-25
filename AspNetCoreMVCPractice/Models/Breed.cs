using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Models;

[Index("Name", "SpeciesId", Name = "UQ_Breeds_Name_Species", IsUnique = true)]
public partial class Breed
{
    [Key]
    public int Id { get; set; }

    [StringLength(30)]
    public string Name { get; set; } = null!;

    [Column("Species_Id")]
    public int SpeciesId { get; set; }

    public bool Status { get; set; }

    [InverseProperty("Breeds")]
    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();

    [ForeignKey("SpeciesId")]
    [InverseProperty("Breeds")]
    public virtual Species Species { get; set; } = null!;
}
