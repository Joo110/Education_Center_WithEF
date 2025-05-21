using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data_Access.Models;

public partial class Subject
{
    [Key]
    [Column("SubjectID")]
    public int SubjectId { get; set; }

    [StringLength(50)]
    public string SubjectName { get; set; } = null!;

    [InverseProperty("Subject")]
    public virtual ICollection<SubjectGradeLevel> SubjectGradeLevels { get; set; } = new List<SubjectGradeLevel>();
}
