using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data_Access.Models;

public partial class GradeLevel
{
    [Key]
    [Column("GradeLevelID")]
    public int GradeLevelId { get; set; }

    [StringLength(50)]
    public string GradeName { get; set; } = null!;

    [InverseProperty("GradeLevel")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    [InverseProperty("GradeLevel")]
    public virtual ICollection<SubjectGradeLevel> SubjectGradeLevels { get; set; } = new List<SubjectGradeLevel>();
}
