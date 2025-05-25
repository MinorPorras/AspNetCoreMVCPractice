using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Models;

[Table("Item_Types")]
[Index("Name", Name = "UQ__Item_Typ__737584F6A0E6ED0F", IsUnique = true)]
public partial class ItemType
{
    [Key]
    public int Id { get; set; }

    [StringLength(30)]
    public string Name { get; set; } = null!;

    [InverseProperty("ItemType")]
    public virtual ICollection<InvoicesDetail> InvoicesDetails { get; set; } = new List<InvoicesDetail>();
}
