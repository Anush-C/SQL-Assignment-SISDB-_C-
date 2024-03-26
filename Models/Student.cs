using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Models
{
    
    public class Student
    {
        int studentID;
        String firstname;
        String lastname;
        DateTime dateofbirth;
        String email;
        int? phonenumber;



        
        public int StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }

        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }

        }
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public DateTime DateOfBirth
        {
            get { return dateofbirth; }
            set { dateofbirth = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public int? PhoneNumber
        {
            get { return phonenumber; }
            set { phonenumber = value; }
        }
        public Student() { }


        // creating a paramaterized constructor
        public Student(int studentID, String firstname, String lastname, DateTime dateofbirth, String email, int phonenumber)
        {
            StudentID = studentID;
            FirstName = firstname;
            LastName = lastname;
            DateOfBirth = dateofbirth;
            Email = email;
            PhoneNumber = phonenumber;
        }

        public override string ToString()
        {
            return $"{StudentID} {FirstName} {LastName} {DateOfBirth} {Email} {PhoneNumber}";
        }


    }



}

