using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Models;

[Table("Invoices_Master")]
[Index("InvoiceNumber", Name = "UQ__Invoices__541A9040050A0436", IsUnique = true)]
public partial class InvoicesMaster
{
    [Key]
    public int Id { get; set; }

    [Column("Invoice_Number")]
    [StringLength(30)]
    public string InvoiceNumber { get; set; } = null!;

    [Column("Invoice_Date", TypeName = "datetime")]
    public DateTime InvoiceDate { get; set; }

    [Column("Total_Amount", TypeName = "decimal(10, 2)")]
    public decimal TotalAmount { get; set; }

    [Column("Customer_Id")]
    public int CustomerId { get; set; }

    [Column("Generated_By")]
    public int GeneratedBy { get; set; }

    [Column("Payment_Methods_Id")]
    public int PaymentMethodsId { get; set; }

    public bool Status { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("InvoicesMasterCustomers")]
    public virtual AppUser Customer { get; set; } = null!;

    [ForeignKey("GeneratedBy")]
    [InverseProperty("InvoicesMasterGeneratedByNavigations")]
    public virtual AppUser GeneratedByNavigation { get; set; } = null!;

    [InverseProperty("InvoicesMaster")]
    public virtual ICollection<InvoicesDetail> InvoicesDetails { get; set; } = new List<InvoicesDetail>();

    [ForeignKey("PaymentMethodsId")]
    [InverseProperty("InvoicesMasters")]
    public virtual PaymentMethod PaymentMethods { get; set; } = null!;
}
