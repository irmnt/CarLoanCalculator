namespace CarLoanCalculator.Models
{
    public class LoanDetails
    {
        public static decimal CalculateMonthlyPayment(decimal principal, decimal annualInterestRate, int termInMonths)
        {
            // Implement your calculation logic here
            decimal monthlyInterestRate = annualInterestRate / 12 / 100;
            decimal denominator = (decimal)Math.Pow((double)(1 + monthlyInterestRate), termInMonths) - 1;
            return principal * monthlyInterestRate * (decimal)Math.Pow((double)(1 + monthlyInterestRate), termInMonths) / denominator;
        }
        public static decimal CalculateTotalPayment(decimal principal, decimal annualInterestRate, int termInMonths)
        {
            decimal monthlyPayment = CalculateMonthlyPayment(principal, annualInterestRate, termInMonths);
            return monthlyPayment * termInMonths;
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
    }
}