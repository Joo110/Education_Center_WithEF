using Data_Access.Context;
using Data_Access.DTOs.MeetingTime_DTOs;
using Data_Access.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using static Data_Access.GlobalUtilities.ExceptionHandle;
namespace OperationsClasses;


public class MeetingTimeData
{

    public static async Task<MeetingTimeDto?> GetInfoByIDAsync(int meetingTimeID)
    {
        using(AppDbContext context = new())
        {
            return await TryCatchAsync(async ()  => { return await context.MeetingTimes
                .Where(mt => mt.MeetingTimeId == meetingTimeID).Select(mt => new MeetingTimeDto
                {
                    MeetingTimeId = meetingTimeID,
                    StartTime = mt.StartTime,
                    EndTime = mt.EndTime,
                    MeetingDays = mt.MeetingDays,
                    NumberDate = mt.NumberDate
                    
                }).FirstOrDefaultAsync(); });
        }
    }

    public static async Task<int> AddAsync(MeetingTimeDto meetingTime)
    {
        using(AppDbContext context = new())
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

    public static async Task<bool> UpdateAsync(MeetingTimeDto meetingTimeToUpdate/*I'm sure it already exists in the database — in other words, I have already checked it in the presentation layer*/)
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


    public static async Task<List<MeetingTimeDto>?> GetAllMeetingTimeDetailsAsync()
    {
        using (AppDbContext context = new())
        {
            return await TryCatchAsync(async () => {
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
