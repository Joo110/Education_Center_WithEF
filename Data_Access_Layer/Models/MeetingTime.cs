using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data_Access.Models;

public partial class MeetingTime
{
    [Key]
    [Column("MeetingTimeID")]
    public int MeetingTimeId { get; set; }

    [Precision(0)]
    public TimeOnly StartTime { get; set; }

    [Precision(0)]
    public TimeOnly EndTime { get; set; }

    [StringLength(50)]
    public string MeetingDays { get; set; } = null!;

    public DateOnly? NumberDate { get; set; }
}
