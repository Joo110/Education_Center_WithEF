using Data_Access.Context;
using Data_Access.DTOs.Person_DTOs;
using Data_Access.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Data_Access.GlobalUtilities.ExceptionHandle;

namespace OperationsClasses
{
    public class PersonData
    {
        public static async Task<PersonDto?> GetInfoByIDAsync(int personId)
        {
            using (var context = new AppDbContext())
            {
                return await TryCatchAsync(async () =>
                {
                    return await context.People
                        .Where(p => p.PersonId == personId)
                        .Select(p => new PersonDto
                        {
                            PersonID = p.PersonId,
                            FirstName = p.FirstName,
                            SecondName = p.SecondName,
                            ThirdName = p.ThirdName,
                            LastName = p.LastName,
                            Gender = p.Gendor ? (byte)1 : (byte)0,
                            DateOfBirth = p.DateOfBirth,
                            PhoneNumber = p.PhoneNumber,
                            Address = p.Address
                        })
                        .FirstOrDefaultAsync();
                });
            }
        }

        public static async Task<int?> AddAsync(PersonDto dto)
        {
            using (var context = new AppDbContext())
            {
                var person = new Person
                {
                    FirstName = dto.FirstName,
                    SecondName = dto.SecondName,
                    ThirdName = dto.ThirdName,
                    LastName = dto.LastName,
                    Gendor = dto.Gender == 1,
                    DateOfBirth = dto.DateOfBirth,
                    PhoneNumber = dto.PhoneNumber,
                    Address = dto.Address
                };

                return await TryCatchAsync(async () =>
                {
                    context.People.Add(person);
                    await context.SaveChangesAsync();
                    return person.PersonId;
                });
            }
        }

        public static async Task<bool> UpdateAsync(PersonDto dto)
        {
            using (var context = new AppDbContext())
            {
                return await TryCatchAsync(async () =>
                {
                    var person = await context.People.FirstOrDefaultAsync(p => p.PersonId == dto.PersonID);
                    if (person == null) return false;

                    person.FirstName = dto.FirstName;
                    person.SecondName = dto.SecondName;
                    person.ThirdName = dto.ThirdName;
                    person.LastName = dto.LastName;
                    person.Gendor = dto.Gender == 1;
                    person.DateOfBirth = dto.DateOfBirth;
                    person.PhoneNumber = dto.PhoneNumber;
                    person.Address = dto.Address;

                    await context.SaveChangesAsync();
                    return true;
                });
            }
        }

        public static async Task<PersonDto?> GetInfoByStudentIDAsync(int studentId)
        {
            using (var context = new AppDbContext())
            {
                return await TryCatchAsync(async () =>
                {
                    return await context.Students
                        .Where(s => s.StudentId == studentId)
                        .Include(s => s.Person)
                        .Select(s => new PersonDto
                        {
                            PersonID = s.Person.PersonId,
                            FirstName = s.Person.FirstName,
                            SecondName = s.Person.SecondName,
                            ThirdName = s.Person.ThirdName,
                            LastName = s.Person.LastName,
                            Gender = (byte)(s.Person.Gendor ? 1 : 0),
                            DateOfBirth = s.Person.DateOfBirth,
                            PhoneNumber = s.Person.PhoneNumber,
                            Address = s.Person.Address
                        })
                        .FirstOrDefaultAsync();
                });
            }
        }
    }
}
