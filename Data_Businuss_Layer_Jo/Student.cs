using Data_Access.Models;
using Data_Access.DTOs.Student_DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business_Access
{
    public class Student
    {
        private readonly StudentData _studentData;

        public Student(StudentData studentData)
        {
            _studentData = studentData;
        }

        public async Task<List<StudentDto>> GetAllStudentsAsync()
        {
            return await _studentData.GetStudentsAsync();
        }

        public async Task<StudentDto?> GetStudentByIdAsync(int studentId)
        {
            if (studentId <= 0)
                throw new ArgumentException("Student ID must be positive.");

            return await _studentData.GetInfoByStudentIDAsync(studentId);
        }

        public async Task<bool> UpdateStudentGradeLevelAsync(int studentId, int newGradeLevelId)
        {
            if (studentId <= 0)
                throw new ArgumentException("Student ID must be positive.");

            if (newGradeLevelId <= 0)
                throw new ArgumentException("Grade Level ID must be positive.");


            return await _studentData.UpdateGradeLevelAsync(studentId, newGradeLevelId);
        }

        public async Task<bool> DeleteStudentAsync(int studentId)
        {
            if (studentId <= 0)
                throw new ArgumentException("Student ID must be positive.");

            return await _studentData.DeleteAsync(studentId);
        }

        public async Task<int?> AddStudentAsync(StudentDto studentDto)
        {
            if (studentDto == null)
                throw new ArgumentNullException(nameof(studentDto));

            if (studentDto.PersonId <= 0)
                throw new ArgumentException("Person ID must be positive.");

            if (studentDto.GradeLevelId <= 0)
                throw new ArgumentException("Grade Level ID must be positive.");

            if (studentDto.CreatedByUserId <= 0)
                throw new ArgumentException("Created By User ID must be positive.");


            return await _studentData.AddAsync(studentDto);
        }
    }
}
