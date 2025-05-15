using Data_Access.Context;
using static Data_Access.GlobalUtilities.ExceptionHandle;
using Microsoft.EntityFrameworkCore;

namespace OperationsClasses
{
    /// <summary>
    /// Provides data access operations for the <c>Class</c> entity using Entity Framework Core with a SQL Server provider.
    /// </summary>
    public class ClassData
    {
        /// <summary>
        /// Asynchronously retrieves class information by its unique identifier.
        /// </summary>
        /// <param name="classID">The unique identifier of the class.</param>
        /// <returns>
        /// A <see cref="ClassDto"/> object containing class details if found; otherwise, <c>null</c>.
        /// </returns>
        public static async Task<ClassDto?> GetInfoByIDAsync(int classID)
        {
            using (var context = new AppDbContext())
            {
                return await TryCatchAsync(async () =>
                {
                    return await context.Classes.Where(c => c.ClassId == classID).Select(c => new ClassDto
                    {
                        classId = c.ClassId,
                        capacity = c.Capacity,
                        classname = c.Classname,
                        Description = c.Description
                    }).FirstOrDefaultAsync();
                });
            }
        }

        /// <summary>
        /// Retrieves the total count of all classes in the database.
        /// </summary>
        /// <returns>
        /// The total number of classes, or <c>null</c> if an error occurs.
        /// </returns>
        public static int? GetAllClassesCount()
        {
            using (var context = new AppDbContext())
            {
                return TryCatch(() => { return context.Classes.Count(); });
            }
        }

        /// <summary>
        /// Asynchronously retrieves all classes from the database.
        /// </summary>
        /// <returns>
        /// A list of <see cref="ClassDto"/> objects representing all classes, or <c>null</c> if an error occurs.
        /// </returns>
        public static async Task<List<ClassDto>?> GetAllClassesAsync()
        {
            using (var context = new AppDbContext())
            {
                return await TryCatchAsync(async () =>
                {
                    return await context.Classes.Select(cs => new ClassDto
                    {
                        classId = cs.ClassId,
                        capacity = cs.Capacity,
                        classname = cs.Classname,
                        Description = cs.Description
                    }).ToListAsync();
                });
            }
        }

        /// <summary>
        /// Asynchronously adds a new class to the database.
        /// </summary>
        /// <param name="dto">The <see cref="ClassDto"/> containing class details to add.</param>
        /// <returns>
        /// The unique identifier of the newly added class, or <c>null</c> if an error occurs.
        /// </returns>
        public static async Task<int?> AddAsync(ClassDto dto)
        {
            using (var context = new AppDbContext())
            {
                var cls = new Data_Access.Models.Class
                {
                    Classname = dto.classname,
                    Capacity = dto.capacity,
                    Description = dto.Description
                };

                return await TryCatchAsync(async () =>
                {
                    context.Classes.Add(cls);
                    await context.SaveChangesAsync();
                    return cls.ClassId;
                });
            }
        }

        /// <summary>
        /// Asynchronously updates an existing class in the database.
        /// </summary>
        /// <param name="dto">
        /// The <see cref="ClassDto"/> containing updated class details. 
        /// The class must already exist in the database.
        /// </param>
        /// <returns>
        /// <c>true</c> if the update was successful; otherwise, <c>false</c>.
        /// </returns>
        public static async Task<bool> UpdateAsync(ClassDto dto)
        {
            using (var context = new AppDbContext())
            {
                return await TryCatchAsync(async () =>
                {
                    var cls = context.Classes.Find(dto.classId);
                    //if (cls == null)
                    //    return false;

                    cls!.Classname = dto.classname;
                    cls.Capacity = dto.capacity;
                    cls.Description = dto.Description;

                    return await context.SaveChangesAsync() > 0;
                });
            }
        }
    }
}