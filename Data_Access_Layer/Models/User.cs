using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data_Access.Models;

public partial class User
{
    [Key]
    [Column("UserID")]
    public int UserId { get; set; }

    [StringLength(50)]
    public string UserName { get; set; } = null!;

    [StringLength(50)]
    public string Password { get; set; } = null!;

    public int Permissions { get; set; }

    public int IsActive { get; set; }

    [Column("PersonID")]
    public int PersonId { get; set; }

    [InverseProperty("CreatedByUser")]
    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    [InverseProperty("CreatedByUser")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    [ForeignKey("PersonId")]
    [InverseProperty("Users")]
    public virtual Person Person { get; set; } = null!;

    [InverseProperty("CreatedByUser")]
    public virtual ICollection<StudentGroup> StudentGroups { get; set; } = new List<StudentGroup>();

    [InverseProperty("CreatedByUser")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    [InverseProperty("CreatedByUser")]
    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
