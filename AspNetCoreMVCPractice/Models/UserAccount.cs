using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMVCPractice.Models;

[Keyless]
[Table("UserAccount")]
[Index("Username", Name = "UQ__UserAcco__536C85E4E6E0C22B", IsUnique = true)]
[Index("IdUser", Name = "UQ__UserAcco__D03DEDCA10402FF8", IsUnique = true)]
public partial class UserAccount
{
    [Column("Id_User")]
    public int IdUser { get; set; }

    [StringLength(30)]
    public string Username { get; set; } = null!;

    [StringLength(255)]
    public string Password { get; set; } = null!;

    public bool Status { get; set; }

    [ForeignKey("IdUser")]
    public virtual AppUser IdUserNavigation { get; set; } = null!;
}
