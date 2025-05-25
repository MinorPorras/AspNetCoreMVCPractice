using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Models;

[Table("Kardex")]
public partial class Kardex
{
    [Key]
    public int Id { get; set; }

    [Column("Item_Type_Id")]
    public int ItemTypeId { get; set; }

    [Column("Item_Id")]
    public int ItemId { get; set; }

    public int Quantity { get; set; }

    [Column("Movement_Type")]
    [StringLength(10)]
    public string MovementType { get; set; } = null!;

    [Column("Date_Of_Movement", TypeName = "datetime")]
    public DateTime DateOfMovement { get; set; }

    [StringLength(200)]
    public string? Description { get; set; }

    [Column("Previous_Stock")]
    public int PreviousStock { get; set; }

    [Column("Current_Stock")]
    public int CurrentStock { get; set; }

    [ForeignKey("ItemTypeId")]
    [InverseProperty("Kardices")]
    public virtual InventoryItemType ItemType { get; set; } = null!;
}
