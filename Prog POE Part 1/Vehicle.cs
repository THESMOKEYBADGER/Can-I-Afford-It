using System;
using System.Collections.Generic;
using System.Text;

namespace Prog_POE_Part_1
{
    class Vehicle
    {

        private  List<string> vDetails = new List<string>();
        private  List<string> vDetailsTwo = new List<String>();
        public  void purchase()
        {
            Console.WriteLine("\nWould you like to purchase a vehicle?");
            Console.WriteLine("If yes then press 'y' or any other key for no...");

            string userInput = Console.ReadLine();
            if (userInput == "y"){

                Console.WriteLine("Please enter the car model >> ");
                vDetailsTwo.Add(Console.ReadLine());
                Console.WriteLine("Please enter the car make >> ");
                vDetailsTwo.Add(Console.ReadLine());
                Console.WriteLine("Please enter the purchase price of the vehicle >> R ");
                vDetails.Add(Console.ReadLine());
                Console.WriteLine("Please enter the total deposit for the vehicle >> R ");
                vDetails.Add(Console.ReadLine());
                Console.WriteLine("Please enter the interest rate in percentage >> ");
                vDetails.Add(Console.ReadLine());
                Console.WriteLine("Please enter the estimated insurance premium >> R");
                vDetails.Add(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Thank you for using this applicaiton!");
               
            }
        }
        

        public  Expense calculateTOM()
        {
            // converting string list to double list for calculations
            List<double> vDetailsNum = new List<double>();
            for (int i = 0; i < vDetails.Count; i++)
            {
                vDetailsNum.Add(double.Parse(vDetails[i]));
            }

            // assigning varible names to user inputs in list vDetailsNum
            double purchasePrice = vDetailsNum[0];
            double totalVdep = vDetailsNum[1];
            double interestRate = vDetailsNum[2] / 100;
            double insurancePrem = vDetailsNum[3];

            double vehicleRepay = purchasePrice - totalVdep;
            //using simple interest 
            double totalInterest = (purchasePrice * interestRate) * 5;
            double monthlyVrepayment = ((vehicleRepay + totalInterest ) / 60) + insurancePrem;

            Console.WriteLine("Monthly car repayment totals >> R " + monthlyVrepayment);
            return new Expense ("Monthly car repayment", monthlyVrepayment);
        }
    }
}
