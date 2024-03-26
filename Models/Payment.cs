using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Information_System.Models
{
    public class Payment
    {
        int paymentID;
        int? studentID;
        decimal? amount;
        DateTime paymentDate;

        public int PaymentID
        {
            get { return paymentID; }
            set { paymentID = value; }
        }

        public int? StudentID
        {
            get { return studentID; }
            set { studentID = value; }
        }

        public decimal? Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public DateTime PaymentDate
        {
            get { return paymentDate; }
            set { paymentDate = value; }
        }
        public Payment()
        {

        }

        public Payment(int paymentID, int studentID, decimal amount, DateTime paymentDate)
        {
            PaymentID = paymentID;
            StudentID = studentID;
            Amount = amount;
            PaymentDate = paymentDate;
        }
        public override string ToString()
        {
            return $"{PaymentID} {StudentID} {Amount} {PaymentDate}";
        }


    }
   
}
