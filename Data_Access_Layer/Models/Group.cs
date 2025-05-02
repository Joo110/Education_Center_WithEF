using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data_Access.Models;

public partial class GroupData
{
    [Key]
    [Column("GroupID")]
    public int GroupId { get; set; }

    [StringLength(50)]
    public string? GroupName { get; set; }

    [Column("ClassID")]
    public int ClassId { get; set; }

    [Column("TeacherID")]
    public int TeacherId { get; set; }

    [Column("SubjectTeacherID")]
    public int SubjectTeacherId { get; set; }

    [Column("MeetingTimeID")]
    public int MeetingTimeId { get; set; }

    public int? StudentCount { get; set; }

    [Column("CreatedByUserID")]
    public int CreatedByUserId { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime CreationDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? LastModifiedDate { get; set; }

    public bool IsActive { get; set; }
}
