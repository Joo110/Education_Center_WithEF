using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data_Access.Models;

public partial class SubjectGradeLevelData
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
}
