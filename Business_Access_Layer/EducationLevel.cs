using Data_Access.Context;
using Data_Access.DTOs.EducationLevel_DTOs;
using Data_Access.DTOs.Teacher_DTOs;
using OperationsClasses;
using System.Threading.Tasks;

namespace Business_Access
{

    /// <summary>
    /// Represents an education level entity with properties and methods for accessing and manipulating education level data.
    /// </summary>
    namespace Business_Access
    {
        public class EducationLevel
        {
           
            public int? EducationLevelId { get; set; }
            public string LevelName { get; set; } = null!;

            //in future it well contain all teachers in this educational level
           //public List<TeacherDto> TeachersInThis_Edu_Level { get { return new List<TeacherDto>(); } }


            /// <summary>
            /// This property made to return the EducationLevel object properties only not return other methods to use it with API,
            /// and it also read only
            /// </summary>
            public EducationLevelDto Dto
            {
                get
                {
                    return new EducationLevelDto
                    {
                        EducationLevelId = this.EducationLevelId,
                        LevelName = this.LevelName,
                    };
                }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="EducationLevel"/> class.
            /// </summary>
            public EducationLevel()
            {
                EducationLevelId = null;
                LevelName = null!;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="EducationLevel"/> class using the specified DTO.
            /// </summary>
            /// <param name="dto">The data transfer object containing education level data.</param>
            public EducationLevel(EducationLevelDto dto)
            {
                EducationLevelId = dto.EducationLevelId;
                LevelName = dto.LevelName;
            }

            /// <summary>
            /// Returns a new <see cref="EducationLevel"/> object if a EducationLevel with the specified ID is found; otherwise, returns null.
            /// </summary>
            /// <param name="eduId">The Education Level ID to search for.</param>
            /// <returns>A <see cref="EducationLevel"/> object or null if not found.</returns>
            public static async Task<EducationLevel?> Find(int eduId)
            {
                var dto = await EducationLevelData.GetInfoByIDAsync(eduId);

                return dto == null ? null : new EducationLevel(dto);
            }

            /// <summary>
            /// Asynchronously retrieves a list of all education level names from the database.
            /// </summary>
            /// <returns>
            /// A <see cref="Task{TResult}"/> representing the asynchronous operation, containing a list of education level names, or <c>null</c> if an error occurs.
            /// </returns>
            public static async Task<List<string>?> GetEducationLevelNamesAsync()
            {
                return await EducationLevelData.GetEducationLevelNamesAsync();
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
                return await EducationLevelData.GetEducationLevelIDAsync(educationLevelName);
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
                return await EducationLevelData.GetEducationLevelNameAsync(educationLevelID);
            }
        }
    }

}