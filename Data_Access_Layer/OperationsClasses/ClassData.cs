using Data_Access.Context;
using static Data_Access.GlobalUtilities.ExceptionHandle;
using Microsoft.EntityFrameworkCore;

namespace OperationsClasses
{
    public class ClassData
    {
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
        public static int? GetAllClassesCount()
        {
            using (var context = new AppDbContext())
            {
                return TryCatch(() => { return context.Classes.Count(); });
            }
        }
        public static async Task<List<ClassDto>?> GetAllClassesAsync()
        {
            using (var context = new AppDbContext())
            {
                return await TryCatchAsync( async () =>
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
        public static async Task<bool> UpdateAsync(ClassDto dto)
        {
            using (var context = new AppDbContext())
            {
                return await TryCatchAsync(async () =>
                {
                    var cls = context.Classes.Find(dto.classId);
                    if (cls == null)
                        return false;

                    cls.Classname = dto.classname;
                    cls.Capacity = dto.capacity;
                    cls.Description = dto.Description;

                    return await context.SaveChangesAsync() > 0;
                });


            }
        }
    }

}
