using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data_Access.Models;

public partial class SubjectGradeLevel
{
    [Key]
    [Column("SubjectGradeLevelID")]
    public int SubjectGradeLevelId { get; set; }

    [Column(TypeName = "smallmoney")]
    public decimal Fees { get; set; }

    [StringLength(50)]
    public string? Description { get; set; }

    [Column("SubjectID")]
    public int SubjectId { get; set; }

    [Column("GradeLevelID")]
    public int GradeLevelId { get; set; }

    [ForeignKey("GradeLevelId")]
    [InverseProperty("SubjectGradeLevels")]
    public virtual GradeLevel GradeLevel { get; set; } = null!;

    [InverseProperty("SubjectGradeLevel")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    [ForeignKey("SubjectId")]
    [InverseProperty("SubjectGradeLevels")]
    public virtual Subject Subject { get; set; } = null!;

    [InverseProperty("SubjectGradeLevel")]
    public virtual ICollection<SubjectTeacher> SubjectTeachers { get; set; } = new List<SubjectTeacher>();
}
