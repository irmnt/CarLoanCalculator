namespace CarLoanCalculator.Models
{
    public class LoanDetails
    {
        public int Id { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal InterestRate { get; set; }
        public int LoanTerm { get; set; }
    }
}