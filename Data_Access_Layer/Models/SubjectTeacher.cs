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
}
