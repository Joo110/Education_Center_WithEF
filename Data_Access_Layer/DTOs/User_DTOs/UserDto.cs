using Data_Access.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.DTOs.User_DTOs
{
    internal class UserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public int Permissions { get; set; }
        public int IsActive { get; set; }
        public int PersonId { get; set; }
    }
}
