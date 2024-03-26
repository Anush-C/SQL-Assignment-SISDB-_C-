using System;
using Student_Information_System.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Exceptions
{
    internal class InvalidTeacherDataException : Exception
    {
        public InvalidTeacherDataException(string message) : base(message) { }

        public static void InvalidTeacherData(Teacher teacher)
        {
            if (String.IsNullOrEmpty(teacher.FirstName) && String.IsNullOrEmpty(teacher.LastName))
            {
                throw new InvalidStudentDataException("First Name and Last Name cannot be empty. Please try again..");
            }
            else if (!IsValidEmail(teacher.Email))
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

