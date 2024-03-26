using System;
using Student_Information_System.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Information_System.Repositories;

namespace Student_Information_System.Exceptions
{
    internal class InvalidCourseDataException : Exception
    {
        public InvalidCourseDataException(string message) : base(message) { }


        public static void InvalidCourseData(Course course)
        {
            if (course.CourseID == 0)
            {
                throw new InvalidCourseDataException("CourseID cannot be zero. Please enter a valid Course ID");
            }
            else if(course.CourseCode== null)
            {
                throw new InvalidCourseDataException("CourseCode is invalid. Please enter a valid Course Code");

            }
           else if(course.CourseName== null)
            {
                throw new InvalidCourseDataException("CourseName is invalid. Please enter a valid Course Name");
            }
            else if(course.InstructorName== null)
            {
                throw new InvalidCourseDataException("InstructorName is invalid. Please enter a valid Instructor Name");
            }
        }
    }
}
