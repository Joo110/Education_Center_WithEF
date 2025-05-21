using Data_Access.DTOs.StudentGroup_DTOs;
using OperationsClasses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business_Access
{
    public class StudentGroup
    {
        private readonly StudentGroupData _studentGroupData;

        public StudentGroup(StudentGroupData studentGroupData)
        {
            _studentGroupData = studentGroupData;
        }

        public async Task<List<StudentGroupDto>> GetAvailableGroupsForStudentAsync(int studentID)
        {
            return await _studentGroupData.GetAvailableGroupsForStudentAsync(studentID);
        }

        public async Task<int?> AddStudentGroupAsync(int studentID, int groupID, int createdByUserID)
        {
            if (studentID <= 0 || groupID <= 0 || createdByUserID <= 0)
                throw new ArgumentException("IDs must be positive numbers.");

            return await _studentGroupData.AddAsync(studentID, groupID, createdByUserID);
        }

        public async Task<bool> UpdateStudentGroupAsync(int studentGroupID, int studentID, int groupID, DateTime? endDate, bool isActive)
        {
            if (studentGroupID <= 0)
                throw new ArgumentException("StudentGroupID must be positive number.");


            return await _studentGroupData.UpdateAsync(studentGroupID, studentID, groupID, endDate, isActive);
        }

        public async Task<StudentGroupDto?> GetStudentGroupByIDAsync(int studentGroupID)
        {
            if (studentGroupID <= 0)
                throw new ArgumentException("StudentGroupID must be positive number.");

            return await _studentGroupData.GetInfoByIDAsync(studentGroupID);
        }
    }
}
