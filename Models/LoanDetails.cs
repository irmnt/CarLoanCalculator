using System.Numerics;

namespace CarLoanCalculator.Models
{
    public class LoanDetails
    {
        /** Calcurate Total Payment */
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

        /**  Get Insurance Price */
        public static string GetInsurancePrice(string insuranceType)
        {
            return insuranceType == "insuranceA_1yr" ? "1000"
                : insuranceType == "insuranceA_3yrs" ? "2000"
                : insuranceType == "insuranceA_5yrs" ? "2500"
                : insuranceType == "insuranceA_10yrs" ? "3000" 
                : "0";
        }

        /** Calcurat Taxes */
        public static decimal CalculateTaxes(decimal vehivlePrice, decimal insurancePrice, decimal otherFees, decimal taxRate)
        {
            var subTotal = vehivlePrice + insurancePrice + otherFees;
            return subTotal * (taxRate / 100);
        }

        /** Get Interest Rate */
        public static string GetInterestRate(string loanTerm)
        {
            return loanTerm == "loanTermA_12m" ? "1.5 %"
                : loanTerm == "loanTermA_36m" ? "2.5 %"
                : loanTerm == "loanTermA_60m" ? "3.5 %"
                : loanTerm == "loanTermA_120m" ? "5.0 %"
                : "0 %";
        }

        /** Calculate Total Loan Amount*/
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

        /** Calculate Monthly Payment Amount */
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

        /** Get Loan Term Number */
        public static int GetLoanTermToInt(string loanTermStr)
        {
            return loanTermStr == "loanTermA_12m" ? 12
                : loanTermStr == "loanTermA_36m" ? 36
                : loanTermStr == "loanTermA_60m" ? 60
                : loanTermStr == "loanTermA_120m" ? 120
                : 0;
        }

        /** Get Interest Paid Amount */
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