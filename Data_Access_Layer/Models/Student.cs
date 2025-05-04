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
}
