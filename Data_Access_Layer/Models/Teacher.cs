using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data_Access.Models;

public partial class Teacher
{
    [Key]
    [Column("TeacherID")]
    public int TeacherId { get; set; }

    public byte TeachingExperience { get; set; }

    [StringLength(50)]
    public string? Certifications { get; set; }

    [Column("CreatedByUserID")]
    public int CreatedByUserId { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? CreationDate { get; set; }

    [Column("EducationLevelID")]
    public int EducationLevelId { get; set; }

    [Column("PersonID")]
    public int PersonId { get; set; }
}
