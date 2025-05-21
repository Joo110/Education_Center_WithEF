using Data_Access.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.DTOs.StudentGroup_DTOs
{
    public class StudentGroupDto
    {
        public int StudentGroupId { get; set; }

        public DateOnly? StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public int? IsActive { get; set; }

        public int? CreatedByUserId { get; set; }

        public int GroupId { get; set; }

        public int StudentsId { get; set; }

        public virtual User CreatedByUser { get; set; } = null!;

        public virtual Group Group { get; set; } = null!;

        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

        public virtual Student Students { get; set; } = null!;
    }
}
