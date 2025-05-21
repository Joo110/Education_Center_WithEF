using Data_Access.Context;
using Data_Access.DTOs.StudentGroup_DTOs;
using Data_Access.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OperationsClasses
{
    public class StudentGroupData
    {
        private readonly AppDbContext _context;

        public StudentGroupData(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentGroupDto>> GetAvailableGroupsForStudentAsync(int studentID)
        {
            var studentGroups = await _context.StudentGroups
                .FromSqlRaw("EXEC SP_GetAvailableGroupsForStudent @StudentID = {0}", studentID)
                .ToListAsync();

            var result = new List<StudentGroupDto>();

            foreach (var sg in studentGroups)
            {
                result.Add(new StudentGroupDto
                {
                    StudentGroupId = sg.StudentGroupId,
                    StudentsId = sg.StudentsId,
                    GroupId = sg.GroupId,
                    StartDate = sg.StartDate,
                    EndDate = sg.EndDate,
                    IsActive = sg.IsActive,
                    CreatedByUserId = sg.CreatedByUserId
                });
            }

            return result;
        }

        public async Task<int?> AddAsync(int studentID, int groupID, int createdByUserID)
        {
            var output = await _context.Database.ExecuteSqlRawAsync(
                "EXEC SP_AddStudentGroup @StudentID = {0}, @GroupID = {1}, @CreatedByUserID = {2}",
                studentID, groupID, createdByUserID);

            var newId = await _context.StudentGroups
                .FromSqlRaw("EXEC SP_AddStudentGroup @StudentID = {0}, @GroupID = {1}, @CreatedByUserID = {2}", studentID, groupID, createdByUserID)
                .AsNoTracking()
                .Select(sg => sg.StudentGroupId)
                .FirstOrDefaultAsync();

            return newId == 0 ? null : (int?)newId;
        }

        public async Task<bool> UpdateAsync(int studentGroupID, int studentID, int groupID, DateTime? endDate, bool isActive)
        {
            var rowsAffected = await _context.Database.ExecuteSqlRawAsync(
                "EXEC SP_UpdateStudentGroup @StudentGroupID = {0}, @StudentID = {1}, @GroupID = {2}, @EndDate = {3}, @IsActive = {4}",
                studentGroupID, studentID, groupID, endDate, isActive ? 1 : 0);

            return rowsAffected > 0;
        }

        public async Task<StudentGroupDto?> GetInfoByIDAsync(int studentGroupID)
        {
            var result = await _context.StudentGroups
                .FromSqlRaw("EXEC SP_GetStudentGroupByID @StudentGroupID = {0}", studentGroupID)
                .AsNoTracking()
                .Select(s => new StudentGroupDto
                {
                    StudentGroupId = s.StudentGroupId,
                    StudentsId = s.StudentsId,
                    GroupId = s.GroupId,
                    StartDate = s.StartDate,
                    EndDate = s.EndDate,
                    IsActive = s.IsActive,
                    CreatedByUserId = s.CreatedByUserId
                })
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
