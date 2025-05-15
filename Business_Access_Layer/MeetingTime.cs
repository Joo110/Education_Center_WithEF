using Data_Access.Context;
using Data_Access.DTOs.MeetingTime_DTOs;
using OperationsClasses;

namespace Business_Access

{
    public class MeetingTime
    {
        public enum enMode { Add, Update }
        public enMode mode;
        public int? MeetingTimeId { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public char MeetingDays { get; set; }

        public DateOnly? NumberDate { get; set; }

        /*
        may be include the relative data here like Groups
        */

        /// <summary>
        /// This property made to return the class object properties only not return other methods to use it with API and Add and Update as parameter,
        /// and it also read only
        /// </summary>
        public MeetingTimeDto dto
        {
            get
            {
                return new MeetingTimeDto
                {
                    MeetingTimeId = this.MeetingTimeId,
                    StartTime = this.StartTime,
                    EndTime = this.EndTime,
                    MeetingDays = this.MeetingDays,
                    NumberDate = this.NumberDate

                };
            }
        }

        public MeetingTime()
        {
            mode = enMode.Add;
            MeetingTimeId = null;
            StartTime = new TimeOnly();
            EndTime = new TimeOnly();
            MeetingDays = '0'; 
            NumberDate = null;
        }

        public MeetingTime(MeetingTimeDto dto)
        {
            mode = enMode.Update;
            this.MeetingTimeId = dto.MeetingTimeId;
            this.StartTime = dto.StartTime;
            this.EndTime = dto.EndTime;
            this.MeetingDays = dto.MeetingDays;
            this.NumberDate = dto.NumberDate;
        }

        /// <summary>
        /// Adds a new MeetingTime asynchronously to the data store.
        /// </summary>
        /// <returns>True if the MeetingTime was added successfully; otherwise, false.</returns>
        private async Task<bool> _AddAsync()
        {
            this.MeetingTimeId = await MeetingTimeData.AddAsync(dto);

            return this.MeetingTimeId != null;
        }

        /// <summary>
        /// Updates an existing MeetingTime asynchronously in the data store.
        /// </summary>
        /// <returns>True if the MeetingTime was updated successfully; otherwise, false.</returns>
        private async Task<bool> _UpdateAsync()
        {
            return await MeetingTimeData.UpdateAsync(dto);
        }

        /// <summary>
        /// Saves the current MeetingTime instance to the data store, adding or updating as appropriate.
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
        /// Returns a new <see cref="MeetingTime"/> object if a MeetingTime with the specified ID is found; otherwise, returns null.
        /// </summary>
        /// <param name="MeetingTimeId">The MeetingTime ID to search for.</param>
        /// <returns>A <see cref="MeetingTime"/> object or null if not found.</returns>
        public static async Task<MeetingTime?> Find(int MeetingTimeId)
        {
            var Dto = await MeetingTimeData.GetInfoByIDAsync(MeetingTimeId);

            return Dto == null ? null : new MeetingTime(Dto);
        }

        /// <summary>
        /// Checks if a meeting time exists for the specified start time and date.
        /// </summary>
        /// <param name="startTime">The start time of the meeting.</param>
        /// <param name="numberDate">The date of the meeting.</param>
        /// <returns>
        /// <c>true</c> if a meeting time exists; otherwise, <c>false</c>.
        /// </returns>
        public static async Task<bool> DoesMeetingTimeExistAsync(TimeOnly startTime, DateOnly numberDate)
        {
            return await MeetingTimeData.DoesMeetingTimeExistAsync(startTime, numberDate);
        }

        /// <summary>
        /// Retrieves all meeting time records as a list of <see cref="MeetingTimeDto"/>.
        /// </summary>
        /// <returns>
        /// A list of <see cref="MeetingTimeDto"/> containing all meeting time details, or <c>null</c> if an error occurs or not any meeting time.
        /// </returns>
        public static async Task<List<MeetingTimeDto>?> GetAllMeetingTimeDetailsAsync()
        {
           return await MeetingTimeData.GetAllMeetingTimeDetailsAsync();
        }
    }
}