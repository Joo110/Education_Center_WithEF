using Data_Access.Context;
using Data_Access.DTOs.GradeLevel_DTOs;
using Microsoft.EntityFrameworkCore;
using static Data_Access.GlobalUtilities.ExceptionHandle;



namespace OperationsClasses
{
    public class GradeLevelData
    {


        public static async Task<List<string>?> GetAllGradeLevelsName()
        {
            using (AppDbContext context = new())
            {
                return await TryCatchAsync(() => { return context.GradeLevels.Select(x => x.GradeName).ToListAsync(); });
            }
        }
        // Get Grade Level Name By ID
        public static string? GetGradeLevelName(int? gradeLevelID)
        {

            using (AppDbContext context = new())
            {
                return TryCatch(() => { return context.GradeLevels.Find(gradeLevelID)?.GradeName; });
            }

        }
        // Get Grade Level Name By Name
        public static int? GetGradeLevelID(string gradeName)
        {
            using (AppDbContext context = new())
            {
                return TryCatch(() => { return context.GradeLevels.Where(g => g.GradeName == gradeName).FirstOrDefault()?.GradeLevelId; });
            }
        }
        public static GradeLevelDto? GetInfoByID(int gradeLevelID)
        {
            using (AppDbContext context = new())
            {
                return TryCatch(() =>
                {
                    var g = context.GradeLevels.Find(gradeLevelID);
                    return g != null ? new GradeLevelDto { GradeName = g.GradeName, GradeLevelId = gradeLevelID } : null;
                });
            }
        }
    }
}