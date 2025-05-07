using System;
using System.Collections.Generic;
using Data_Access.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data_Access.Context;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasOne(d => d.Class).WithMany(p => p.Groups)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Groups_Classes");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Groups)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Groups_Users");

            entity.HasOne(d => d.MeetingTime).WithMany(p => p.Groups)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Groups_MeetingTimes");

            entity.HasOne(d => d.SubjectTeacher).WithMany(p => p.Groups)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Groups_SubjectTeachers");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Groups)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Groups_Teachers");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Payments).HasConstraintName("FK_Payments_Users");

            entity.HasOne(d => d.StudentGroup).WithMany(p => p.Payments)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Payments_StudentGroups");

            entity.HasOne(d => d.SubjectGradeLevel).WithMany(p => p.Payments)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Payments_SubjectGradeLevels");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Students)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Students_Users");

            entity.HasOne(d => d.GradeLevel).WithMany(p => p.Students)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Students_GradeLevels");

            entity.HasOne(d => d.Person).WithMany(p => p.Students)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Students_People");
        });

        modelBuilder.Entity<StudentGroup>(entity =>
        {
            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.StudentGroups)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_StudentGroups_Users");

            entity.HasOne(d => d.Group).WithMany(p => p.StudentGroups)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_StudentGroups_Groups");

            entity.HasOne(d => d.Students).WithMany(p => p.StudentGroups)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_StudentGroups_Students");
        });

        modelBuilder.Entity<SubjectGradeLevel>(entity =>
        {
            entity.HasOne(d => d.GradeLevel).WithMany(p => p.SubjectGradeLevels)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_SubjectGradeLevels_GradeLevels");

            entity.HasOne(d => d.Subject).WithMany(p => p.SubjectGradeLevels)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_SubjectGradeLevels_Subjects");
        });

        modelBuilder.Entity<SubjectTeacher>(entity =>
        {
            entity.HasOne(d => d.SubjectGradeLevel).WithMany(p => p.SubjectTeachers)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_SubjectTeachers_SubjectGradeLevels");

            entity.HasOne(d => d.Teacher).WithMany(p => p.SubjectTeachers)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_SubjectTeachers_Teachers");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.Teachers)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Teachers_Users");

            entity.HasOne(d => d.EducationLevel).WithMany(p => p.Teachers)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Teachers_EducationLevels");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasOne(d => d.Person).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Users_People");
        });

       
        //OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
