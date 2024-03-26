using System;
using Student_Information_System.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Exceptions
{
    internal class InvalidFundsException : Exception
    {
        public InvalidFundsException(string message): base(message) { }

        public void InvalidFund(decimal amount)
        {
            if(amount < 200)
            {
                throw new InvalidFundsException("Insufficient Fund to enroll in this course. Please provide a sufficient amount for this course.");
            }
        }
    }
}
