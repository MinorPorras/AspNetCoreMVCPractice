using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Models;

[Table("Inventory_Item_Types")]
[Index("Name", Name = "UQ__Inventor__737584F649E0E832", IsUnique = true)]
public partial class InventoryItemType
{
    [Key]
    public int Id { get; set; }

    [StringLength(30)]
    public string Name { get; set; } = null!;

    [InverseProperty("ItemType")]
    public virtual ICollection<InventoryMovement> InventoryMovements { get; set; } = new List<InventoryMovement>();

    [InverseProperty("ItemType")]
    public virtual ICollection<Kardex> Kardices { get; set; } = new List<Kardex>();
}
