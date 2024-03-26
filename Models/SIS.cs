//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Threading.Tasks;

//namespace Student_Information_System.Models
//{
//    internal class SIS
//    {
//        public Student Student { get; set; }
//        public Course Course { get; set; }
//        public Teacher Teacher { get; set; }

//        public List<Student> students = new List<Student>();
//        public List<Course> courses = new List<Course>();
//        public List<Teacher> teachers = new List<Teacher>();


//        public void EnrollStudentInCourse(Student student, Course course)
//        {
//            if (student == null)
//            {
//                throw new StudentNotFoundException("Student does not exist in the system.");
//            }
//            if (course.enrollments.Contains(student))
//            {
//                throw new DuplicateEnrollmentException("Student is already enrolled in the course");
//            }

//            course.enrollments.Add(student);
//            Console.WriteLine("Student Enrolled Successfully");
//        }

//        public void AssignTeacherToCourse(Teacher teacher, Course course)
//        {
//            if (teacher == null)
//            {
//                throw new TeacherNotFoundException("Teacher does not exist in the system.");
//            }
//            if (course == null)
//            {
//                throw new CourseNotFoundException("Course does not exist in the system.");
//            }
//            course.AssignedTeacher = teacher;
//            Console.WriteLine("Teacher was assigned to a course succesfully");
//        }
//        public void RecordPayment(Student student, decimal amount, DateTime paymentDate)
//        {
//            if (amount <= 0)
//            {
//                throw new PaymentValidationException("Invalid payment amount. Amount must be greater than zero.");
//            }

//            if (paymentDate > DateTime.Now)
//            {
//                throw new PaymentValidationException("Invalid payment date. Payment date cannot be in the future.");
//            }

//            student.RecordPayment(student, amount, paymentDate);
//            Console.WriteLine("Payment recorded for the student successfully");
//        }
//        public void GenerateEnrollmentReport(Course course)
//        {
//            foreach (Student student in course.enrollments)
//            {
//                Console.WriteLine($"Enrollment Report:: {student.FirstName}");
//            }
//        }

//        public void GeneratePaymentReport(Student student)
//        {
//            foreach (Payment payment in student.paymentRecords)
//            {
//                Console.WriteLine($"Payment Report:: {payment.Amount} in {payment.PaymentDate}");
//            }
//        }
//        public void CalculateCourseStatistics(Course course)
//        {
//            int enrolledCount = course.enrollments.Count;
//            decimal totalpayments = 0;

//            foreach (Student student in course.enrollments)
//            {
//                foreach (Payment payment in student.paymentRecords)
//                {
//                    totalpayments += payment.Amount;
//                }
//            }
//            Console.WriteLine($"Course Statistics for {course.CourseName}");
//            Console.WriteLine($"Enrollment Count:: {enrolledCount}");
//            Console.WriteLine($"Total Payments:: {totalpayments}");
//        }
//        public void CreateOrUpdate(Student student, Course course)
//        {
//            if (String.IsNullOrEmpty(student.FirstName) && String.IsNullOrEmpty(student.LastName))
//            {
//                throw new InvalidStudentDataException("Invalid Student Data. Both first name and last name are required");
//            }
//            if (student.DateOfBirth > DateTime.Now)
//            {
//                throw new InvalidStudentDataException("Invalid date of birth. Enter the correct date of birth");
//            }
//            if (!IsValidEmail(student.Email))
//            {
//                throw new InvalidStudentDataException("Invalid Email");
//            }
//            if (String.IsNullOrEmpty(course.CourseCode))
//            {
//                throw new InvalidCourseDataException("Invalid Course code. Valid course code is required");
//            }
//            if (String.IsNullOrEmpty(course.InstructorName))
//            {

//                throw new InvalidCourseDataException("Invalid Course Instructor Name. Valid course Instructor Name is required");

//            }
//            Course exists1 = courses.FirstOrDefault(c => c.CourseCode == course.CourseCode);
//            if (exists1 != null)
//            {
//                exists1.CourseCode = course.CourseCode;
//                exists1.CourseName = course.CourseName;
//                exists1.InstructorName = course.InstructorName;
//                exists1.AssignedTeacher = course.AssignedTeacher;
//                Console.WriteLine("Course updated Succesfully");

//            }
//            else
//            {

//                courses.Add(course);
//                Console.WriteLine("Course created succesfully");
//            }


//            Student exists = students.FirstOrDefault(st => st.StudentID == student.StudentID);
//            if (exists !=null)
//            {
//                exists.StudentID = student.StudentID;
//                exists.FirstName = student.FirstName;
//                exists.LastName = student.LastName;
//                exists.Email = student.Email;
//                exists.PhoneNumber = student.PhoneNumber;

//                Console.WriteLine("Student updated Succesfully");

//            }
//            else
//            {
//                students.Add(student);
//                Console.WriteLine("Student created successfully");
//                //throw new InvalidStudentDataException("Student with the same ID already exists in the system.");
//            }

//        }
//        private bool IsValidEmail(string email)
//        {
//            string emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
//            return System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern);
//        }

//    }
//}
