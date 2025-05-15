using Data_Access.Context;
using Data_Access.DTOs.Payment_DTOs;
using static Data_Access.GlobalUtilities.ExceptionHandle;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Data_Access.Models;
using System.Threading.Tasks;
namespace OperationsClasses;

/// <summary>
/// Provides data access operations for payment-related entities using Entity Framework Core as the ORM and SQL Server as the data provider.
/// </summary>
/// <remarks>
/// This class contains static methods for retrieving and counting payment records, including support for both LINQ-based and stored procedure-based queries.
/// </remarks>
public class PaymentData
{
    
    /// <summary>
    /// Retrieves all payment records by joining the Payments and StudentGroups tables.
    /// </summary>
    /// <returns>
    /// A list of <see cref="PaymentDto"/> objects representing all payments, or null if an exception occurs.
    /// </returns>
    /// <remarks>
    /// Uses LINQ to Entities for querying. Results are ordered by payment date.
    /// </remarks>
    public static async Task<List<PaymentDto>?> GetAllPaymentsAsync()
    {
        using (AppDbContext context = new())
        {
            return await TryCatchAsync(async () =>
            {
                var result = await (
                    from payment in context.Payments
                    join studentGroup in context.StudentGroups
                        on payment.StudentGroupId equals studentGroup.StudentGroupId
                    orderby payment.PaymentDate
                    select new PaymentDto
                    {
                        PaymentId = payment.PaymentId,
                        GroupId = studentGroup.GroupId,
                        StudentsID = studentGroup.StudentsId,
                        SubjectGradeLevelId = payment.SubjectGradeLevelId,
                        PaymentAmount = payment.PaymentAmount,
                        PaymentDate = payment.PaymentDate
                    }).ToListAsync();

                return result;
            });
        }
    }

    /// <summary>
    /// Retrieves all payment records using a stored procedure.
    /// </summary>
    /// <returns>
    /// A list of <see cref="PaymentDto"/> objects representing all payments, or null if an exception occurs.
    /// </returns>
    /// <remarks>
    /// Executes the "SP_GetAllPayments" stored procedure in SQL Server using Entity Framework Core.
    /// </remarks>
    public static async Task<List<PaymentDto>?> GetAllPayments_SP_Async()
    {
        using (AppDbContext context = new())
        {
            return await TryCatchAsync(async () =>
            {
                return await context.Set<PaymentDto>().FromSqlRaw("SP_GetAllPayments").ToListAsync();
            });
        }
    }

    /// <summary>
    /// Gets the total count of payment records in the Payments table.
    /// </summary>
    /// <returns>
    /// The number of payment records.
    /// </returns>
    public static async Task<int> GetAllPaymentsCountAsync()
    {
        using (AppDbContext context = new())
        {
            return await TryCatchAsync(async () => { return await context.Payments.CountAsync(); });
        }
    }
}
