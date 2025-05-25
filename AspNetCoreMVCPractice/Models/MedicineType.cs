using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Models;

[Table("Medicine_Types")]
[Index("Name", Name = "UQ__Medicine__737584F6C34D005D", IsUnique = true)]
[Index("Code", Name = "UQ__Medicine__A25C5AA70C46538C", IsUnique = true)]
public partial class MedicineType
{
    [Key]
    public int Id { get; set; }

    [StringLength(60)]
    public string Code { get; set; } = null!;

    [StringLength(50)]
    public string Name { get; set; } = null!;

    public bool Status { get; set; }

    [InverseProperty("MedicineTypes")]
    public virtual ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();
}
