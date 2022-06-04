using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Prog_POE_Part_1
{
    class Program
    {

        static List<Expense> finalExpenses = new List<Expense>();
        static void Main(string[] args)
        {
            Expense retrieveA = new Expense();

            retrieveA.Hello();
            double grossMonthlyIncome = retrieveA.getMonthlyIncome();
            List<Expense> otherCosts = retrieveA.enterInfo();

            double leftOverss = Expense.totalOtherExpenses(retrieveA.costs, retrieveA.monthlyIncome);

            Accomodation retrieveB = new Accomodation();
            retrieveB.rentOrBuy();
            Expense houseRepayment = retrieveB.getRepayment();

            Vehicle retrieveC = new Vehicle();
            retrieveC.purchase();
            Expense tom = retrieveC.calculateTOM();

            double totalSpend = grossMonthlyIncome - leftOverss - houseRepayment.getCost() - tom.getCost();
            if (totalSpend > (0.75 * grossMonthlyIncome))
            {
                Console.WriteLine("\nWARNING: Your total monthly payments exeed 75% of your gross monthly income");
            }
            else
            {
                Console.WriteLine("\nYour total monthly repayments are less than 75% of your gross monthly income!");
            }
           
            Console.WriteLine("\nHere's a breakdown of your monthly expenses >> ");
            
            finalExpenses.Add(houseRepayment);
            finalExpenses.Add(tom);
            finalExpenses.AddRange(otherCosts);

            finalExpenses = finalExpenses.OrderByDescending(x => x.getCost()).ToList();

            printExpenseList(finalExpenses);

        }
        public static void printExpenseList(List<Expense> list)
        {          
            foreach (Expense e in list)
            {
                Console.WriteLine(e.toString());        
            }
        }
    }
}


