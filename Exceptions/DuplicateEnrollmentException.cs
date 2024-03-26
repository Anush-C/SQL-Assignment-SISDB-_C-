using System;
using Student_Information_System.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Information_System.Repositories;

namespace Student_Information_System.Exceptions
{
    internal class DuplicateEnrollmentException : Exception
    {
        public DuplicateEnrollmentException(String message): base(message) { }

        public static void DuplicateEnrollment(Enrollment enrollment)
        {
            EnrollmentRepository enrollmentRepository = new EnrollmentRepository();
            if (enrollmentRepository.DuplicateEnrollmentExists(enrollment))
            {
                    throw new DuplicateEnrollmentException("StudentID already exists. Please try again. ");
                
            }
        }
    }
}
