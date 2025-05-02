using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data_Access.Models;

public partial class EducationLevelData
{
    [Key]
    [Column("EducationLevelID")]
    public int EducationLevelId { get; set; }

    [StringLength(50)]
    public string LevelName { get; set; } = null!;
}
