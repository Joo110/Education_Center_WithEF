using Data_Access.Context;
using Data_Access.DTOs.Group_DTOs;
using Data_Access.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using static Data_Access.GlobalUtilities.ExceptionHandle;

namespace OperationsClasses
{
    /// <summary>
    /// Provides data operations related to Group entities using Entity Framework Core with SQL Server.
    /// </summary>
    public class GroupData
    {
        /// <summary>
        /// Retrieves a group's information by its ID.
        /// </summary>
        /// <param name="groupID">The ID of the group.</param>
        /// <returns>A <see cref="GroupDto"/> containing the group data, or null if not found.</returns>
        public static async Task<GroupDto?> GetInfoByIDAsync(int groupID)
        {
            using (AppDbContext context = new())
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

        /// <summary>
        /// Retrieves the schedule for today by executing a stored procedure.
        /// </summary>
        /// <returns>A list of <see cref="ScheduleForTodayDto"/> objects representing today's schedule.</returns>
        public static async Task<List<ScheduleForTodayDto>?> GetScheduleForTodayAsync()
        {
            using (AppDbContext context = new())
            {
                return await TryCatchAsync(async () =>
                {
                    return await context.Set<ScheduleForTodayDto>().FromSqlRaw("Exec SP_GetScheduleForToday").ToListAsync();
                });
            }
        }

        /// <summary>
        /// Retrieves all group details by executing a stored procedure.
        /// </summary>
        /// <returns>A list of <see cref="GroupsDetailsDto"/> representing all group details.</returns>
        public static async Task<List<GroupsDetailsDto>?> GetAllGroupsDetailsAsync()
        {
            using (AppDbContext context = new())
            {
                return await TryCatchAsync(async () =>
                {
                    return await context.Set<GroupsDetailsDto>().FromSqlRaw("Exec SP_GetAllGroupsDetails").ToListAsync();
                });
            }
        }

        /// <summary>
        /// Retrieves all group names.
        /// </summary>
        /// <returns>A list of group names as strings.</returns>
        public static List<string>? GetAllGroupName()
        {
            using (AppDbContext context = new())
            {
                return TryCatch(() => context.Groups.Select(gp => gp.GroupName)?.ToList());
            }
        }

        /// <summary>
        /// Adds a new group to the database.
        /// </summary>
        /// <param name="newGroup">The group data to be added.</param>
        /// <returns>The ID of the newly created group, or null if the operation failed.</returns>
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

        /// <summary>
        /// Updates an existing group's information.
        /// </summary>
        /// <param name="Group">The group data with updated values. The group must already exist.</param>
        /// <returns><c>true</c> if the update was successful; otherwise, <c>false</c>.</returns>
        public static async Task<bool> UpdateAsync(GroupDto Group)
        {
            using (AppDbContext context = new())
            {
                var group = await context.Groups.FindAsync(Group.GroupId);

                return await TryCatchAsync(async () =>
                {
                    group!.ClassId = Group.ClassId;
                    group.CreatedByUserId = Group.CreatedByUserId;
                    group.CreationDate = Group.CreationDate;
                    group.GroupName = Group.GroupName;
                    group.LastModifiedDate = Group.LastModifiedDate;
                    group.MeetingTimeId = Group.MeetingTimeId;
                    group.IsActive = Group.IsActive;
                    group.StudentCount = Group.StudentCount;
                    group.SubjectTeacherId = Group.SubjectTeacherId;
                    group.TeacherId = Group.TeacherId;

                    return await context.SaveChangesAsync() > 0;
                });
            }
        }

        /// <summary>
        /// Gets the subject fees associated with a specific group by its ID.
        /// </summary>
        /// <param name="groupID">The ID of the group.</param>
        /// <returns>The fees for the subject associated with the group.</returns>
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

        /// <summary>
        /// Retrieves all students enrolled in a specific group by executing a stored procedure.
        /// </summary>
        /// <param name="groupID">The ID of the group.</param>
        /// <returns>A list of <see cref="AllStudentsInThisGroupDto"/> representing students in the group.</returns>
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
