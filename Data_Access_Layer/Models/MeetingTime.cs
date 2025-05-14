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

    [StringLength(1)]
    public char MeetingDays { get; set; }

    public DateOnly? NumberDate { get; set; }

    [InverseProperty("MeetingTime")]
    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
