using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Models;

[Index("Code", Name = "UQ__Medicine__A25C5AA7112E99B3", IsUnique = true)]
public partial class Medicine
{
    [Key]
    public int Id { get; set; }

    [StringLength(60)]
    public string Code { get; set; } = null!;

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    public string Description { get; set; } = null!;

    public int Stock { get; set; }

    public int Min { get; set; }

    public int Max { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    public bool Status { get; set; }

    [Column("Suppliers_Id")]
    public int SuppliersId { get; set; }

    [Column("Medicine_Types_Id")]
    public int MedicineTypesId { get; set; }

    [InverseProperty("Medicines")]
    public virtual ICollection<MedicineTreatment> MedicineTreatments { get; set; } = new List<MedicineTreatment>();

    [ForeignKey("MedicineTypesId")]
    [InverseProperty("Medicines")]
    public virtual MedicineType MedicineTypes { get; set; } = null!;

    [ForeignKey("SuppliersId")]
    [InverseProperty("Medicines")]
    public virtual Supplier Suppliers { get; set; } = null!;
}
