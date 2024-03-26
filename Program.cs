using Student_Information_System.Repositories;
using Student_Information_System.Models;
using System.Xml.Serialization;
using System.Transactions;
using Student_Information_System.Exceptions;
using Student_Information_System.MainMenu;

namespace Student_Info_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentInfo sis = new StudentInfo();
            sis.MainMenu();
        }
    }
}
