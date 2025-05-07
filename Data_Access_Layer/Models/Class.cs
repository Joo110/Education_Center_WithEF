using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data_Access.Models;

public partial class Class
{
    [Key]
    [Column("classID")]
    public int ClassId { get; set; }

    [Column("classname")]
    [StringLength(50)]
    public string Classname { get; set; } = null!;

    [Column("capacity")]
    public int Capacity { get; set; }

    [StringLength(50)]
    public string? Description { get; set; }

    [InverseProperty("Class")]
    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
