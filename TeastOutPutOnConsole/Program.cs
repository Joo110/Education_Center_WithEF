// See https://aka.ms/new-console-template for more information
using OperationsClasses;

ClassDto dto = new ClassDto
{
    classname = "Class 3",
    capacity = 100,
    Description = "For test"
};
await ClassData.AddAsync(dto);
List<ClassDto>? result = await ClassData.GetAllClassesAsync();
if (result != null)
    foreach (var item in result)
        Console.WriteLine(item.ToString());
