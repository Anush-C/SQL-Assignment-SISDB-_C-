using System;
using Student_Information_System.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Exceptions
{
    internal class InvalidStudentDataException : Exception
    {
        public InvalidStudentDataException(string message): base(message) { }

        public static void InvalidStudentData(Student student)
        {
            if(String.IsNullOrEmpty(student.FirstName) && String.IsNullOrEmpty(student.LastName))
            {
                throw new InvalidStudentDataException("First Name and Last Name cannot be empty. Please try again..");
            }
            else if(student.DateOfBirth > DateTime.Now)
            {
                throw new InvalidStudentDataException("Invalid Date of Birth. Please try  again..");
            }
            else if(!IsValidEmail(student.Email))
            {
                throw new InvalidStudentDataException("Invalid Email. Please try again..");
            }
        }
        private static bool IsValidEmail(string email)
        {
            string emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, emailPattern);  
        }
    }
}
