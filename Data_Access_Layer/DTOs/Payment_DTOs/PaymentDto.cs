using Microsoft.EntityFrameworkCore;

namespace Data_Access.DTOs.Payment_DTOs
{
    [Keyless]
    public class PaymentDto
    {
        public int? PaymentId { get; set; }
        public int StudentsID { get; set; }
        public int GroupId { get; set; }
        public int PaymentAmount { get; set; }
        public int SubjectGradeLevelId { get; set; }
        public DateTime? PaymentDate { get; set; }
      
    }
}
