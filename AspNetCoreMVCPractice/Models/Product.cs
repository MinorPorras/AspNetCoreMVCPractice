using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Models;

[Index("Code", Name = "UQ__Products__A25C5AA7055031BC", IsUnique = true)]
public partial class Product
{
    [Key]
    public int Id { get; set; }

    [StringLength(60)]
    public string Code { get; set; } = null!;

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    public string Description { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    public int Stock { get; set; }

    public int Min { get; set; }

    public int Max { get; set; }

    public bool Status { get; set; }

    [Column("Product_Types_Id")]
    public int ProductTypesId { get; set; }

    [Column("Suppliers_Id")]
    public int SuppliersId { get; set; }

    [ForeignKey("ProductTypesId")]
    [InverseProperty("Products")]
    public virtual ProductType ProductTypes { get; set; } = null!;

    [ForeignKey("SuppliersId")]
    [InverseProperty("Products")]
    public virtual Supplier Suppliers { get; set; } = null!;
}
