namespace CarLoanCalculator.Models
{
    public class LoanViewModel
    {
        public decimal AnnualInterestRate { get; set; }
        public decimal MonthlyPayment { get; set; }
        public char SelectedPlan { get; set; }
    }
}