using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Education_Center_EF.Models
{
    public class clsPeople
    {
        [Table("People")]
        public class Person
        {
            [Key]
            public int PersonID { get; set; }
            public string FirstName { get; set; } = "";
            public string SecondName { get; set; } = "";
            public string? ThirdName { get; set; }
            public string LastName { get; set; } = "";
            public byte Gender { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string PhoneNumber { get; set; } = "";
            public string? Address { get; set; }
        }
    }
}
