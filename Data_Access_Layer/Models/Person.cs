﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data_Access.Models;

public partial class Person
{
    [Key]
    [Column("PersonID")]
    public int PersonId { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string SecondName { get; set; } = null!;

    [StringLength(50)]
    public string? ThirdName { get; set; }

    [StringLength(50)]
    public string? LastName { get; set; }

    public bool Gendor { get; set; }

    public DateOnly DateOfBirth { get; set; }

    [StringLength(50)]
    public string PhoneNumber { get; set; } = null!;

    [StringLength(50)]
    public string Address { get; set; } = null!;

    [InverseProperty("Person")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    [InverseProperty("Person")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
