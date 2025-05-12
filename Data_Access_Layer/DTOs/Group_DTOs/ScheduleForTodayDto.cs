

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Data_Access.DTOs.Group_DTOs
{
    [Keyless]
    public class ScheduleForTodayDto
    {
        public string FullName { get; set; } = null!;
        public string SubjectName { get; set; } = null!;
        public string? ClassName {  get; set; }
        public  DateOnly? NumberDate { get; set; }
        public string Time {  get; set; } = null!;
    }
}
