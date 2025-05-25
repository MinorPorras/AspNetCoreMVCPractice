using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Models;

public partial class Role
{
    [Key]
    public int Id { get; set; }

    [StringLength(30)]
    public string Name { get; set; } = null!;

    public bool Status { get; set; }

    [InverseProperty("Roles")]
    public virtual ICollection<AppUser> AppUsers { get; set; } = new List<AppUser>();
}
