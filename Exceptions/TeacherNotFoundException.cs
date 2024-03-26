using System;
using Student_Information_System.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Information_System.Repositories;

namespace Student_Information_System.Exceptions
{
    internal class TeacherNotFoundException : Exception
    {
        public TeacherNotFoundException(string message): base(message) { }

        public static void TeacherNotFound(Teacher teacher)
        {
            TeacherRepository teacherRepository = new TeacherRepository();
            if (!teacherRepository.TeacherExists(teacher))
            {
                throw new TeacherNotFoundException("Teacher does not exist. Please try again..");
            }
        }
    }
}
