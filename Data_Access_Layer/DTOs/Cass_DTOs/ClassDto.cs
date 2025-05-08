
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

 [Keyless]
public partial class ClassDto
{
   
    public int classId { get; set; } 
    public string classname { get; set; } = null!;
    public int capacity { get; set; }
    public string? Description { get; set; }

    public override string ToString()
    {
        return $"classId = {classId},  classname = {classname}, capacity = {capacity}, Description = {Description}";
    }
}
