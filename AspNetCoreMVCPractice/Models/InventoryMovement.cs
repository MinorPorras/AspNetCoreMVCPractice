using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Models;

[Table("Inventory_Movements")]
[Index("Code", Name = "UQ__Inventor__A25C5AA745659D0E", IsUnique = true)]
public partial class InventoryMovement
{
    [Key]
    public int Id { get; set; }

    [StringLength(60)]
    public string Code { get; set; } = null!;

    [Column("Date_Of_Movement", TypeName = "datetime")]
    public DateTime DateOfMovement { get; set; }

    [Column("Item_Type_Id")]
    public int ItemTypeId { get; set; }

    [Column("Item_Id")]
    public int ItemId { get; set; }

    [Column("Movement_Type")]
    [StringLength(10)]
    public string MovementType { get; set; } = null!;

    public int Quantity { get; set; }

    [Column("Suppliers_Id")]
    public int SuppliersId { get; set; }

    [Column("AppUsers_Id")]
    public int AppUsersId { get; set; }

    [ForeignKey("AppUsersId")]
    [InverseProperty("InventoryMovements")]
    public virtual AppUser AppUsers { get; set; } = null!;

    [ForeignKey("ItemTypeId")]
    [InverseProperty("InventoryMovements")]
    public virtual InventoryItemType ItemType { get; set; } = null!;

    [ForeignKey("SuppliersId")]
    [InverseProperty("InventoryMovements")]
    public virtual Supplier Suppliers { get; set; } = null!;
}
