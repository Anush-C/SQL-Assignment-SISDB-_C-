using Student_Information_System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Information_System.Exceptions;
using Student_Information_System.Models;

namespace Student_Information_System.Service
{
    internal class CourseService
    {
        private readonly CourseRepository _courseRepository;

        public CourseService()
        {
            _courseRepository = new CourseRepository();
        }

        public void AssignTeacherToCourse(Teacher teacher, Course course)
        {
            try
            {
                TeacherNotFoundException.TeacherNotFound(teacher);
                CourseNotFoundException.CourseNotFound(course);
                _courseRepository.AssignTeacher(teacher, course);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetEnrollmentByCourse(int course_id)
        {
            try
            {
                Course course = new Course();
                course.CourseID = course_id;
                CourseNotFoundException.CourseNotFound(course);
                _courseRepository.GetEnrollments(course_id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void GetTeacherByCourse(string courseName)
        {
            try
            {
                Course course = new Course();
                course.CourseName = courseName;
                InvalidCourseDataException.InvalidCourseData(course);
                _courseRepository.GetTeacher(courseName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateCourseDetails(Course course)
        {
            try
            {
                CourseNotFoundException.CourseNotFound(course);
                _courseRepository.UpdateCourseInfo(course);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DisplayCourse()
        {
            _courseRepository.DisplayCourseInfo();
        }

        public void CourseMenu()
        {
            Course course = new Course();
            int choice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Course Management::");
                Console.WriteLine($"1: Update Course\n2: Get enrollments\n3: Get teacher\n4: Display course Records\n5: Assign Teacher\n6: Back to Main menu..\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter course id: ");
                        int co_id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter course name: ");
                        string co_name = Console.ReadLine();
                        Console.WriteLine("Enter course credits: ");
                        int co_credits = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter instructor id: ");
                        int co_instructorId = int.Parse(Console.ReadLine());
                        Course course1 = new Course(co_id, co_name, co_credits, co_instructorId);
                        UpdateCourseDetails(course1);
                        Console.WriteLine($"Updated succesfully...");
                        break;

                    case 2:
                        Console.WriteLine("Enter course id: ");
                        int course_id = int.Parse(Console.ReadLine());
                        GetEnrollmentByCourse(course_id);
             
                        break;

                    case 3:
                        Console.WriteLine("Enter course name: ");
                        string course_name = Console.ReadLine();
                        GetTeacherByCourse(course_name);
                       
                        break;

                    case 4:
                        Console.WriteLine("Course List: ");
                        DisplayCourse();
                        break;

                    case 5:
                        Console.WriteLine("Enter teacher id: ");
                        int t_id = int.Parse(Console.ReadLine());
                        Teacher teachers = new Teacher() { TeacherID = t_id };
                        Console.WriteLine("Enter course id: ");
                        int cid = int.Parse(Console.ReadLine());
                        Course course2 = new Course();
                        course2.CourseID = cid;
                        AssignTeacherToCourse(teachers, course2);
                        break;

                    case 6:
                        Console.WriteLine("Redirecting..");
                        break;

                    default:
                        Console.WriteLine("Try again!!!");
                        break;
                }
            } while (choice != 6);
        }
    }
}
