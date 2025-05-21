using Data_Access.DTOs.Subject_DTOs;
using OperationsClasses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business_Access
{
    public class Subject
    {
        private readonly SubjectData _subjectData;

        public Subject(SubjectData subjectData)
        {
            _subjectData = subjectData;
        }

        public async Task<List<SubjectDto>> GetAllSubjectsAsync()
        {
            return await _subjectData.GetAllSubjectNamesAsync();
        }

        public async Task<string> GetSubjectNameByIdAsync(int subjectId)
        {
            var (found, name) = await _subjectData.GetInfoByIdAsync(subjectId);
            return found ? name : null;
        }

        public async Task<int?> GetSubjectIdByNameAsync(string subjectName)
        {
            return await _subjectData.GetSubjectIdByNameAsync(subjectName);
        }

        public async Task<int?> AddSubjectAsync(string subjectName)
        {
            return await _subjectData.AddNewSubjectAsync(subjectName);
        }

        public async Task<string> GetSubjectNameByGradeLevelIdAsync(int subjectGradeLevelId)
        {
            var dto = await _subjectData.GetSubjectNameBySubjectGradeLevelIdAsync(subjectGradeLevelId);
            return dto?.SubjectName;
        }
    }
}
