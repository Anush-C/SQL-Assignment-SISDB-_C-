using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Models
{
    public class Enrollment
    {
        int enrollmentID;
        int? studentID;
        int?  courseID;
        DateTime enrollmentDate;

        
        public int EnrollmentID
        {
            get { return enrollmentID; }
            set { enrollmentID = value; }
        }

        public int? StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }

        public int? CourseID
        {
            get { return courseID; }
            set { courseID = value; }
        }

        public DateTime EnrollmentDate
        {
            get { return enrollmentDate; }
            set { enrollmentDate = value; }
        }
        public Enrollment() { }
        public Enrollment(int enrollmentID, int studentID, int courseID, DateTime enrollmentDate)
        {
            this.EnrollmentID = enrollmentID;
            this.StudentID = studentID;
            this.CourseID = courseID;
            this.EnrollmentDate = enrollmentDate;

        }
        public override string ToString()
        {
            return $"{EnrollmentID} {StudentID} {CourseID} {EnrollmentDate}";
        }


    }
}
