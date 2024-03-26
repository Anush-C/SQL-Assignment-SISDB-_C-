using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Information_System.Repositories;
using Student_Information_System.Exceptions;
using Student_Information_System.Models;

namespace Student_Information_System.Service
{
    internal class EnrollmentService
    {
        private readonly EnrollmentRepository _enrollmentRepository;

        public EnrollmentService()
        {
            _enrollmentRepository = new EnrollmentRepository();
        }

        public void GetStudentByEnrollment(int enrollmentId)
        {
            _enrollmentRepository.GetStudent(enrollmentId);
        }

        public void GetCourseByEnrollments(int enrollmentId)
        {
            _enrollmentRepository.GetCourse(enrollmentId);
        }

        public void EnrollmentMenu()
        {
            Enrollment enrollment = new Enrollment();
            int choice = 0;
            do
            {
                Console.Clear();    
                Console.WriteLine("Enrollment Management::");
                Console.WriteLine($"1: Get Student Enrollments\n2: Get Course Enrollments\n3: Back to Main menu..\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter enrollment id: ");
                        int enrollmentId = int.Parse(Console.ReadLine());
                        GetStudentByEnrollment(enrollmentId);
                        break;

                    case 2:
                        Console.WriteLine("Enter enrollment id: ");
                        int enrollment_Id = int.Parse(Console.ReadLine());
                        GetCourseByEnrollments(enrollment_Id);
                        break;

                    case 3:
                        Console.WriteLine("Redirecting..");
                        break;

                    default:
                        Console.WriteLine("Try again!!!");
                        break;
                }
            } while (choice != 3);
        }
    }
}
