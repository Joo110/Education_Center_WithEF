namespace Data_Access.DTOs.Payment_DTOs
{
    public class PaymentDto
    {
        public int PaymentId { get; set; }
        public int PaymentAmount { get; set; }
        public int StudentGroupId { get; set; }
        public int SubjectGradeLevelId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? CreatedByUserId { get; set; }
    }
}
