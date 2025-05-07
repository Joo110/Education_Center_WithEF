using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data_Access.Models;

public partial class StudentGroup
{
    [Key]
    [Column("StudentGroupID")]
    public int StudentGroupId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? IsActive { get; set; }

    [Column("CreatedByUserID")]
    public int CreatedByUserId { get; set; }

    [Column("GroupID")]
    public int GroupId { get; set; }

    [Column("StudentsID")]
    public int StudentsId { get; set; }

    [ForeignKey("CreatedByUserId")]
    [InverseProperty("StudentGroups")]
    public virtual User CreatedByUser { get; set; } = null!;

    [ForeignKey("GroupId")]
    [InverseProperty("StudentGroups")]
    public virtual Group Group { get; set; } = null!;

    [InverseProperty("StudentGroup")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    [ForeignKey("StudentsId")]
    [InverseProperty("StudentGroups")]
    public virtual Student Students { get; set; } = null!;
}
