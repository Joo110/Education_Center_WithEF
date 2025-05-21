using Data_Access.DTOs.Person_DTOs;
using System.Threading.Tasks;

namespace Business_Access
{
    public class Person
    {
        public async Task<PersonDto?> GetPersonByIdAsync(int personId)
        {
            return await OperationsClasses.PersonData.GetInfoByIDAsync(personId);
        }

        public async Task<int?> AddPersonAsync(PersonDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.FirstName) || string.IsNullOrWhiteSpace(dto.SecondName))
                return null;

            return await OperationsClasses.PersonData.AddAsync(dto);
        }

        public async Task<bool> UpdatePersonAsync(PersonDto dto)
        {
            if (dto.PersonID <= 0)
                return false;

            return await OperationsClasses.PersonData.UpdateAsync(dto);
        }

        public async Task<PersonDto?> GetPersonByStudentIdAsync(int studentId)
        {
            return await OperationsClasses.PersonData.GetInfoByStudentIDAsync(studentId);
        }
    }
}
