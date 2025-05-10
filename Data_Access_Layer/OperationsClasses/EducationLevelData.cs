using Data_Access.Context;
using Data_Access.DTOs.EducationLevel_DTOs;
using Data_Access.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Threading.Tasks;
namespace OperationsClasses;

public  class EducationLevelData
{
    public static async Task<List<string>?> GetEductionLevelName()
    {
        try
        {
            using (AppDbContext context = new())
            {
                return await context.EducationLevels.Select(E_L => E_L.LevelName).ToListAsync();
            }
        }
        catch (Exception)
        {
            return null;
        }
    }
    public static  EducationLevelDto? GetInfoByID(int educationLevelID)
    {
        try
        {
            using (AppDbContext context = new()) {
                //if we use asynchronization

                //return await context.EducationLevels.Where(e_l => e_l.EducationLevelId == educationLevelID)
                //    .Select(n => new EducationLevelDto { EducationLevelId = educationLevelID, LevelName = n.LevelName }).FirstOrDefaultAsync();
                
                var el = context.EducationLevels.Find(educationLevelID);
                return el == null ? null : new EducationLevelDto { EducationLevelId = el.EducationLevelId, LevelName = el.LevelName };
            }
        }
        catch (Exception)
        {
            return null;
        }
    }
    public static int? GetEducationLevelID(string educationLevelName)
    {
        try
        {
            using(AppDbContext context = new())
            {
                return context.EducationLevels.Where(el => el.LevelName == educationLevelName).FirstOrDefault()?.EducationLevelId;
            }
        }
        catch (Exception)
        {
            return null;
        }
    }
    public static string? GetEducationLevelName(int? educationLevelID)
    {
        try
        {
            using (AppDbContext context = new())
            {
                return context.EducationLevels.Where(el => el.EducationLevelId == educationLevelID).FirstOrDefault()?.LevelName;
            }
        }
        catch (Exception)
        {
            return null;
        }
    }
}
