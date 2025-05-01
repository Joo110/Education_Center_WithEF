using System;
using System.Collections.Generic;
using Data_Access.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data_Access.Context;

public partial class AppDBContext : DbContext
{
    //public AppDBContext()
    //{
    //}

    //public AppDBContext(DbContextOptions<AppDBContext> options)
    //    : base(options)
    //{
    //}

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<EducationLevel> EducationLevels { get; set; }

    public virtual DbSet<GradeLevel> GradeLevels { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<MeetingTime> MeetingTimes { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentGroup> StudentGroups { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<SubjectGradeLevel> SubjectGradeLevels { get; set; }

    public virtual DbSet<SubjectTeacher> SubjectTeachers { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<User> Users { get; set; }

   
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings").Value);


}
