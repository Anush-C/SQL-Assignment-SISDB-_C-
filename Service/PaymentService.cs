using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Information_System.Repositories;
using Student_Information_System.Models;

namespace Student_Information_System.Service
{
    internal class PaymentService
    {
        private readonly PaymentRepository _paymentRepository;
        public PaymentService()
        {
            _paymentRepository = new PaymentRepository();
        }

        public void GetStudentByPayment(int paymentId)
        {
            _paymentRepository.GetStudent(paymentId);
        }

        public void GetAmountByPayment(int paymentId)
        {
            _paymentRepository.GetPaymentAmount(paymentId);
        }

        public void GetPaymentDateById(int paymentId)
        {
            _paymentRepository.GetPaymentdate(paymentId);
        }

        public void PaymentMenu()
        {
            Payment payment = new Payment();
            int choice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Payment Management");
                Console.WriteLine($"1: Get student  Payments\n2: Get payment amount\n3. Get payment date\n4: Back to Main menu..\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter payment id: ");
                        int payment_id = int.Parse(Console.ReadLine());
                        GetStudentByPayment(payment_id);
                        break;

                    case 2:
                        Console.WriteLine("Enter payment id: ");
                        int paymentid = int.Parse(Console.ReadLine());
                        GetAmountByPayment(paymentid);
                        break;

                    case 3:
                        Console.WriteLine("Enter payment id: ");
                        int paymentId = int.Parse(Console.ReadLine());
                        GetPaymentDateById(paymentId);
                        break;

                    case 4:
                        Console.WriteLine("Redirecting...");
                        break;

                    default:
                        Console.WriteLine("Try again!!!");
                        break;
                }
            } while (choice != 4);
        }
    }
}

