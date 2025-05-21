using Data_Access.Context;
using Data_Access.DTOs.Student_DTOs;
using Data_Access.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data_Access.Models
{
    public class StudentData
    {
        private readonly AppDbContext _context;

        public StudentData(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentDto>> GetStudentsAsync()
        {
            return await _context.Students
                .Include(s => s.Person)
                .Include(s => s.GradeLevel)
                .Include(s => s.CreatedByUser)
                .Select(s => new StudentDto
                {
                    StudentId = s.StudentId,
                    CreatedByUserId = s.CreatedByUserId,
                    CreationDate = s.CreationDate,
                    PersonId = s.PersonId,
                    GradeLevelId = s.GradeLevelId,
                    CreatedByUser = s.CreatedByUser,
                    GradeLevel = s.GradeLevel,
                    Person = s.Person,
                    StudentGroups = s.StudentGroups
                }).ToListAsync();
        }

        public async Task<StudentDto?> GetInfoByStudentIDAsync(int studentID)
        {
            var student = await _context.Students
                .Include(s => s.Person)
                .Include(s => s.GradeLevel)
                .Include(s => s.CreatedByUser)
                .FirstOrDefaultAsync(s => s.StudentId == studentID);

            if (student == null) return null;

            return new StudentDto
            {
                StudentId = student.StudentId,
                CreatedByUserId = student.CreatedByUserId,
                CreationDate = student.CreationDate,
                PersonId = student.PersonId,
                GradeLevelId = student.GradeLevelId,
                CreatedByUser = student.CreatedByUser,
                GradeLevel = student.GradeLevel,
                Person = student.Person,
                StudentGroups = student.StudentGroups
            };
        }

        public async Task<bool> UpdateGradeLevelAsync(int studentID, int newGradeLevelID)
        {
            var student = await _context.Students.FindAsync(studentID);
            if (student == null) return false;

            student.GradeLevelId = newGradeLevelID;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int studentID)
        {
            var student = await _context.Students.FindAsync(studentID);
            if (student == null) return false;

            _context.Students.Remove(student);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<int?> AddAsync(StudentDto dto)
        {
            var student = new Student
            {
                PersonId = dto.PersonId,
                GradeLevelId = dto.GradeLevelId,
                CreatedByUserId = dto.CreatedByUserId,
                CreationDate = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.Students.Add(student);

            try
            {
                await _context.SaveChangesAsync();
                return student.StudentId;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
