using Data_Access.Context;
using Data_Access.DTOs.Payment_DTOs;
using OperationsClasses;

namespace Business_Access
{
    public class Payment
    {
        public enum enMode { Add, Update }
        public enMode mode = enMode.Add;
        public int? PaymentId { get; set; }
        public int StudentsID { get; set; }
        public int GroupId { get; set; }
        public decimal PaymentAmount { get; set; }
        public int SubjectGradeLevelId { get; set; }
        public DateTime? PaymentDate { get; set; }

        /// <summary>
        /// This property made to return the class object properties only not return other methods to use it with API,
        /// and it also read only
        /// </summary>
        public PaymentDto dto
        {
            get
            {
                return new PaymentDto
                {
                    PaymentId = this.PaymentId,
                    StudentsID = this.StudentsID,
                    GroupId = this.GroupId,
                    PaymentAmount = this.PaymentAmount,
                    SubjectGradeLevelId = this.SubjectGradeLevelId,
                    PaymentDate = this.PaymentDate
                };
            }
        }

        public Payment() {

            this.mode = enMode.Add;
            this.PaymentId = null;
            this.StudentsID = 0;
            this.GroupId = 0;
            this.PaymentAmount = 0;
            this.SubjectGradeLevelId = 0;
            this.PaymentDate = null;

        }

        public Payment(PaymentDto dto)
        {
            this.mode = enMode.Update;
            this.PaymentId = dto.PaymentId;
            this.StudentsID = dto.StudentsID;
            this.GroupId = dto.GroupId;
            this.PaymentAmount = dto.PaymentAmount;
            this.SubjectGradeLevelId = dto.SubjectGradeLevelId;
            this.PaymentDate = dto.PaymentDate;
        }

        /*
         
        make find by id and more in the future
         
         */

        /// <summary>
        /// Retrieves all payment records.
        /// </summary>
        /// <returns>
        /// A list of <see cref="PaymentDto"/> objects representing all payments, or null if an exception occurs.
        /// </returns>
        /// <remarks>
        /// Uses LINQ to Entities for querying. Results are ordered by payment date.
        /// </remarks>
        public static async Task<List<PaymentDto>?> GetAllPaymentsAsync()
        {
            return await PaymentData.GetAllPaymentsAsync();
        }

        /// <summary>
        /// Retrieves all payment records using a stored procedure.
        /// </summary>
        /// <returns>
        /// A list of <see cref="PaymentDto"/> objects representing all payments, or null if an exception occurs or not any payment.
        /// </returns>
        
        public static async Task<List<PaymentDto>?> GetAllPayments_SP_Async()
        {
            return await PaymentData.GetAllPayments_SP_Async();
        }

        /// <summary>
        /// Gets the total count of payment records in the Payments table.
        /// </summary>
        /// <returns>
        /// The number of payment records.
        /// </returns>
        public static async Task<int> GetAllPaymentsCountAsync()
        {
            return await PaymentData.GetAllPaymentsCountAsync();
        }
    }
}
