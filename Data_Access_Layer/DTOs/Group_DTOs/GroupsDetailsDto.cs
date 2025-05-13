using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.DTOs.Group_DTOs
{
    [Keyless]
    public class GroupsDetailsDto
    {
        public int GroupID { get; set; }
        public string className { get; set; } = null!;
        public string TeacherName { get; set; } = null!;
        public string SubjectName { get; set; } = null!;
        public string GradeName { get; set; } = null!;
        public string StartTime { get; set; } = null!;
        public string EndTime { get; set; } = null!;
        public string MeetingDays {  get; set; } = null!;
        public short StudentCount { get; set; } 
        public decimal Fees { get; set; }
        public bool IsActive { get; set; }
        
    }
}
