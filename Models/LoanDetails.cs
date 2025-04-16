using System.Numerics;

namespace CarLoanCalculator.Models
{
    public class LoanDetails
    {
        public static decimal CalculateMonthlyPayment(decimal principal, decimal annualInterestRate, int termInMonths)
        {
            // Implement your calculation logic here
            return 1500;
        }
        public static decimal CalculateTotalPayment(decimal vehivlePrice, decimal insurancePrice, decimal otherFees, decimal taxes, decimal totalInterestPaid)
        {
            var totalPayment = vehivlePrice + insurancePrice + otherFees + taxes + totalInterestPaid;
            return totalPayment;
        }

        public static string SetInsurancePrice(string insuranceType)
        {
            if (insuranceType == "insuranceA_1yr")
            {
                return "1000";
            }
            else if (insuranceType == "insuranceA_3yr")
            {
                return "2000";
            }
            else if (insuranceType == "insuranceA_5yr")
            {
                return "2500";
            }
            else if (insuranceType == "insuranceA_10yr")
            {
                return "3000";
            }
            else
            {
                return "0";
            }
        }

        public static decimal CalculateTaxes(decimal vehivlePrice, decimal insurancePrice, decimal otherFees, decimal totalInterestPaid, decimal taxRate)
        {
            var subTotal = vehivlePrice + insurancePrice + otherFees + totalInterestPaid;
            return subTotal * (taxRate/100);
        }

        public static string SetInterestRate(string loanTerm)
        {
            var interestRate = loanTerm == "loanTermA_12m" ? "1.5 %"
        : loanTerm == "loanTermA_36m" ? "2.5 %"
            : loanTerm == "loanTermA_60m" ? "3.5 %"
                : loanTerm == "loanTermA_120m" ? "5.0 %" : "0 %";

            return interestRate;
        }
    }
}