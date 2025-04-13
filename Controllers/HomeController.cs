using CarLoanCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

            var vehivlePrice = model.VehiclePricePlanA.ToString();
            var downPayment = model.DownPaymentPlanA.ToString();
            var insurancePrice = "0";
            var otherFees = model.OtherFeesPlanA.ToString();
            var taxRate = model.TaxRatePlanA.ToString();
            var taxes = "0";
            var totalInterestPaid = "0";
            var totalLoanAmount = "0";
            var monthlyPayment = "0";

            // memo: before storing it in TempData, converting to string
            TempData["VehiclePricePlanA"] = vehivlePrice;
            TempData["DownPaymentPlanA"] = downPayment;
            TempData["InsuranceTypePlanA"] = model.InsuranceTypePlanA.ToString();
            TempData["OtherFeesPlanA"] = otherFees;
            TempData["TaxRatePlanA"] = model.TaxRatePlanA.ToString();
            TempData["LoanTermPlanA"] = model.LoanTermPlanA.ToString();
            TempData["LoanStartDatePlanA"] = model.LoanStartDatePlanA.ToString();


            // Call the static method to calculate the total payment
            decimal totalPayment = LoanDetails.CalculateTotalPayment(10000, 8, 36);
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
            model.OtherFeesPlanA = Convert.ToString(TempData["OtherFeesPlanA"]) ?? "0";
            model.TaxRatePlanA = Convert.ToString(TempData["TaxRatePlanA"]) ?? "0";
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
