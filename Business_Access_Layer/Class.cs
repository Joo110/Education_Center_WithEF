using Data_Access.DTOs.Group_DTOs;
using OperationsClasses;

/// <summary>
/// Represents a business logic layer class for managing class entities, including creation, update, and retrieval operations.
/// </summary>
/// <remarks>
/// Provides methods for adding, updating, and finding class records, as well as retrieving class counts and lists.
/// </remarks>
public class Class
{
    public enum enMode { Add, Update }
    public enMode mode;
    public int? classId { get; set; }
    public string className { get; set; } = null!;
    public int capacity { get; set; }
    public string? Description { get; set; }

    //in future it contain all group in current class
    //public List<GroupDto> GroupsInClass { get { return new List<GroupDto>(); } }

    /// <summary>
    /// This property made to return the class object properties only not return other methods to use it with API and Add and Update as parameter,
    /// and it also read only
    /// </summary>
    public ClassDto dto
    {
        get
        {
            return new ClassDto
            {
                classId = this.classId,
                capacity = this.capacity,
                classname = this.className,
                Description = this.Description
            };
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Class"/> class with default values.
    /// </summary>
    public Class()
    {

        this.classId = null;
        this.className = string.Empty;
        this.capacity = 0;
        this.Description = null;
        mode = enMode.Add;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Class"/> class using a <see cref="ClassDto"/> object.
    /// </summary>
    /// <param name="Dto">The data transfer object containing class information.</param>
    public Class(ClassDto Dto)
    {
        this.classId = Dto.classId;
        this.className = Dto.classname;
        this.capacity = Dto.capacity;
        this.Description = Dto.Description;
        mode = enMode.Update;
    }

    /// <summary>
    /// Adds a new class asynchronously to the data store.
    /// </summary>
    /// <returns>True if the class was added successfully; otherwise, false.</returns>
    private async Task<bool> _AddAsync()
    {
        this.classId = await ClassData.AddAsync(dto);

        return this.classId != null;
    }

    /// <summary>
    /// Updates an existing class asynchronously in the data store.
    /// </summary>
    /// <returns>True if the class was updated successfully; otherwise, false.</returns>
    private async Task<bool> _UpdateAsync()
    {
        return await ClassData.UpdateAsync(dto);
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
    /// Returns a new <see cref="Class"/> object if a class with the specified ID is found; otherwise, returns null.
    /// </summary>
    /// <param name="classID">The class ID to search for.</param>
    /// <returns>A <see cref="Class"/> object or null if not found.</returns>
    public static async Task<Class?> Find(int classID)
    {
        var Dto = await ClassData.GetInfoByIDAsync(classID);

        return Dto != null ? new Class(Dto) : null;
    }

    /// <summary>
    /// Gets the total count of all classes.
    /// </summary>
    /// <returns>The number of classes, or null if unavailable.</returns>
    public static int? GetAllClassesCount()
    {
        return ClassData.GetAllClassesCount();
    }

    /// <summary>
    /// Asynchronously retrieves a list of all class data transfer objects.
    /// </summary>
    /// <returns>A list of <see cref="ClassDto"/> objects, or null if none are found.</returns>
    public static async Task<List<ClassDto>?> GetAllClassesAsync()
    {
        return await ClassData.GetAllClassesAsync();
    }
}
