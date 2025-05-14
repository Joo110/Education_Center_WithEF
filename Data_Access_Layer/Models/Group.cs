using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data_Access.Models;

public partial class Group
{
    [Key]
    [Column("GroupID")]
    public int GroupId { get; set; }

    [StringLength(50)]
    public string GroupName { get; set; } = null!;

    [Column("ClassID")]
    public int ClassId { get; set; }

    [Column("TeacherID")]
    public int TeacherId { get; set; }

    [Column("SubjectTeacherID")]
    public int SubjectTeacherId { get; set; }

    [Column("MeetingTimeID")]
    public int MeetingTimeId { get; set; }

    public short? StudentCount { get; set; }

    [Column("CreatedByUserID")]
    public int CreatedByUserId { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime CreationDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? LastModifiedDate { get; set; }

    public bool IsActive { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("Groups")]
    public virtual Class Class { get; set; } = null!;

    [ForeignKey("CreatedByUserId")]
    [InverseProperty("Groups")]
    public virtual User CreatedByUser { get; set; } = null!;

    [ForeignKey("MeetingTimeId")]
    [InverseProperty("Groups")]
    public virtual MeetingTime MeetingTime { get; set; } = null!;

    [InverseProperty("Group")]
    public virtual ICollection<StudentGroup> StudentGroups { get; set; } = new List<StudentGroup>();

    [ForeignKey("SubjectTeacherId")]
    [InverseProperty("Groups")]
    public virtual SubjectTeacher SubjectTeacher { get; set; } = null!;

    [ForeignKey("TeacherId")]
    [InverseProperty("Groups")]
    public virtual Teacher Teacher { get; set; } = null!;
}
