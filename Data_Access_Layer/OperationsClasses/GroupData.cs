using Data_Access.Context;
using Data_Access.DTOs.Group_DTOs;
using Data_Access.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using static Data_Access.GlobalUtilities.ExceptionHandle;

namespace OperationsClasses
{


    public class GroupData
    {


        public static async Task<GroupDto?> GetInfoByIDAsync(int groupID)
        {
            using(AppDbContext context = new())
            {
                return await TryCatchAsync(async () =>
                {
                    return await context.Groups.Where(gp => gp.GroupId == groupID).Select(gp => new GroupDto
                    {
                        GroupId = gp.GroupId,
                        ClassId = gp.ClassId,
                        CreatedByUserId = gp.CreatedByUserId,
                        CreationDate = gp.CreationDate,
                        GroupName = gp.GroupName,
                        IsActive = gp.IsActive,
                        LastModifiedDate = gp.LastModifiedDate,
                        MeetingTimeId = gp.MeetingTimeId,
                        StudentCount = gp.StudentCount,
                        SubjectTeacherId = gp.SubjectTeacherId,
                        TeacherId = gp.TeacherId


                    }).FirstOrDefaultAsync();
                });
            }
        }
   
        public static async Task<List<ScheduleForTodayDto>?> GetScheduleForTodayAsync()
        {
            using (AppDbContext context = new())
            {
                   return await TryCatchAsync(async () => {
                       return await context.Set<ScheduleForTodayDto>().FromSqlRaw($"Exec SP_GetScheduleForToday").ToListAsync(); });
            }
        }

        public static async Task<List<GroupsDetailsDto>?> GetAllGroupsDetailsAsync()
        {
            using (AppDbContext context = new())
            {
                return await TryCatchAsync(async () => { 
                    return await context.Set<GroupsDetailsDto>().FromSqlRaw("Exec SP_GetAllGroupsDetails").ToListAsync(); });
            }
        }

        public static List<string>? GetAllGroupName()
        {
           using(AppDbContext context = new())
           {
               return TryCatch(() => { return context.Groups.Select(gp => gp.GroupName)?.ToList(); });
           }
        }

        public static async Task<int?> AddAsync(GroupDto newGroup)
        {
            using (AppDbContext context = new())
            {
                return await TryCatchAsync(async () =>
                {
                    var group = new Group
                    {
                        ClassId = newGroup.ClassId,
                        CreatedByUserId = newGroup.CreatedByUserId,
                        CreationDate = newGroup.CreationDate,
                        GroupName = newGroup.GroupName,
                        LastModifiedDate = newGroup.LastModifiedDate,
                        MeetingTimeId = newGroup.MeetingTimeId,
                        IsActive = newGroup.IsActive,
                        StudentCount = newGroup.StudentCount,
                        SubjectTeacherId = newGroup.SubjectTeacherId,
                        TeacherId = newGroup.TeacherId

                    };
                    context.Groups.Add(group);
                    await context.SaveChangesAsync();
                    return group.GroupId;


                });
            }
        }

       public static async Task<bool> UpdateAsync(GroupDto Group)
        {
            using (AppDbContext context = new())
            {
                var group = context.Groups.Find(Group.GroupId);
                if (group == null)
                    return false;

                return await TryCatchAsync(async () =>
                {
                    group.ClassId = Group.ClassId;
                    group.CreatedByUserId = Group.CreatedByUserId;
                    group.CreationDate = Group.CreationDate;
                    group.GroupName = Group.GroupName;
                    group.LastModifiedDate = Group.LastModifiedDate;
                    group.MeetingTimeId = Group.MeetingTimeId;
                    group.IsActive = Group.IsActive;
                    group.StudentCount = Group.StudentCount;
                    group.SubjectTeacherId = Group.SubjectTeacherId;
                    group.TeacherId = Group.TeacherId;
                    group.GroupId = Group.GroupId;

                    return await context.SaveChangesAsync() > 0;

                });
            }
        }

        public static async Task<decimal> GetSubjectFeesByGroupIDAsync(int groupID)
        {
            using (AppDbContext context = new())
            {
                return await TryCatchAsync(async () =>
                {
                    var fees = (from Group in context.Groups
                                join SubjectTeacher in context.SubjectTeachers on Group.SubjectTeacherId equals SubjectTeacher.SubjectTeacherId
                                join SubjectGradeLevel in context.SubjectGradeLevels on SubjectTeacher.SubjectGradeLevelId equals SubjectGradeLevel.SubjectGradeLevelId
                                where Group.GroupId == groupID
                                select SubjectGradeLevel.Fees).FirstOrDefaultAsync();
                    return await fees;
                });
               
            }
        }

        public static async Task<List<AllStudentsInThisGroupDto>?> GetAllStudentsInGroupAsync(int groupID)
        {
            using (AppDbContext context = new())
            {
                return await TryCatchAsync(async () =>
                {
                    return await context.Set<AllStudentsInThisGroupDto>()
                    .FromSqlInterpolated($"Exec SP_GetAllStudentsInGroup {groupID}").ToListAsync();
                });
            }

        }
    
    }
}