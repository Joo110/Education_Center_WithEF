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

    public virtual DbSet<ClassData> Classes { get; set; }

    public virtual DbSet<EducationLevelData> EducationLevels { get; set; }

    public virtual DbSet<GradeLevelData> GradeLevels { get; set; }

    public virtual DbSet<GroupData> Groups { get; set; }

    public virtual DbSet<MeetingTimeData> MeetingTimes { get; set; }

    public virtual DbSet<PaymentData> Payments { get; set; }

    public virtual DbSet<PersonData> People { get; set; }

    public virtual DbSet<StudentData> Students { get; set; }

    public virtual DbSet<StudentGroupData> StudentGroups { get; set; }

    public virtual DbSet<SubjectData> Subjects { get; set; }

    public virtual DbSet<SubjectGradeLevelData> SubjectGradeLevels { get; set; }

    public virtual DbSet<SubjectTeacherData> SubjectTeachers { get; set; }

    public virtual DbSet<TeacherData> Teachers { get; set; }

    public virtual DbSet<UserData> Users { get; set; }

   
    //Read the connection strings from json file
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings").Value);


}
