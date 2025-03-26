namespace CarLoanCalculator.Models
{
    public class LoanViewModel
    {
        public string Amount { get; set; }
        public string Term { get; set; }
        public string LoanType { get; set; }
        public decimal AnnualInterestRate { get; set; }
        public decimal MonthlyPayment { get; set; } // Add this property
    }
}