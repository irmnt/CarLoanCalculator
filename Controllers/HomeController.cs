using CarLoanCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarLoanCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LoanDetails _loanDetails;

        public HomeController(ILogger<HomeController> logger, LoanDetails loanDetails)
        {
            _logger = logger;
            _loanDetails = loanDetails;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Confirm(LoanViewModel model)
        {
            // To do - Utilize the selected plan to calculate the monthly payment

            decimal vehivlePrice = decimal.Parse(model.VehiclePricePlanA);
            decimal downPayment = decimal.Parse(model.DownPaymentPlanA.ToString());
            decimal insurancePrice = decimal.Parse(LoanDetails.SetInsurancePrice(model.InsuranceTypePlanA.ToString()));
            decimal otherFees = decimal.Parse(model.OtherFeesPlanA.ToString());
            var taxRate = model.TaxRatePlanA.ToString();
            decimal interestRate = decimal.Parse(LoanDetails.ConvertInterestRate(model.LoanTermPlanA.ToString()).Replace("%", "").Trim());
            decimal taxes = LoanDetails.CalculateTaxes(vehivlePrice, insurancePrice, otherFees, decimal.Parse(taxRate));
            // To do - get the int value form loanTerm
            var loanTerm = LoanDetails.ConvertLoanTermToInt(model.LoanTermPlanA.ToString());
            decimal totalLoanAmount = LoanDetails.CalculateTotalLoanAmount(vehivlePrice, downPayment, insurancePrice, otherFees, taxes);
            decimal monthlyPayment = LoanDetails.CalcurateMonthlyPayment(vehivlePrice, downPayment, insurancePrice, otherFees, taxes, 12, loanTerm);
            decimal totalInterestPaid = LoanDetails.GetInterestPaid(monthlyPayment, totalLoanAmount, loanTerm);
            decimal totalPayment = LoanDetails.CalculateTotalPayment(vehivlePrice, insurancePrice, otherFees, taxes, totalInterestPaid);


            // memo: before storing it in TempData, converting to string
            TempData["VehiclePricePlanA"] = vehivlePrice.ToString("F2");
            TempData["DownPaymentPlanA"] = downPayment.ToString("F2");
            TempData["InsuranceTypePlanA"] = model.InsuranceTypePlanA.ToString();
            TempData["InsurancePricePlanA"] = insurancePrice.ToString();
            TempData["OtherFeesPlanA"] = otherFees.ToString("F2");
            TempData["TaxRatePlanA"] = model.TaxRatePlanA.ToString();
            TempData["InterestRatePlanA"] = interestRate.ToString();
            TempData["TaxesPlanA"] = taxes.ToString("F2");
            TempData["LoanTermPlanA"] = model.LoanTermPlanA.ToString();
            TempData["LoanStartDatePlanA"] = model.LoanStartDatePlanA.ToString();
            TempData["TotalLoanAmountPlanA"] = totalLoanAmount.ToString("F2");
            TempData["MonthlyPaymentPlanA"] = monthlyPayment.ToString("F2");
            TempData["TotalInterestPaidPlanA"] = totalInterestPaid.ToString("F2");
            TempData["TotalPaymentAmountPlanA"] = totalPayment.ToString("F2");

            // Perform calculations using the service
            return RedirectToAction("Confirmation");
        }
        public IActionResult Confirmation(LoanViewModel model)
        {
            // memo: convert the value in accordance with its data type
            model.TotalPaymentAmountPlanA = Convert.ToString(TempData["TotalPaymentAmountPlanA"]) ?? "0";
            model.VehiclePricePlanA = Convert.ToString(TempData["VehiclePricePlanA"]) ?? "0";
            model.DownPaymentPlanA = Convert.ToString(TempData["DownPaymentPlanA"]) ?? "0";
            model.InsuranceTypePlanA = Convert.ToString(TempData["InsuranceTypePlanA"]) ?? "No Insurance";
            model.InsurancePricePlanA = Convert.ToString(TempData["INsurancePricePlanA"]) ?? "0";
            model.OtherFeesPlanA = Convert.ToString(TempData["OtherFeesPlanA"]) ?? "0";
            model.TaxRatePlanA = Convert.ToString(TempData["TaxRatePlanA"]) ?? "0";
            model.TaxesPlanA = Convert.ToString(TempData["TaxesPlanA"]) ?? "0";
            model.LoanTermPlanA = Convert.ToString(TempData["LoanTermPlanA"]) ?? "No Loan";
            model.LoanStartDatePlanA = Convert.ToString(TempData["LoanStartDatePlanA"]) ?? "TBD";
            model.InterestRatePlanA = Convert.ToString(TempData["InterestRatePlanA"]) ?? "0";
            model.TotalInterestPaidPlanA = Convert.ToString(TempData["TotalInterestPaidPlanA"]) ?? "0";
            model.TotalLoanAmountPlanA = Convert.ToString(TempData["TotalLoanAmountPlanA"]) ?? "0";
            model.MonthlyPaymentPlanA = Convert.ToString(TempData["MonthlyPaymentPlanA"]) ?? "0";

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
