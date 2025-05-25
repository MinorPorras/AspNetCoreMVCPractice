using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Models;

[Table("Invoices_Detail")]
public partial class InvoicesDetail
{
    [Key]
    public int Id { get; set; }

    [Column("Invoices_Master_Id")]
    public int InvoicesMasterId { get; set; }

    [Column("Item_Type_Id")]
    public int ItemTypeId { get; set; }

    [Column("Item_Id")]
    public int ItemId { get; set; }

    public int Quantity { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [ForeignKey("InvoicesMasterId")]
    [InverseProperty("InvoicesDetails")]
    public virtual InvoicesMaster InvoicesMaster { get; set; } = null!;

    [ForeignKey("ItemTypeId")]
    [InverseProperty("InvoicesDetails")]
    public virtual ItemType ItemType { get; set; } = null!;
}
