using System;
using System.Data.SqlClient;
using Student_Information_System.Models;
using Student_Information_System.Utility;

namespace Student_Information_System.Repositories
{
    internal class PaymentRepository
    {
        SqlConnection connect = null;
        SqlCommand cmd = null;

        public PaymentRepository()
        {
            connect = new SqlConnection(DBConnectUtil.GetConnectionString());
            cmd = new SqlCommand();
        }
       

        public void GetPaymentAmount(int paymentId)
        {
            cmd.CommandText = "Select amount from Payments where payment_id=@py_id";
            cmd.Parameters.AddWithValue("@py_id", paymentId);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int amount = (int)reader["amount"];
                Console.WriteLine($"Amount : {amount}");
            }
            connect.Close();
        }

        public void GetStudent(int paymentId)
        {
            cmd.CommandText = "Select * from Payments where payment_id=@p_id";
            cmd.Parameters.AddWithValue("@p_id", paymentId);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Payment payment = new Payment();
                payment.PaymentID = (int)reader["payment_id"];
                payment.StudentID = Convert.IsDBNull(reader["student_id"]) ? null : (int)reader["student_id"];
                payment.Amount = Convert.IsDBNull(reader["amount"]) ? null : (int)reader["amount"];
                payment.PaymentDate = (DateTime)reader["payment_date"];
                Console.WriteLine($"Payment details for the student:: {payment}");
            }
            connect.Close();
        }

        public void GetPaymentdate(int paymentId)
        {
            cmd.CommandText = "Select payment_date from Payments where payment_id=@py_id";
            cmd.Parameters.AddWithValue("@py_id", paymentId);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime date = (DateTime)reader["payment_date"];
                Console.WriteLine($"Payment Date : {date}");
            }
            connect.Close();
        }

    }
}
