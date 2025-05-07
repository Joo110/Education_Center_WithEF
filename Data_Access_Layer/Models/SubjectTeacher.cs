using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data_Access.Models;

public partial class SubjectTeacher
{
    [Key]
    [Column("SubjectTeacherID")]
    public int SubjectTeacherId { get; set; }

    [Column("TeacherID")]
    public int TeacherId { get; set; }

    public DateOnly AssignmentDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public int? IsActive { get; set; }

    [Column("SubjectGradeLevelID")]
    public int SubjectGradeLevelId { get; set; }

    [InverseProperty("SubjectTeacher")]
    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    [ForeignKey("SubjectGradeLevelId")]
    [InverseProperty("SubjectTeachers")]
    public virtual SubjectGradeLevel SubjectGradeLevel { get; set; } = null!;

    [ForeignKey("TeacherId")]
    [InverseProperty("SubjectTeachers")]
    public virtual Teacher Teacher { get; set; } = null!;
}
