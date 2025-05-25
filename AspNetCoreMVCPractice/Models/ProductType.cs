using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Models;

[Table("Product_Types")]
[Index("Name", Name = "UQ__Product___737584F6FCD0E9BB", IsUnique = true)]
[Index("Code", Name = "UQ__Product___A25C5AA7B732034C", IsUnique = true)]
public partial class ProductType
{
    [Key]
    public int Id { get; set; }

    [StringLength(60)]
    public string Code { get; set; } = null!;

    [StringLength(50)]
    public string Name { get; set; } = null!;

    public bool Status { get; set; }

    [InverseProperty("ProductTypes")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
