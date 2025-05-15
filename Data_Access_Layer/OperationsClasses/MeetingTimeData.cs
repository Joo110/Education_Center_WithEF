using Data_Access.Context;
using Data_Access.DTOs.MeetingTime_DTOs;
using Data_Access.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using static Data_Access.GlobalUtilities.ExceptionHandle;
namespace OperationsClasses;


/// <summary>
/// Provides data access operations for <see cref="MeetingTime"/> entities using Entity Framework Core and SQL Server.
/// </summary>
/// <remarks>
/// This class includes methods for retrieving, adding, updating, and checking the existence of meeting time records.
/// All methods use <see cref="AppDbContext"/> for database operations.
/// The data provider is SQL Server and the ORM is Entity Framework Core.
/// </remarks>
public class MeetingTimeData
{
    /// <summary>
    /// Retrieves a <see cref="MeetingTimeDto"/> by its unique identifier.
    /// </summary>
    /// <param name="meetingTimeID">The unique identifier of the meeting time.</param>
    /// <returns>
    /// A <see cref="MeetingTimeDto"/> if found; otherwise, <c>null</c>.
    /// </returns>
    public static async Task<MeetingTimeDto?> GetInfoByIDAsync(int meetingTimeID)
    {
        using (AppDbContext context = new())
        {
            return await TryCatchAsync(async () =>
            {
                return await context.MeetingTimes
                .Where(mt => mt.MeetingTimeId == meetingTimeID).Select(mt => new MeetingTimeDto
                {
                    MeetingTimeId = meetingTimeID,
                    StartTime = mt.StartTime,
                    EndTime = mt.EndTime,
                    MeetingDays = mt.MeetingDays,
                    NumberDate = mt.NumberDate

                }).FirstOrDefaultAsync();
            });
        }
    }

    /// <summary>
    /// Adds a new meeting time record to the database.
    /// </summary>
    /// <param name="meetingTime">The <see cref="MeetingTimeDto"/> to add.</param>
    /// <returns>
    /// The number of state entries written to the database.
    /// </returns>
    public static async Task<int> AddAsync(MeetingTimeDto meetingTime)
    {
        using (AppDbContext context = new())
        {
            var NewMeeting = new MeetingTime
            {
                StartTime = meetingTime.StartTime,
                EndTime = meetingTime.EndTime,
                MeetingDays = meetingTime.MeetingDays,
                NumberDate = meetingTime.NumberDate
            };

            return await TryCatchAsync(async () =>
            {
                context.MeetingTimes.Add(NewMeeting);
                return await context.SaveChangesAsync();
            });
        }
    }

    /// <summary>
    /// Updates an existing meeting time record in the database.
    /// </summary>
    /// <param name="meetingTimeToUpdate">The <see cref="MeetingTimeDto"/> containing updated values. Assumes the record exists.</param>
    /// <returns>
    /// <c>true</c> if the update was successful; otherwise, <c>false</c>.
    /// </returns>
    public static async Task<bool> UpdateAsync(MeetingTimeDto meetingTimeToUpdate)
    {
        using (AppDbContext context = new())
        {
            var mt = context.MeetingTimes.Find(meetingTimeToUpdate.MeetingTimeId);
            //if(mt == null) 
            //    return false;
            mt!.MeetingTimeId = meetingTimeToUpdate.MeetingTimeId;
            mt.StartTime = meetingTimeToUpdate.StartTime;
            mt.EndTime = meetingTimeToUpdate.EndTime;
            mt.MeetingDays = meetingTimeToUpdate.MeetingDays;
            mt.NumberDate = meetingTimeToUpdate.NumberDate;


            return await TryCatchAsync(async () =>
            {
                return await context.SaveChangesAsync() > 0;
            });
        }
    }

    /// <summary>
    /// Checks if a meeting time exists for the specified start time and date.
    /// </summary>
    /// <param name="startTime">The start time of the meeting.</param>
    /// <param name="numberDate">The date of the meeting.</param>
    /// <returns>
    /// <c>true</c> if a meeting time exists; otherwise, <c>false</c>.
    /// </returns>
    public static bool DoesMeetingTimeExist(TimeOnly startTime, DateOnly numberDate)
    {
        using (AppDbContext context = new())
        {
            if (context.MeetingTimes.Any(mt => mt.StartTime
            == startTime && mt.NumberDate == numberDate))
                return true;

            return false;
        }
    }

    /// <summary>
    /// Retrieves all meeting time records as a list of <see cref="MeetingTimeDto"/>.
    /// </summary>
    /// <returns>
    /// A list of <see cref="MeetingTimeDto"/> containing all meeting time details, or <c>null</c> if an error occurs.
    /// </returns>
    public static async Task<List<MeetingTimeDto>?> GetAllMeetingTimeDetailsAsync()
    {
        using (AppDbContext context = new())
        {
            return await TryCatchAsync(async () =>
            {
                return await context.MeetingTimes
                .Select(mt => new MeetingTimeDto
                {
                    MeetingTimeId = mt.MeetingTimeId,
                    StartTime = mt.StartTime,
                    EndTime = mt.EndTime,
                    MeetingDays = mt.MeetingDays,
                    NumberDate = mt.NumberDate

                }).ToListAsync();
            });
        }
    }
}
