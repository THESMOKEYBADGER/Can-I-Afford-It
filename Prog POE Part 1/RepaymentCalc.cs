using System;
using System.Collections.Generic;
using System.Text;

namespace Prog_POE_Part_1
{
    class RepaymentCalc
    {
        public double Afford(double[] propertyCosts)
        {
         // INSTANTIATING VARIABLES 
            double homeLoanRepay;
            double timeToRepay;           

         // USING HOME LOAN FORMULA TO CALCULATE REPAYMENT A=P(1+in)
            homeLoanRepay = propertyCosts[0] - propertyCosts[1];
            timeToRepay = propertyCosts[3] / 12;
            double IN = (propertyCosts[2] / 100) * timeToRepay;

            double totalRepayment = homeLoanRepay*(1 + IN);
            return totalRepayment / propertyCosts[3];

        }

    }
}
