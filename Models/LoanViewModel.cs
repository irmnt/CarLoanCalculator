namespace CarLoanCalculator.Models
{
    public class LoanViewModel
    {
        /* Finalized Information */
        public required string TotalPaymentAmount { get; set; }
        public required string VehiclePrice { get; set; }
        public required string DownPayment { get; set; }
        public required string InsuranceType { get; set; }
        public required string InsurancePrice { get; set; }
        public required string OtherFees { get; set; }
        public required string TaxRate { get; set; }
        public required string Taxes { get; set; }
        public required string LoanTerm { get; set; }
        public required string LoanStartDate { get; set; }
        public required string InterestRate { get; set; }
        public required string TotalInterestPaid { get; set; }
        public required string TotalLoanAmount { get; set; }
        public required string MonthlyPayment { get; set; }

        // Selected Plan
        public char SelectedPlan { get; set; }

        /* Values of Plan A */
        public required string TotalPaymentAmountPlanA { get; set; }
        public required string VehiclePricePlanA { get; set; }
        public required string DownPaymentPlanA { get; set; }
        public required string InsuranceTypePlanA { get; set; }
        public required string InsurancePricePlanA { get; set; }
        public required string OtherFeesPlanA { get; set; }
        public required string TaxRatePlanA { get; set; }
        public required string TaxesPlanA { get; set; }
        public required string LoanTermPlanA { get; set; }
        public required string LoanStartDatePlanA { get; set; }
        public required string InterestRatePlanA { get; set; }
        public required string TotalInterestPaidPlanA { get; set; }
        public required string TotalLoanAmountPlanA { get; set; }
        public required string MonthlyPaymentPlanA { get; set; }

        /* Values of Plan B */
        public required string TotalPaymentAmountPlanB { get; set; }
        public required string VehiclePricePlanB { get; set; }
        public required string DownPaymentPlanB { get; set; }
        public required string InsuranceTypePlanB { get; set; }
        public required string InsurancePricePlanB { get; set; }
        public required string OtherFeesPlanB { get; set; }
        public required string TaxRatePlanB { get; set; }
        public required string TaxesPlanB { get; set; }
        public required string LoanTermPlanB { get; set; }
        public required string LoanStartDatePlanB { get; set; }
        public required string InterestRatePlanB { get; set; }
        public required string TotalInterestPaidPlanB { get; set; }
        public required string TotalLoanAmountPlanB { get; set; }
        public required string MonthlyPaymentPlanB { get; set; }

        /* Values of Plan C */
        public required string TotalPaymentAmountPlanC { get; set; }
        public required string VehiclePricePlanC { get; set; }
        public required string DownPaymentPlanC { get; set; }
        public required string InsuranceTypePlanC { get; set; }
        public required string InsurancePricePlanC { get; set; }
        public required string OtherFeesPlanC { get; set; }
        public required string TaxRatePlanC { get; set; }
        public required string TaxesPlanC { get; set; }
        public required string LoanTermPlanC { get; set; }
        public required string LoanStartDatePlanC { get; set; }
        public required string InterestRatePlanC { get; set; }
        public required string TotalInterestPaidPlanC { get; set; }
        public required string TotalLoanAmountPlanC { get; set; }
        public required string MonthlyPaymentPlanC { get; set; }

    }
}