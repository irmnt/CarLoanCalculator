using System.Numerics;

namespace CarLoanCalculator.Models
{
    public class LoanDetails
    {
        /* Calcurate Total Payment */
        public static decimal CalculateTotalPayment(
            decimal vehivlePrice,
            decimal insurancePrice,
            decimal otherFees,
            decimal taxes,
            decimal totalInterestPaid
            )
        {
            var totalPayment = vehivlePrice + insurancePrice + otherFees + taxes + totalInterestPaid;
            return totalPayment;
        }

        /* Get Vehicle Price */
        public static string GetInsuranceType(string insuranceType, string plan)
        {
            return insuranceType == "insurance" + plan + "_1yr" ? "Insurance 1 Year"
                : insuranceType == "insurance" + plan + "_3yrs" ? "Insurance 3 Years"
                : insuranceType == "insurance" + plan + "_5yrs" ? "Insurance 5 Years"
                : insuranceType == "insurance" + plan + "_10yrs" ? "Insurance 10 Years"
                : "No Insurance";
        }

        /*  Get Insurance Price */
        public static string GetInsurancePrice(string insuranceType, string plan)
        {
            return insuranceType == "insurance" + plan + "_1yr" ? "1000"
                : insuranceType == "insurance" + plan + "_3yrs" ? "2000"
                : insuranceType == "insurance" + plan + "_5yrs" ? "2500"
                : insuranceType == "insurance" + plan + "_10yrs" ? "3000" 
                : "0";
        }

        /* Calcurat Taxes */
        public static decimal CalculateTaxes(decimal vehivlePrice, decimal insurancePrice, decimal otherFees, decimal taxRate)
        {
            var subTotal = vehivlePrice + insurancePrice + otherFees;
            return subTotal * (taxRate / 100);
        }

        /* Get Interest Rate */
        public static string GetInterestRate(string loanTerm, string plan)
        {
            return loanTerm == "loanTerm" + plan + "_12m" ? "1.5 %"
                : loanTerm == "loanTerm" + plan + "_36m" ? "2.5 %"
                : loanTerm == "loanTerm" + plan + "_60m" ? "3.5 %"
                : loanTerm == "loanTerm" + plan + "_120m" ? "5.0 %"
                : "0 %";
        }

        /* Get Loan End Date */
        public static string GetLoanEndDate(string loanStartDate, int loanTerm)
        {
            DateTime startDate = DateTime.Parse(loanStartDate);
            DateTime endDate = startDate.AddMonths(loanTerm);
            return endDate.ToString("MM/yyyy");
        }

        /* Calculate Total Loan Amount*/
        public static decimal CalculateTotalLoanAmount(
            decimal vehivlePrice,
            decimal downPayment,
            decimal insurancePrice,
            decimal otherFees,
            decimal taxes
            )
        {
            var totalLoanAmount = vehivlePrice + insurancePrice + otherFees + taxes - downPayment;
            return totalLoanAmount;
        }

        /* Calculate Monthly Payment Amount */
        public static decimal CalcurateMonthlyPayment(
            decimal vehivlePrice,
            decimal downPayment,
            decimal insurancePrice,
            decimal otherFees,
            decimal taxes,
            decimal interestRate,
            int loanTerm
            )
        {
            // To do - Fix the calculation logic
            decimal totalLoanAmount = vehivlePrice + insurancePrice + otherFees + taxes - downPayment;
            decimal monthlyInterestRate = interestRate / 100 / 12;
            double growthFactorDouble = Math.Pow((double)(1 + monthlyInterestRate), loanTerm);
            decimal growthFactor = Math.Round((decimal)growthFactorDouble, 10); // safe rounding
            var monthlyPayment = (totalLoanAmount * monthlyInterestRate * growthFactor) / (growthFactor - 1);

            return (decimal)monthlyPayment;
        }

        /* Get Loan Term Number */
        public static int GetLoanTermToInt(string loanTermStr, string plan)
        {
            return loanTermStr == "loanTerm" + plan + "_12m" ? 12
                : loanTermStr == "loanTerm" + plan + "_36m" ? 36
                : loanTermStr == "loanTerm" + plan + "_60m" ? 60
                : loanTermStr == "loanTerm" + plan + "_120m" ? 120
                : 0;
        }

        /* Get Interest Paid Amount */
        public static decimal GetInterestPaid(decimal monthlyPayment,
            decimal totalLoanAmount,
            int loanTerm
            )
        {
            var totalPayment = monthlyPayment * loanTerm;
            var interestPaid = totalPayment - totalLoanAmount;
            return interestPaid;
        }
    }
}