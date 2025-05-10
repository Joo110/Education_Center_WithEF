using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.DTOs.EducationLevel_DTOs
{
    public class EducationLevelDto
    {
        public int EducationLevelId { get; set; }
        public string LevelName { get; set; } = null!;

        public override string ToString()
        {
            return $"EducationLevelId :{EducationLevelId},  LevelName{LevelName}";
        }
    }
}
