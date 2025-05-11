using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.DTOs.GradeLevel_DTOs
{
    public class GradeLevelDto
    {
        public int GradeLevelId { get; set; }
        public string? GradeName { get; set; }
    }
}
