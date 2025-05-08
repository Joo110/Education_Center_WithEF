
using Data_Access.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace OperationsClasses;

public  class ClassData
{
    
    public static async Task<ClassDto?> GetInfoByIDAsync(int classID)
    {
        try
        {
            using(var context = new AppDbContext())
            {
                return await (context.Classes.Where(c => c.ClassId == classID).Select(c => new ClassDto
                {
                    classId = c.ClassId,
                    capacity = c.Capacity,
                    classname = c.Classname,
                    Description = c.Description
                }).FirstOrDefaultAsync());
                  
                    
            }
        }
        catch (Exception)
        {
            return null;
        }
        
    }
    public static int GetAllClassesCount()
    {
        try
        {
            using (var context = new AppDbContext())
            {
                return context.Classes.Count();
                 
            }

        }
        catch (Exception)
        {
            return -1;
        }
    }
    public static async Task<List<ClassDto>?> GetAllClassesAsync()
    {
        try
        {
            using( var context = new AppDbContext())
            {
                return await context.Classes.Select(cs => new ClassDto
                {
                    classId=cs.ClassId,
                    capacity = cs.Capacity,
                    classname = cs.Classname,
                    Description = cs.Description
                }).ToListAsync();
            }
        }
        catch (Exception)
        {
            return null;
        }
    }
    public static async Task<int> AddAsync(ClassDto dto)
    {   
        try
        {
            using(var context = new AppDbContext())
            {
                var cls = new Data_Access.Models.Class
                {
                    Classname = dto.classname,
                    Capacity = dto.capacity,
                    Description = dto.Description

                };

                 context.Classes.Add(cls);
                 await context.SaveChangesAsync();
                 return cls.ClassId;
                
            }
        }
        catch (Exception)
        {
            return -1;
        }

    }
    public static async Task<bool> Update(ClassDto dto)
    {
        try
        {
            using (var context = new AppDbContext())
            {
                var cls = context.Classes.Find(dto.classId);
                if (cls == null)
                    return false;

                cls.Classname = dto.classname;
                cls.Capacity = dto.capacity;
                cls.Description = dto.Description;
                
                return await context.SaveChangesAsync() > 0;

            }
        }
        catch (Exception)
        {
            return false;
        }

    }

}
