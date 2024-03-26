using Student_Information_System.Repositories;
using Student_Information_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Information_System.Exceptions;


namespace Student_Information_System.Service
{
    internal class StudentService
    {
        private readonly StudentRepository _studentRepository;

        public StudentService()
        {
            _studentRepository = new StudentRepository();
        }

        public void AddStudentRecords(Student student)
        {
            try
            {
                InvalidStudentDataException.InvalidStudentData(student);
                _studentRepository.InsertRecords(student);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public void UpdateStudentRecords(Student student)
        {

            try
            {
                InvalidStudentDataException.InvalidStudentData(student);
                _studentRepository.UpdateStudentInfo(student);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }

        public void EnrollStudentInCourse(Course course, int studentID)
        {
            try
            {
                CourseNotFoundException.CourseNotFound(course);
                Enrollment enrollment = new Enrollment();
                enrollment.CourseID = course.CourseID;
                enrollment.StudentID = studentID;
                DuplicateEnrollmentException.DuplicateEnrollment(enrollment);
                _studentRepository.EnrollInCourse(course, studentID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void MakePaymentByStudentId(int studentId, int amount, DateTime payment_date)
        {
            try
            {
                Payment payment = new Payment();
                payment.Amount = amount;
                payment.PaymentDate = payment_date;
                PaymentValidationException.PaymentValidData(payment);
                _studentRepository.MakePayment(studentId, amount, payment_date);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetEnrolledCoursesbyStudentId(int studentId)
        {
            try
            {
                StudentNotFoundException.StudentNotFound(studentId);
                _studentRepository.GetEnrolledCourses(studentId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetPaymentByStudentId(int studentId)
        {
            try
            {
                StudentNotFoundException.StudentNotFound(studentId);
                _studentRepository.GetPaymentHistory(studentId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DisplayStudentRecords()
        {
            _studentRepository.DisplayStudentInfo();
        }

        public void StudentMenu()
        {
            int choice = 0;
            do
            {
                Console.Clear();    
                Console.WriteLine("Student Management::");
                Console.WriteLine($"1: Insert Student Records\n2: Update Student Records\n3: Enroll Student in Course\n4: Make Payment\n5: Display Student Records\n6: Get enrolled courses\n7: Get payment history\n8: Back to Main menu..\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                Student student = new Student();
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter first name: ");
                        string fname = Console.ReadLine();
                        Console.WriteLine("Enter last name: ");
                        string lname = Console.ReadLine();
                        Console.WriteLine("Enter date of birth (yyyy-mm-dd): ");
                        string dob = Console.ReadLine();
                        Console.WriteLine("Enter email: ");
                        string email = Console.ReadLine();
                        Console.WriteLine("Enter phone number: ");
                        int phno = int.Parse(Console.ReadLine());
                        student = new Student() { FirstName = fname, LastName = lname, DateOfBirth = DateTime.Parse(dob), Email = email, PhoneNumber = phno };
                        AddStudentRecords(student);
                        Console.WriteLine("Record inserted successfully");
                        break;

                    case 2:
                        Console.WriteLine("Enter Student id to be updated: ");
                        int st_id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter first name: ");
                        string st_fname = Console.ReadLine();
                        Console.WriteLine("Enter last name: ");
                        string st_lname = Console.ReadLine();
                        Console.WriteLine("Enter date of birth (yyyy-mm-dd): ");
                        string st_dob = Console.ReadLine();
                        Console.WriteLine("Enter email: ");
                        string st_email = Console.ReadLine();
                        Console.WriteLine("Enter phone number: ");
                        int st_phno = int.Parse(Console.ReadLine());
                        Student student1 = new Student(st_id, st_fname, st_lname, DateTime.Parse(st_dob), st_email, st_phno);
                        UpdateStudentRecords(student1);
                        Console.WriteLine("Student Record updated successfully...");
                        break;

                    case 3:
                        Console.WriteLine("Enter Course id: ");
                        int co_id = int.Parse(Console.ReadLine());
                        Course courses = new Course();
                        courses.CourseID = co_id;
                        Console.WriteLine("Enter student id: ");
                        int s_id = int.Parse(Console.ReadLine());
                        EnrollStudentInCourse(courses, s_id);
                        break;

                    case 4:
                        Console.WriteLine("Enter student id: ");
                        int studentid = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter amount");
                        int amount = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter payment date");
                        DateTime payment_date = DateTime.Parse(Console.ReadLine());
                        MakePaymentByStudentId(studentid, amount, payment_date);
                        break;

                    case 5:
                        Console.WriteLine("List of students: ");
                        DisplayStudentRecords();
                        break;

                    case 6:
                        Console.WriteLine("Enter student id: ");
                        int s_id1 = int.Parse(Console.ReadLine());
                        GetEnrolledCoursesbyStudentId(s_id1);
                        break;

                    case 7:
                        Console.WriteLine("Enter student id: ");
                        int s_id2 = int.Parse(Console.ReadLine());
                        GetPaymentByStudentId(s_id2);
                        break;

                    case 8:
                        Console.WriteLine("Redirecting...");
                        break;

                    default:
                        Console.WriteLine("Try again!!!");
                        break;
                       
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey(true);
                Console.Clear();
            } while (choice != 8);
        }
    }
}
