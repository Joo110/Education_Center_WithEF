using Data_Access.Context;
using Data_Access.DTOs.GradeLevel_DTOs;
using Microsoft.EntityFrameworkCore;
using static Data_Access.GlobalUtilities.ExceptionHandle;

namespace OperationsClasses
{
    /// <summary>
    /// Provides data access operations for GradeLevel entities using Entity Framework Core with a SQL Server provider.
    /// </summary>
    public class GradeLevelData
    {
        /// <summary>
        /// Asynchronously retrieves all grade level names from the database.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains a list of grade level names, or null if an error occurs.
        /// </returns>
        public static async Task<List<string>?> GetAllGradeLevelsNameAsync()
        {
            using (AppDbContext context = new())
            {
                return await TryCatchAsync(async () => { return await context.GradeLevels.Select(x => x.GradeName).ToListAsync(); });
            }
        }

        /// <summary>
        /// Retrieves the name of a grade level by its ID.
        /// </summary>
        /// <param name="gradeLevelID">The ID of the grade level.</param>
        /// <returns>
        /// The name of the grade level if found; otherwise, null.
        /// </returns>
        public static string? GetGradeLevelName(int? gradeLevelID)
        {
            using (AppDbContext context = new())
            {
                return TryCatch(() => { return context.GradeLevels.Find(gradeLevelID)?.GradeName; });
            }
        }

        /// <summary>
        /// Retrieves the ID of a grade level by its name.
        /// </summary>
        /// <param name="gradeName">The name of the grade level.</param>
        /// <returns>
        /// The ID of the grade level if found; otherwise, null.
        /// </returns>
        public static int? GetGradeLevelID(string gradeName)
        {
            using (AppDbContext context = new())
            {
                return TryCatch(() => { return context.GradeLevels.Where(g => g.GradeName == gradeName).FirstOrDefault()?.GradeLevelId; });
            }
        }

        /// <summary>
        /// Retrieves grade level information as a <see cref="GradeLevelDto"/> by grade level ID.
        /// </summary>
        /// <param name="gradeLevelID">The ID of the grade level.</param>
        /// <returns>
        /// A <see cref="GradeLevelDto"/> containing grade level information if found; otherwise, null.
        /// </returns>
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
