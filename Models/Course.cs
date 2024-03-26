using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Models
{
    public class Course
    {
        int courseID;
        String courseName;
        String courseCode;
        String instructorName;
        int? credits;
        int ? instructorID;



        public int CourseID
        {
            get { return courseID; }
            set { courseID = value; }
        }

        public string CourseName
        {
            get { return courseName; }
            set { courseName = value; }
        }

        public String CourseCode
        {
            get { return courseCode; }
            set { courseCode = value; }
        }

        public string InstructorName
        {
            get { return instructorName; }
            set { instructorName = value; }
        }

        public int? Credits
        {
            get { return credits;  }
            set { credits = value; }

        }

        public int? InstructorID
        {
            get { return instructorID; }
            set { instructorID = value; }
        }
        public Course() { }


        public Course(int courseID, string instructorName, int? credits, int? instructorID)
        {
            this.CourseID = courseID;
            this.CourseName = courseName;
            this.credits = credits;
            this.instructorID = instructorID;
            
        }
        public override string ToString()
        {
            return $"{CourseID} {CourseName} {Credits} {InstructorID}";
        }
    }
}

       
