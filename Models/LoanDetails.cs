namespace CarLoanCalculator.Models
{
    public class LoanDetails
    {
        public decimal CalculateMonthlyPayment(decimal principal, decimal annualInterestRate, int termInMonths)
        {
            // Implement your calculation logic here
            decimal monthlyInterestRate = annualInterestRate / 12 / 100;
            decimal denominator = (decimal)Math.Pow((double)(1 + monthlyInterestRate), termInMonths) - 1;
            return principal * monthlyInterestRate * (decimal)Math.Pow((double)(1 + monthlyInterestRate), termInMonths) / denominator;
        }
    }
}