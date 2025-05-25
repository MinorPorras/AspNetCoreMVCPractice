using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Models;

[Index("Code", Name = "UQ__Supplier__A25C5AA778480BE8", IsUnique = true)]
[Index("Email", Name = "UQ__Supplier__A9D105348780D250", IsUnique = true)]
public partial class Supplier
{
    [Key]
    public int Id { get; set; }

    [StringLength(60)]
    public string Code { get; set; } = null!;

    [Column("Supplier_Name")]
    [StringLength(50)]
    public string SupplierName { get; set; } = null!;

    [Column("Contact_Name")]
    [StringLength(50)]
    public string? ContactName { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string Phone { get; set; } = null!;

    [StringLength(200)]
    public string Address { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [StringLength(30)]
    public string? Province { get; set; }

    [StringLength(30)]
    public string? Canton { get; set; }

    [StringLength(30)]
    public string? District { get; set; }

    public bool Status { get; set; }

    [InverseProperty("Suppliers")]
    public virtual ICollection<InventoryMovement> InventoryMovements { get; set; } = new List<InventoryMovement>();

    [InverseProperty("Suppliers")]
    public virtual ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();

    [InverseProperty("Suppliers")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
