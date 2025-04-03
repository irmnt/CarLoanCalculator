namespace CarLoanCalculator.Models
{
    public class LoanViewModel
    {
        // Values of Plan A
        public char SelectedPlan { get; set; }
        public double TotalPaymentAmountPlanA { get; set; }
        public double VehiclePricePlanA { get; set; }
        public double DownPaymentPlanA { get; set; }
        public string InsuranceTypePlanA { get; set; }
        public double OtherFeesPlanA { get; set; }
        public double TaxRatePlanA { get; set; }
        public string LoanTermPlanA { get; set; }
        public string LoanStartDatePlanA { get; set; }
        public double InterestRatePlanA { get; set; }
        public double TotalInterestPaidPlanA { get; set; }
        public double TotalLoanAmountPlanA { get; set; }
        public double MonthlyPaymentPlanA { get; set; }

    }
}