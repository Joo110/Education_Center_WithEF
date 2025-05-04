using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data_Access.Models;

public partial class Payment
{
    [Key]
    [Column("PaymentID")]
    public int PaymentId { get; set; }

    public int PaymentAmount { get; set; }

    [Column("StudentGroupID")]
    public int StudentGroupId { get; set; }

    [Column("SubjectGradeLevelID")]
    public int SubjectGradeLevelId { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? PaymentDate { get; set; }

    [Column("CreatedByUserID")]
    public int? CreatedByUserId { get; set; }
}
