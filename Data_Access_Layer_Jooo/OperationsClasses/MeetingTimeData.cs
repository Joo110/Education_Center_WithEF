using Microsoft.EntityFrameworkCore;
namespace OperationsClasses;


public class MeetingTimeData
{
    /*
     public static bool GetInfoByID(int? meetingTimeID, ref TimeSpan startTime, ref TimeSpan endTime, ref string meetingDays, ref DateTime NumberDate)
         {
             bool isFound = false;

             try
             {
                 using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {
                     connection.Open();

                     using (SqlCommand command = new SqlCommand("SP_GetMeetingTimeInfoByID", connection))
                     {
                         command.CommandType = CommandType.StoredProcedure;

                         command.Parameters.AddWithValue("@MeetingTimeID", (object)meetingTimeID ?? DBNull.Value);

                         using (SqlDataReader reader = command.ExecuteReader())
                         {
                             if (reader.Read())
                             {
                                 // The record was found
                                 isFound = true;

                                 startTime = (TimeSpan)reader["StartTime"];
                                 endTime = (TimeSpan)reader["EndTime"];
                                 meetingDays = (string)reader["MeetingDays"];
                                 NumberDate = (DateTime)reader["NumberDate"];
                             }
                             else
                             {
                                 // The record was not found
                                 isFound = false;
                             }
                         }
                     }
                 }
             }
             catch (Exception ex)
             {
                 isFound = false;
                 clsDataAccessHelper.HandleException(ex);
             }

             return isFound;
         }

         public static int? Add(TimeSpan startTime, TimeSpan endTime, string meetingDays, DateTime NumberDate)
         {
             int? meetingTimeID = null;

             try
             {
                 using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {
                     connection.Open();

                     using (SqlCommand command = new SqlCommand("SP_AddNewMeetingTime", connection))
                     {
                         command.CommandType = CommandType.StoredProcedure;

                         command.Parameters.AddWithValue("@StartTime", startTime);
                         command.Parameters.AddWithValue("@EndTime", endTime);
                         command.Parameters.AddWithValue("@MeetingDays", meetingDays);
                         command.Parameters.AddWithValue("@NumberDate", (object)NumberDate ?? DBNull.Value); // ✅ تصحيح القيم الفارغة

                         SqlParameter outputIdParam = new SqlParameter("@NewMeetingTimeID", SqlDbType.Int)
                         {
                             Direction = ParameterDirection.Output
                         };
                         command.Parameters.Add(outputIdParam);

                         command.ExecuteNonQuery();

                         // ✅ تصحيح المشكلة: التحقق من أن القيمة ليست DBNull.Value
                         if (outputIdParam.Value != DBNull.Value)
                         {
                             meetingTimeID = Convert.ToInt32(outputIdParam.Value);
                         }
                     }
                 }
             }
             catch (Exception ex)
             {
                 clsDataAccessHelper.HandleException(ex);
             }

             return meetingTimeID;
         }

          public static bool Update(int meetingTimeID, TimeSpan startTime, TimeSpan endTime, string meetingDays, DateTime NumberDate)
          {
             int rowAffected = 0;

             try
             {
                 using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                 {
                     connection.Open();

                     using (SqlCommand command = new SqlCommand("SP_UpdateMeetingTime", connection))
                     {
                         command.CommandType = CommandType.StoredProcedure;

                         command.Parameters.AddWithValue("@MeetingTimeID", meetingTimeID);
                         command.Parameters.AddWithValue("@StartTime", startTime);
                         command.Parameters.AddWithValue("@EndTime", endTime);
                         command.Parameters.AddWithValue("@MeetingDays", meetingDays);
                         command.Parameters.AddWithValue("@NumberDate", (object)NumberDate ?? DBNull.Value); // ✅ تصحيح القيم الفارغة

                         rowAffected = command.ExecuteNonQuery();
                     }
                 }
             }
             catch (Exception ex)
             {
                 clsDataAccessHelper.HandleException(ex);
             }

             return (rowAffected > 0);
          }


         public static bool DoesMeetingTimeExist(TimeSpan startTime, DateTime numberDate)
         {
             using (SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString))
             {
                 conn.Open();
                 using (SqlCommand cmd = new SqlCommand("SP_DoesMeetingTimeExistByStartTimeAndMeetingDays", conn))
                 {
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.AddWithValue("@StartTime", startTime);
                     cmd.Parameters.AddWithValue("@NumberDate", numberDate);

                     return (bool)cmd.ExecuteScalar();
                 }
             }
         }


         public static DataTable GetAllMeetingTimeDetails()
         {
             DataTable dt = new DataTable();
             string connectionString = clsDataAccessSettings.ConnectionString;

             using (SqlConnection conn = new SqlConnection(connectionString))
             {
                 using (SqlCommand cmd = new SqlCommand("SP_GetAllMeetingTimeDetails", conn))
                 {
                     cmd.CommandType = CommandType.StoredProcedure;

                     using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                     {
                         da.Fill(dt);
                     }
                 }
             }

             return dt;
         }
     */

}
