using Data_Access.Context;
using static Data_Access.GlobalUtilities.ExceptionHandle;
using Data_Access.DTOs.EducationLevel_DTOs;
using Data_Access.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Threading.Tasks;

namespace OperationsClasses
{

    public class EducationLevelData
    {
        public static async Task<List<string>?> GetEductionLevelNameAsync()
        {
            using (AppDbContext context = new())
            {
                return await TryCatchAsync(async () => { return await context.EducationLevels.Select(E_L => E_L.LevelName).ToListAsync(); });
            }
        }
        public static EducationLevelDto? GetInfoByID(int educationLevelID)
        {
            using (AppDbContext context = new())
            {
                return TryCatch(() =>
                {

                    //if we use asynchronization

                    //return await context.EducationLevels.Where(e_l => e_l.EducationLevelId == educationLevelID)
                    //    .Select(n => new EducationLevelDto { EducationLevelId = educationLevelID, LevelName = n.LevelName }).FirstOrDefaultAsync();

                    var el = context.EducationLevels.Find(educationLevelID);
                    return el == null ? null : new EducationLevelDto { EducationLevelId = el.EducationLevelId, LevelName = el.LevelName };
                });
            }
        }
        public static int? GetEducationLevelID(string educationLevelName)
        {
            using (AppDbContext context = new())
            {
                return TryCatch(() => { return context.EducationLevels.Where(el => el.LevelName == educationLevelName).FirstOrDefault()?.EducationLevelId; });
            }
        }
        public static string? GetEducationLevelName(int? educationLevelID)
        {
            using (AppDbContext context = new())
            {
                return TryCatch(() => { return context.EducationLevels.Where(el => el.EducationLevelId == educationLevelID).FirstOrDefault()?.LevelName; });
            }
        }
    }
}