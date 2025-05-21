using Data_Access.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.DTOs.Student_DTOs
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public int CreatedByUserId { get; set; }
        public DateOnly? CreationDate { get; set; }
        public int PersonId { get; set; }
        public int GradeLevelId { get; set; }
        public virtual User CreatedByUser { get; set; } = null!;
        public virtual GradeLevel GradeLevel { get; set; } = null!;
        public virtual Person Person { get; set; } = null!;
        public virtual ICollection<StudentGroup> StudentGroups { get; set; } = new List<StudentGroup>();
    }
}
