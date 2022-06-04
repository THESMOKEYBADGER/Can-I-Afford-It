using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Prog_POE_Part_1
{
    class Accomodation
    {
        // parallel arrays for the costs and cost anmes of buying a property
        private string[] propertyCostNames = { "Property Price ", "Total Deposit", "Interest Rate in %", "Months to repay" };
        private static double[] propertyCosts = new double[4];
        private string userChoice;
        private double rentalCost;

        
        // METHOD FOR RETRIEVING USER CHOICE OF RENTING OR BUYING 
        public void rentOrBuy()
        {
            Console.WriteLine("\nDo you wish to rent accomadation (1) or buy a property (2)");
            userChoice = Console.ReadLine();

            if (userChoice == "1")

            {              
                string userInput = "";
                do
                {
                    Console.WriteLine("Please enter you monthly rental: R");                
                    userInput = Console.ReadLine();
                } while (!double.TryParse(userInput, out rentalCost));
                Console.WriteLine("Monthly rental is: " + rentalCost);
                
            }

         // IF USER CHOOSES TO BUY, METHOD FOR CAPTURING DATA FOR PURCHASE AND TO CALCULATE REPAYMENT PER MONTH
            else
            {
                if (userChoice == "2")
                {
                    for (int i = 0; i < propertyCosts.Length; i++)
                    {
                        propertyCosts[i] = GetDouble(string.Format("Enter the {0}:", propertyCostNames[i], ""));

                    }
                    for (int i = 0; i < propertyCostNames.Length; i++)
                    {
                        if (propertyCosts[3] > 360 || propertyCosts[3] < 240)
                        {
         // PARAMETERS TO RETRAIN USER FROM ENTERING VALUES OUTSIDE OF THE RANGE
                            propertyCosts[3] = GetDouble(string.Format("Enter a value between 240 and 360 for {0} : ", propertyCostNames[3]));
                        }
                    }
                }
            }

        // CONVERTING USER INPUT FROM STRING TO DOUBLE FOR CALCULATIONS 
            double GetDouble(string s)
            {
                double rental = 0;
                string userInput = "";
                do
                {
                    Write(s);
                    userInput = Console.ReadLine();
                } while (!double.TryParse(userInput, out rental));
                return rental;
            }

        } 

        // FETCHING CALCULATED REPAYMENT 
        public Expense getRepayment()
        {
            if(userChoice == "1")
            {
                return new Expense("Rental Cost", rentalCost);
               
            }

            RepaymentCalc random = new RepaymentCalc();
            double repayment = random.Afford(propertyCosts);

            Expense getThird = new Expense();
            double third = getThird.thirdIncome();

         // DETERMINING WETHER USER CAN AFFORD THE HOME LOAN AND STATING SO 
            if (repayment < third)
            {
                Console.WriteLine("\nYour home loan is very likely to get approved as it is less than one third of your monthly income...");
            }
            else
            {
                Console.WriteLine("\nIt is unlikely that you will be granted a home loan...");
            }
            
            Console.WriteLine("\nThe monthly payment for this home would be R " + repayment);
            
            return new Expense("Repayment", repayment);

           
        }
        // METHOD TO RETUN ONLY THE REPAYMENT FOR CALLING IN EXPENSE CLASS 
        public  double fetchValue()
        {
            RepaymentCalc random = new RepaymentCalc();
            double repayment = random.Afford(propertyCosts);
            return repayment;
        }
    }
}

