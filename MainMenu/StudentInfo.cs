using Student_Information_System.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.MainMenu
{
    internal class StudentInfo
    {
        StudentService studentService;
        CourseService courseService;
        EnrollmentService enrollmentService;
        TeacherService teacherService;
        PaymentService paymentService;

        public StudentInfo()
        {
            studentService = new StudentService();
            courseService = new CourseService();
            enrollmentService = new EnrollmentService();
            teacherService = new TeacherService();
            paymentService = new PaymentService();
        }

        public void MainMenu()
        {
            int choice = 0;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=======================================");
                Console.WriteLine("|        Welcome to our Student         |");
                Console.WriteLine("|       Information System (SIS)        |");
                Console.WriteLine("=======================================");
                Console.ResetColor();
                Console.WriteLine("Main Menu::\n");
                Console.WriteLine("1: Student Records");
                Console.WriteLine("2: Course Records");
                Console.WriteLine("3: Enrollment Records");
                Console.WriteLine("4: Teacher Records");
                Console.WriteLine("5: Payment Records");
                Console.WriteLine("6: Exit");

                Console.WriteLine("\nEnter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        studentService.StudentMenu();
                        break;

                    case 2:
                        courseService.CourseMenu();
                        break;

                    case 3:
                        enrollmentService.EnrollmentMenu();
                        break;

                    case 4:
                        teacherService.TeacherMenu();
                        break;

                    case 5:
                        paymentService.PaymentMenu();
                        break;

                    case 6:
                        Console.WriteLine("Redirecting...");
                        break;

                    default:
                        Console.WriteLine("Try again...");
                        break;
                }
            } while (choice != 6);
        }
    }
}
