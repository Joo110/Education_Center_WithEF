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
    /// <summary>
    /// Provides data access operations for the <see cref="EducationLevel"/> entity using SQL Server and Entity Framework Core.
    /// </summary>
    /// <remarks>
    /// This class contains static methods to retrieve education level information from the database.
    /// </remarks>
    public class EducationLevelData
    {
        /// <summary>
        /// Asynchronously retrieves a list of all education level names from the database.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation, containing a list of education level names, or <c>null</c> if an error occurs.
        /// </returns>
        public static async Task<List<string>?> GetEductionLevelNameAsync()
        {
            using (AppDbContext context = new())
            {
                return await TryCatchAsync(async () => { return await context.EducationLevels.Select(E_L => E_L.LevelName).ToListAsync(); });
            }
        }

        /// <summary>
        /// Retrieves education level information by its unique identifier.
        /// </summary>
        /// <param name="educationLevelID">The unique identifier of the education level.</param>
        /// <returns>
        /// An <see cref="EducationLevelDto"/> containing the education level information, or <c>null</c> if not found or an error occurs.
        /// </returns>
        public static async Task<EducationLevelDto?> GetInfoByIDAsync(int educationLevelID)
        {
            using (AppDbContext context = new())
            {
                return await TryCatchAsync(async () =>
                {
                    EducationLevel? el = await context.EducationLevels.FindAsync(educationLevelID);
                    return el == null ? null : new EducationLevelDto { EducationLevelId = el.EducationLevelId, LevelName = el.LevelName };
                });
            }
        }

        /// <summary>
        /// Retrieves the unique identifier of an education level by its name.
        /// </summary>
        /// <param name="educationLevelName">The name of the education level.</param>
        /// <returns>
        /// The unique identifier of the education level, or <c>null</c> if not found or an error occurs.
        /// </returns>
        public static async Task<int?> GetEducationLevelIDAsync(string educationLevelName)
        {
            using (AppDbContext context = new())
            {
                return await TryCatchAsync(async () =>
                {
                    var educationLevel = await context.EducationLevels
                        .Where(el => el.LevelName == educationLevelName)
                        .FirstOrDefaultAsync();

                    return educationLevel?.EducationLevelId;
                });
            }
        }

        /// <summary>
        /// Retrieves the name of an education level by its unique identifier.
        /// </summary>
        /// <param name="educationLevelID">The unique identifier of the education level.</param>
        /// <returns>
        /// The name of the education level, or <c>null</c> if not found or an error occurs.
        /// </returns>
        public static async Task<string?> GetEducationLevelNameAsync(int? educationLevelID)
        {
            using (AppDbContext context = new())
            {
                return await TryCatchAsync(async () => {
                    var educationLevel =  await context.EducationLevels.
                    Where(el => el.EducationLevelId == educationLevelID).FirstOrDefaultAsync();
                    
                    return educationLevel?.LevelName;

                });
            }
        }
    }
}
