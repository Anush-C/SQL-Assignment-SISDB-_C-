using Student_Information_System.Models;
using Student_Information_System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Exceptions
{
    internal class CourseNotFoundException : Exception
    {

        public CourseNotFoundException(string message) : base(message) { }
        public static void CourseNotFound(Course course) {
            //if (course.CourseID == 0)
            //{
            //    throw new CourseNotFoundException("CourseID does not exits. Please try again..");
            //}
            //if (course.CourseName == null)
            //{
            //    throw new CourseNotFoundException("CourseName does not exits. Please try again..");

            //}
            CourseRepository courseRepository = new CourseRepository();
            if(!courseRepository.CourseExists(course))
            {
                throw new CourseNotFoundException("Course does not found. Please try again..");
            }
        }
    }
}
    