using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.DTOs.MeetingTime_DTOs
{
    public class MeetingTimeDto
    {
        public int MeetingTimeId { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public string MeetingDays { get; set; } = null!;

        public DateOnly? NumberDate { get; set; }

    }
}
