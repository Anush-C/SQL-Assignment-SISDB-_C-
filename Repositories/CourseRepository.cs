using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Student_Information_System.Models;
using Student_Information_System.Utility;

namespace Student_Information_System.Repositories
{
    internal class CourseRepository
    {
        SqlConnection connect = null;
        SqlCommand cmd = null;

        public CourseRepository()
        {
            connect = new SqlConnection(DBConnectUtil.GetConnectionString());
            cmd = new SqlCommand();
        }

        public void AssignTeacher(Teacher teacher, Course course)
        {
            cmd.CommandText = "Update Courses set teacher_id=@teach_id where course_id=@cse_id and teacher_id is null";
            cmd.Parameters.AddWithValue("@tech_id", teacher.TeacherID);
            cmd.Parameters.AddWithValue("@cse_id", course.CourseID);
            connect.Open();
            cmd.Connection = connect;
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        public void GetEnrollments(int course_id)
        {
            List<Enrollment> enrollments = new List<Enrollment>();
            cmd.CommandText = "Select * from Enrollments where course_id=@cse_id";
            cmd.Parameters.AddWithValue("@cse_id", course_id);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Enrollment enrollment = new Enrollment();
                enrollment.EnrollmentID = (int)reader["enrollment_id"];
                enrollment.StudentID = Convert.IsDBNull(reader["student_id"]) ? null : (int)reader["student_id"];
                enrollment.CourseID =  (int)reader["course_id"];
                enrollment.EnrollmentDate = (DateTime)reader["enrollment_date"];
                enrollments.Add(enrollment);
            }
            foreach (Enrollment enrollment in enrollments)
            {
                Console.WriteLine(enrollment);
            }
            connect.Close();
        }

        public void GetTeacher(string course_name)
        {
            cmd.CommandText = "Select CONCAT_WS(' ',first_name,last_name) as Teacher from Teacher t JOIN Courses c on t.teacher_id=c.teacher_id where c.course_name=@co_name";
            cmd.Parameters.AddWithValue("@c_name", course_name);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string teachername = (string)reader["Teacher"];
                Console.WriteLine($"Teacher for the course:: {teachername}");
            }
            connect.Close();
        }

        public void UpdateCourseInfo(Course course)
        {
            cmd.CommandText = "Update Courses set course_name=@name,credits=@credit,teacher_id=@t_id where course_id=@co_id";
            cmd.Parameters.AddWithValue("@name", course.CourseName);
            cmd.Parameters.AddWithValue("@credit", course.Credits);
            cmd.Parameters.AddWithValue("@t_id", course.InstructorName);
            connect.Open();
            cmd.Connection = connect;
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        public void DisplayCourseInfo()
        {
            List<Course> courses = new List<Course>();
            cmd.CommandText = "Select * from Courses";
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Course course = new Course();
                course.CourseID = (int)reader["course_id"];
                course.CourseName = (string)reader["course_name"];
                course.Credits = Convert.IsDBNull(reader["credits"]) ? null : (int)reader["credits"];
                course.InstructorID = Convert.IsDBNull(reader["teacher_id"]) ? null : (int)reader["teacher_id"];
                courses.Add(course);
            }
            foreach (Course course in courses)
            {
                Console.WriteLine(course);
            }
            connect.Close();
        }

        public bool CourseExists(Course course)
        {
            int cnt = 0;
            cmd.CommandText = "Select count(*) as totalcourses from Courses where course_id=@cse_id";
            cmd.Parameters.AddWithValue("@cse_id", course.CourseID);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cnt= (int)reader["totalcourses"];
            }
            connect.Close();
            if (cnt > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
