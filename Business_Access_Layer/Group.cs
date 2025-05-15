using Data_Access.Context;
using Data_Access.DTOs.Group_DTOs;
using OperationsClasses;
using System.Threading.Tasks;

namespace Business_Access
{
    public class Group
    {
        public enum enMode { Add,Update}
        public enMode mode;
        public int? GroupId { get; set; }

        public string GroupName { get; set; } = null!;

        public int ClassId { get; set; }

        public int TeacherId { get; set; }

        public int SubjectTeacherId { get; set; }

        public int MeetingTimeId { get; set; }

        public short? StudentCount { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public bool IsActive { get; set; }
        
        /*
         may be include the relative data here like (Teacher,StudentGroups,MeetingTime,ets..)
         */

        /// <summary>
        /// This property made to return the EducationLevel object properties only not return other methods to use it with API and Add and Update as parameter,
        /// and it also read only
        /// </summary>
        public GroupDto dto {
            get
            {
                return new GroupDto
                {
                    GroupId = this.GroupId,
                    GroupName = this.GroupName,
                    ClassId = this.ClassId,
                    TeacherId = this.TeacherId,
                    SubjectTeacherId = this.SubjectTeacherId,
                    MeetingTimeId = this.MeetingTimeId,
                    StudentCount = this.StudentCount,
                    CreatedByUserId = this.CreatedByUserId,
                    CreationDate = this.CreationDate,
                    LastModifiedDate = this.LastModifiedDate,
                    IsActive = this.IsActive

                };

            } 
        }


        public Group()
        {
            mode = enMode.Add;
            GroupId = null;
            GroupName = string.Empty;
            ClassId = 0;
            TeacherId = 0;
            SubjectTeacherId = 0;
            MeetingTimeId = 0;
            StudentCount = null;
            CreatedByUserId = 0;
            CreationDate = DateTime.UtcNow;
            LastModifiedDate = null;
            IsActive = true;
        }

        public Group(GroupDto dto)
        {
            mode = enMode.Update;
            this.GroupId = dto.GroupId;
            this.GroupName = dto.GroupName;
            this.ClassId = dto.ClassId;
            this.TeacherId = dto.TeacherId;
            this.SubjectTeacherId = dto.SubjectTeacherId;
            this.MeetingTimeId = dto.MeetingTimeId;
            this.StudentCount = dto.StudentCount;
            this.CreatedByUserId = dto.CreatedByUserId;
            this.CreationDate = dto.CreationDate;
            this.LastModifiedDate = dto.LastModifiedDate;
            this.IsActive = dto.IsActive;
        }
        private async Task<bool> _AddAsync()
        {
            this.GroupId = await GroupData.AddAsync(dto);

            return this.GroupId != null;
        }
        private async Task<bool> _UpdateAsync()
        {
            return await GroupData.UpdateAsync(dto);
        }

        /// <summary>
        /// Saves the current class instance to the data store, adding or updating as appropriate.
        /// </summary>
        /// <returns>True if the operation was successful; otherwise, false.</returns>
        public async Task<bool> Save()
        {
            switch (mode)
            {
                case enMode.Add:
                    if (await _AddAsync())
                    {
                        mode = enMode.Update;
                        return true;
                    }
                    else return false;

                case enMode.Update:
                    return await _UpdateAsync();

            }

            return false;
        }

        /// <summary>
        /// Returns a new <see cref="Group"/> object if a Group with the specified ID is found; otherwise, returns null.
        /// </summary>
        /// <param name="GroupId">The Group ID to search for.</param>
        /// <returns>A <see cref="Group"/> object or null if not found.</returns>
        public static async Task<Group?> Find(int GroupId)
        {
            var group = await GroupData.GetInfoByIDAsync(GroupId);

            return group ==null ? null : new Group(group);
        }

        /// <summary>
        /// Retrieves the schedule for today.
        /// </summary>
        /// <returns>A list of <see cref="ScheduleForTodayDto"/> objects representing today's schedule.</returns>
        public static async Task<List<ScheduleForTodayDto>?> GetScheduleForTodayAsync()
        {
           return await GroupData.GetScheduleForTodayAsync();
        }

        /// <summary>
        /// Retrieves all group details.
        /// </summary>
        /// <returns>A list of <see cref="GroupsDetailsDto"/> representing all group details.</returns>
        public static async Task<List<GroupsDetailsDto>?> GetAllGroupsDetailsAsync()
        {
            return await GroupData.GetAllGroupsDetailsAsync();
        }

        /// <summary>
        /// Retrieves all group names.
        /// </summary>
        /// <returns>A list of group names as strings, otherwise, returns null</returns>
        public static async Task<List<string>?> GetAllGroupNameAsync()
        {
           return await GroupData.GetAllGroupNameAsync();
        }

       
        /// <summary>
        /// Gets the subject fees associated with a specific group by its ID.
        /// </summary>
        /// <param name="groupID">The ID of the group.</param>
        /// <returns>The fees for the subject associated with the group.</returns>
        public static async Task<decimal> GetSubjectFeesByGroupIDAsync(int groupID)
        {
           return await GroupData.GetSubjectFeesByGroupIDAsync(groupID);
        }

        /// <summary>
        /// Retrieves all students enrolled in a specific group.
        /// </summary>
        /// <param name="groupID">The ID of the group.</param>
        /// <returns>A list of <see cref="AllStudentsInThisGroupDto"/> representing students in the group.</returns>
        public static async Task<List<AllStudentsInThisGroupDto>?> GetAllStudentsInGroupAsync(int groupID)
        {
            return await GroupData.GetAllStudentsInGroupAsync(groupID);
        }
    }
}