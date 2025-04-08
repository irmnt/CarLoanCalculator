namespace CarLoanCalculator.Models
{
    public class LoanViewModel
    {
        // Values of Plan A
        public char SelectedPlan { get; set; }
        public required string TotalPaymentAmountPlanA { get; set; }
        public required string VehiclePricePlanA { get; set; }
        public required string DownPaymentPlanA { get; set; }
        public required string InsuranceTypePlanA { get; set; }
        public required string OtherFeesPlanA { get; set; }
        public required string TaxRatePlanA { get; set; }
        public required string LoanTermPlanA { get; set; }
        public required string LoanStartDatePlanA { get; set; }
        public required string InterestRatePlanA { get; set; }
        public required string TotalInterestPaidPlanA { get; set; }
        public required string TotalLoanAmountPlanA { get; set; }
        public required string MonthlyPaymentPlanA { get; set; }

    }
}