using Data_Access.DTOs.Group_DTOs;
using OperationsClasses;


var result = await GroupData.GetAllStudentsInGroupAsync(4);

if (result != null)
    foreach (var item in result)
        Console.WriteLine(item.FullName);
else
    Console.WriteLine("null");