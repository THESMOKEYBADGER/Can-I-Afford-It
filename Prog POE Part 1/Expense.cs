using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;


namespace Prog_POE_Part_1
{
    internal class Expense
    {
        // INSTANTIATING VARIABLES AND ARRAYS
        public double monthlyIncome;
        private string[] costsName = { "monthly tax", "groceries","water & lights", "travel ", "phone bills", "other expenses"};
        public double[] costs = new double[6];

        //Attributes
        string name;
        double cost;
        public Expense()
        {

        }
        public Expense(string newName, double newCost)
        {
            name = newName;
            cost = newCost;
        }


        // INTRO METHOD FOR ASKING IF USER WOULD LIKE TO USE THE APPLICAITON
        public void Hello()
        {
            Console.WriteLine("Hello! This is your own private expense calculator...\n");


            Console.WriteLine("Would you like to make a new calculation?\nEnter y/n\n");
            String userChoice = Console.ReadLine();
            
         // IF STATEMENT FOR YES OR NO TO USE APP
            if(userChoice == "y")
            {
                Console.WriteLine("\nHere we GO!");
            }
            else
            {
                Console.WriteLine("Goodbye then");
                System.Environment.Exit(0);
            }
        }

        private double GetDouble(string s)
        {
            double userOutput = 0;
            string userInput = "";
            do
            {
                Write(s);
                userInput = Console.ReadLine();
            } while (!double.TryParse(userInput, out userOutput));
            
            return userOutput;
        }

        // RETRIEVE DATA FOR MONTHLY COSTS
        public List<Expense> enterInfo()
        {
            for (int i = 0; i < costs.Length; i++)
            {
                costs[i] = GetDouble(string.Format("Enter cost for {0}: R", costsName[i]));
            }
            return getExpenseList();
        }

        public double getCost()
        {
            return this.cost;
        }

        public Dictionary<string, double> createMap()
        {
            var map = new Dictionary<string, double>();
            map.Add(costsName[0],costs[0]);
            map.Add(costsName[1], costs[1]);
            map.Add(costsName[2], costs[2]);
            map.Add(costsName[3], costs[3]);
            map.Add(costsName[4], costs[4]);
            map.Add(costsName[5], costs[5]);

            return map;
        }
        public List<Expense> getExpenseList()
        {
            List<Expense> expenseList = new List<Expense>();
            var map = createMap();
            foreach (KeyValuePair<string, double> entry in map)
            {
                expenseList.Add(new Expense(entry.Key, entry.Value));
            }
            return expenseList;
        }

        

        // RETRIEVE USER MONTHLY INCOME AND CONVERT TO DOUBLE + RETURN INCOME
        public double getMonthlyIncome()
        {
            Console.Write("Enter your gross monthly income: R");
            monthlyIncome = Convert.ToDouble(Console.ReadLine());
            return monthlyIncome;
        }

        public double MonthlyIncome { get => monthlyIncome; set => monthlyIncome = value; }

        // METHOD TO RETURB A THIRD OF USERS MONTHLY INCOME FOR CALCULATIONS
        public double thirdIncome()
        {
            double thirdIncome =  getMonthlyIncome()* 0.3333;
            return thirdIncome;
        }

        // CALCULATE REMAINING MONEY AFTER ALL DEDUCTIONS
        public static double totalOtherExpenses(double[] costs, double monthlyIncome)
        {
        // CALLING REPAYMENT
            Accomodation fetch = new Accomodation();
            double expensesSum = (costs[0] + costs[1] + costs[2] + costs[3] + costs[4] + costs[5] );
            return expensesSum;
        }

        public string toString()
        {
            return "Name: " + this.name + " Cost: R" + this.cost;
        }
    }
}
