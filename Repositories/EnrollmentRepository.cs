using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Information_System.Models;
using Student_Information_System.Utility;

namespace Student_Information_System.Repositories
{
    internal class EnrollmentRepository
    {
        SqlConnection connect = null;
        SqlCommand cmd = null;


        public EnrollmentRepository()
        {
            connect = new SqlConnection(DBConnectUtil.GetConnectionString());
            cmd = new SqlCommand();
        }
        public void GetStudent(int enrollment_id)
        {
            cmd.CommandText = "Select student_id from Enrollments where enrollment_id=@en_id";
            cmd.Parameters.AddWithValue("@en_id", enrollment_id);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int student_id = (int)reader["student_id"];
                Console.WriteLine($"Student enrolled in a course: {student_id}");
            }
            connect.Close();
        }

        public void GetCourse(int enrollment_id)
        {
            cmd.CommandText = "Select course_id from Enrollments where enrollment_id=@en_id";
            cmd.Parameters.AddWithValue("@en_id", enrollment_id);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int course_id = (int)reader["course_id"];
                Console.WriteLine($"Course enrolled for this Enrollment id: {course_id}");
            }
            connect.Close();
        }

        public bool DuplicateEnrollmentExists(Enrollment enrollment)
        {
            int count = 0;
            cmd.CommandText = "Select count(*) as total from Enrollments where student_id=@st_id and course_id=@co_id";
            cmd.Parameters.AddWithValue("@st_id", enrollment.StudentID);
            cmd.Parameters.AddWithValue("@co_id", enrollment.CourseID);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                count = (int)reader["total"];
            }
            connect.Close();
            if (count > 1)
            {
                return true;
            }
            return false;
        }
    }
}
