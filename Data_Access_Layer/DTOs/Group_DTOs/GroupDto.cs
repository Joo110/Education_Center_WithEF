using Data_Access.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.DTOs.Group_DTOs
{
    public class GroupDto
    {
        public int GroupId { get; set; }

        public string? GroupName { get; set; }

        public int ClassId { get; set; }

        public int TeacherId { get; set; }

        public int SubjectTeacherId { get; set; }

        public int MeetingTimeId { get; set; }

        public int? StudentCount { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public bool IsActive { get; set; }

       
    }
}
