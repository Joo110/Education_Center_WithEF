using Data_Access.Context;
using Data_Access.DTOs.Payment_DTOs;
using static Data_Access.GlobalUtilities.ExceptionHandle;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Data_Access.Models;
namespace OperationsClasses;

public  class PaymentData
{
    /*
     SELECT        dbo.Payments.PaymentID, dbo.StudentGroups.StudentsID, dbo.StudentGroups.GroupID, dbo.Payments.SubjectGradeLevelID, dbo.Payments.PaymentAmount, dbo.Payments.PaymentDate
    FROM            dbo.Payments INNER JOIN
                             dbo.StudentGroups ON dbo.Payments.StudentGroupID = dbo.StudentGroups.StudentGroupID*/
    public static async Task<List<PaymentDto>?> GetAllPayments()
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
     public static async Task<List<PaymentDto>?> GetAllPayments_SP()
    {
        using (AppDbContext context = new())
        {
            return await TryCatchAsync(async () =>
            {
                return await context.Set<PaymentDto>().FromSqlRaw("SP_GetAllPayments").ToListAsync();

            });

    }
    }


    public static int GetAllPaymentsCount()
    {
        using (AppDbContext context = new())
        {
            return context.Payments.Count();
        }
    }
}
