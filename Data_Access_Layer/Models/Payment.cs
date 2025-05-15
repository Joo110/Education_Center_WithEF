using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Access.Models;

public partial class Payment
{
    [Key]
    [Column("PaymentID")]
    public int PaymentId { get; set; }

    public decimal PaymentAmount { get; set; }

    [Column("StudentGroupID")]
    public int StudentGroupId { get; set; }

    [Column("SubjectGradeLevelID")]
    public int SubjectGradeLevelId { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? PaymentDate { get; set; }

    [Column("CreatedByUserID")]
    public int? CreatedByUserId { get; set; }

    [ForeignKey("CreatedByUserId")]
    [InverseProperty("Payments")]
    public virtual User? CreatedByUser { get; set; }

    [ForeignKey("StudentGroupId")]
    [InverseProperty("Payments")]
    public virtual StudentGroup StudentGroup { get; set; } = null!;

    [ForeignKey("SubjectGradeLevelId")]
    [InverseProperty("Payments")]
    public virtual SubjectGradeLevel SubjectGradeLevel { get; set; } = null!;
}
