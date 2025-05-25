using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Models;

[Table("Payment_Methods")]
[Index("Name", Name = "UQ__Payment___737584F642BFCD58", IsUnique = true)]
[Index("Code", Name = "UQ__Payment___A25C5AA7DEC0AFE1", IsUnique = true)]
public partial class PaymentMethod
{
    [Key]
    public int Id { get; set; }

    [StringLength(60)]
    public string Code { get; set; } = null!;

    [StringLength(50)]
    public string Name { get; set; } = null!;

    public bool Status { get; set; }

    [InverseProperty("PaymentMethods")]
    public virtual ICollection<InvoicesMaster> InvoicesMasters { get; set; } = new List<InvoicesMaster>();
}
