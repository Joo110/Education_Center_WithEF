using Data_Access.DTOs.GradeLevel_DTOs;
using Data_Access.DTOs.Student_DTOs;
using OperationsClasses;

namespace Business_Access

{
    /// <summary>
    /// Represents a grade level in the education system, providing methods for retrieving grade level information
    /// and converting between data transfer objects (DTOs) and business objects.
    /// </summary>
    /// <remarks>
    /// This class encapsulates the business logic related to grade levels, including methods for finding grade levels,
    /// retrieving grade level names and IDs, and converting to DTOs for API usage.
    /// </remarks>
    public class GradeLevel
    {
        
        public int? GradeLevelId { get; set; }
        public string? GradeName { get; set; }

        //in future it contain all group in current class
       // public List<StudentDto> StudentsInThisGrade { get { return new List<StudentDto>(); } }

        /// <summary>
        /// This property made to return the GradeLevel object properties only not return other methods to use it with API,
        /// and it also read only
        /// </summary>
        public GradeLevelDto Dto 
        { 
            get
            {
                return new GradeLevelDto
                {
                    GradeLevelId = this.GradeLevelId,
                    GradeName = this.GradeName,
                };
             } 
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GradeLevel"/> class.
        /// </summary>
        public GradeLevel()
        {
            GradeLevelId = null;
            GradeName = null!;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GradeLevel"/> class using the specified DTO.
        /// </summary>
        /// <param name="dto">The data transfer object containing education level data.</param>
        public GradeLevel(GradeLevelDto dto)
        {
            GradeLevelId = dto.GradeLevelId;
            GradeName = dto.GradeName;
        }

        /// <summary>
        /// Returns a new <see cref="GradeLevel"/> object if a GradeLevel with the specified ID is found; otherwise, returns null.
        /// </summary>
        /// <param name="GradeLevelID">The Education Level ID to search for.</param>
        /// <returns>A <see cref="GradeLevel"/> object or null if not found.</returns>
        public static async Task<GradeLevel?> Find(int GradeLevelID)
        {
            var dto = await GradeLevelData.GetInfoByIDAsync(GradeLevelID);

            return dto == null ? null : new GradeLevel (dto);
        }

        /// <summary>
        /// Asynchronously retrieves all grade level names from the database.
        /// </summary>
        /// <returns>
        /// A task representing the asynchronous operation. The task result contains a list of grade level names, or null if an error occurs.
        /// </returns>
        public static async Task<List<string>?> GetAllGradeLevelsNameAsync()
        {
           return await GradeLevelData.GetAllGradeLevelsNameAsync();
        }

        /// <summary>
        /// Retrieves the name of a grade level by its ID.
        /// </summary>
        /// <param name="gradeLevelID">The ID of the grade level.</param>
        /// <returns>
        /// The name of the grade level if found; otherwise, null.
        /// </returns>
        public static async Task<string?> GetGradeLevelNameAsync(int? gradeLevelID)
        {
            return await GradeLevelData.GetGradeLevelNameAsync(gradeLevelID);
        }

        /// <summary>
        /// Retrieves the ID of a grade level by its name.
        /// </summary>
        /// <param name="gradeName">The name of the grade level.</param>
        /// <returns>
        /// The ID of the grade level if found; otherwise, null.
        /// </returns>
        public static async Task<int?> GetGradeLevelIDAsync(string gradeName)
        {
            return await GradeLevelData.GetGradeLevelIDAsync(gradeName);
        }

       
    }
}
