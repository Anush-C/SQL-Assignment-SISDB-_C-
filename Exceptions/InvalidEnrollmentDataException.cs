using Student_Information_System.Models;
using Student_Information_System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Exceptions
{
    internal class InvalidEnrollmentDataException : Exception
    {
        public InvalidEnrollmentDataException(string message): base(message ){ }


        public static void InvalidEnrollmentData(Enrollment enrollment)
        {
            if (enrollment.EnrollmentID == null )
            {
                throw new InvalidEnrollmentDataException("ID cannot be null. Please try again..");
            }
            else if (enrollment.StudentID == null)
            {
                throw new InvalidEnrollmentDataException("Student ID cannot be null. Please try again..");
            }
            else if(enrollment.EnrollmentDate >  DateTime.Now) 
            {
                throw new InvalidEnrollmentDataException("Enter a valid enrollment date.");
            }
        }
        
    }
}
