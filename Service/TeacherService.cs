using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Information_System.Exceptions;
using Student_Information_System.Models;
using Student_Information_System.Repositories;

namespace Student_Information_System.Service
{
    internal class TeacherService
    {
        private readonly TeacherRepository _teacherRepository;

        public TeacherService()
        {
            _teacherRepository = new TeacherRepository();
        }

        public void DisplayTeacherRecords()
        {
            _teacherRepository.displayTeacherInfo();
        }

        public void UpdateTeacherRecords(Teacher teacher)
        {
            _teacherRepository.UpdateTeacherInfo(teacher);
        }

        public void GetAssignedCoursesByTeacherId(int teacherId)
        {
            _teacherRepository.GetAssignedCourses(teacherId);
        }

        public void TeacherMenu()
        {
            Teacher teacher = new Teacher();
            int choice = 0;
            do
            {
                Console.Clear();    
                Console.WriteLine("Teacher Management::");
                Console.WriteLine($"1: Update teacher Records \n2: Get Assigned Course for Teacher\n3: Display Teacher Information\n4: Back to Main menu...\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter teacher id: ");
                        int t_id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter first name: ");
                        string t_fname = Console.ReadLine();
                        Console.WriteLine("Enter last name: ");
                        string t_lname = Console.ReadLine();
                        Console.WriteLine("Enter email: ");
                        string t_email = Console.ReadLine();
                        Teacher teacher1 = new Teacher(t_id, t_fname, t_lname, t_email);
                        UpdateTeacherRecords(teacher1);
                        Console.WriteLine("Updated Teacher records successfully..");
                        break;

                    case 2:
                        Console.WriteLine("Enter teacher id: ");
                        int teacherId = int.Parse(Console.ReadLine());
                        GetAssignedCoursesByTeacherId(teacherId);
                        break;

                    case 3:
                        Console.WriteLine("Teacher details: ");
                        DisplayTeacherRecords();
                        break;

                    case 4:
                        Console.WriteLine("Redirecting...");
                        break;

                    default:
                        Console.WriteLine("Try again!!!");
                        break;
                }
            } while (choice != 4);
        }
    }
}
