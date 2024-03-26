using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Models
{
    public class Teacher
    {
        int teacherID;
        String firstName;
        String lastName;
        String email;
        
       

        public int TeacherID
        {
            get { return teacherID; }
            set { teacherID = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public Teacher() { }

        public Teacher(int teacherID, String firstName, String lastName, String email)
        {
            this.teacherID = teacherID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
        }
        public override string ToString()
        {
            return $"{TeacherID} {FirstName} {LastName} {Email}";
        }






    }
}
