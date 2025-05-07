// See https://aka.ms/new-console-template for more information
using OperationsClasses;
var result = await ClassData.GetInfoByIDAsync(1);
Console.WriteLine(result.ToString());
