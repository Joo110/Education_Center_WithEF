using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data_Access.Models;

public partial class Student
{
    [Key]
    [Column("StudentID")]
    public int StudentId { get; set; }

    [Column("CreatedByUserID")]
    public int CreatedByUserId { get; set; }

    public DateOnly? CreationDate { get; set; }

    [Column("PersonID")]
    public int PersonId { get; set; }

    [Column("GradeLevelID")]
    public int GradeLevelId { get; set; }

    [ForeignKey("CreatedByUserId")]
    [InverseProperty("Students")]
    public virtual User CreatedByUser { get; set; } = null!;

    [ForeignKey("GradeLevelId")]
    [InverseProperty("Students")]
    public virtual GradeLevel GradeLevel { get; set; } = null!;

    [ForeignKey("PersonId")]
    [InverseProperty("Students")]
    public virtual Person Person { get; set; } = null!;

    [InverseProperty("Students")]
    public virtual ICollection<StudentGroup> StudentGroups { get; set; } = new List<StudentGroup>();
}
