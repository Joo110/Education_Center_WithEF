using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.DTOs.Group_DTOs
{
    [Keyless]
    public class AllStudentsInThisGroupDto
    {
        public int StudentID { get; set; }
        public string FullName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Grade { get; set; } = null!;
        public byte Age { get; set; }
    }
}
