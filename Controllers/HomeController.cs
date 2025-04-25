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

            decimal vehivlePrice = decimal.Parse(model.VehiclePricePlanA);
            decimal downPayment = decimal.Parse(model.DownPaymentPlanA.ToString());
            decimal insurancePrice = decimal.Parse(LoanDetails.GetInsurancePrice(model.InsuranceTypePlanA.ToString()));
            decimal otherFees = decimal.Parse(model.OtherFeesPlanA.ToString());
            var taxRate = model.TaxRatePlanA.ToString();
            decimal interestRate = decimal.Parse(LoanDetails.GetInterestRate(model.LoanTermPlanA.ToString()).Replace("%", "").Trim());
            decimal taxes = LoanDetails.CalculateTaxes(vehivlePrice, insurancePrice, otherFees, decimal.Parse(taxRate));
            var loanTerm = LoanDetails.GetLoanTermToInt(model.LoanTermPlanA.ToString());
            decimal totalLoanAmount = LoanDetails.CalculateTotalLoanAmount(vehivlePrice, downPayment, insurancePrice, otherFees, taxes);
            decimal monthlyPayment = LoanDetails.CalcurateMonthlyPayment(vehivlePrice, downPayment, insurancePrice, otherFees, taxes, interestRate, loanTerm);
            decimal totalInterestPaid = LoanDetails.GetInterestPaid(monthlyPayment, totalLoanAmount, loanTerm);
            decimal totalPayment = LoanDetails.CalculateTotalPayment(vehivlePrice, insurancePrice, otherFees, taxes, totalInterestPaid);


            // memo: before storing it in TempData, converting to string
            TempData["VehiclePrice"] = vehivlePrice.ToString("F2");
            TempData["DownPayment"] = downPayment.ToString("F2");
            TempData["InsuranceType"] = model.InsuranceTypePlanA.ToString();
            TempData["InsurancePrice"] = insurancePrice.ToString();
            TempData["OtherFees"] = otherFees.ToString("F2");
            TempData["TaxRate"] = model.TaxRatePlanA.ToString();
            TempData["InterestRate"] = interestRate.ToString();
            TempData["Taxes"] = taxes.ToString("F2");
            TempData["LoanTerm"] = model.LoanTermPlanA.ToString();
            TempData["LoanStartDate"] = model.LoanStartDatePlanA.ToString();
            TempData["TotalLoanAmount"] = totalLoanAmount.ToString("F2");
            TempData["MonthlyPayment"] = monthlyPayment.ToString("F2");
            TempData["TotalInterestPaid"] = totalInterestPaid.ToString("F2");
            TempData["TotalPaymentAmount"] = totalPayment.ToString("F2");

            // Perform calculations using the service
            return RedirectToAction("Confirmation");
        }
        public IActionResult Confirmation(LoanViewModel model)
        {
            // memo: convert the value in accordance with its data type
            model.TotalPaymentAmount = Convert.ToString(TempData["TotalPaymentAmount"]) ?? "0";
            model.VehiclePrice = Convert.ToString(TempData["VehiclePrice"]) ?? "0";
            model.DownPayment = Convert.ToString(TempData["DownPayment"]) ?? "0";
            model.InsuranceType = Convert.ToString(TempData["InsuranceType"]) ?? "No Insurance";
            model.InsurancePrice = Convert.ToString(TempData["INsurancePrice"]) ?? "0";
            model.OtherFees = Convert.ToString(TempData["OtherFees"]) ?? "0";
            model.TaxRate = Convert.ToString(TempData["TaxRate"]) ?? "0";
            model.Taxes = Convert.ToString(TempData["Taxes"]) ?? "0";
            model.LoanTerm = Convert.ToString(TempData["LoanTerm"]) ?? "No Loan";
            model.LoanStartDate = Convert.ToString(TempData["LoanStartDate"]) ?? "TBD";
            model.InterestRate = Convert.ToString(TempData["InterestRate"]) ?? "0";
            model.TotalInterestPaid = Convert.ToString(TempData["TotalInterestPaid"]) ?? "0";
            model.TotalLoanAmount = Convert.ToString(TempData["TotalLoanAmount"]) ?? "0";
            model.MonthlyPayment = Convert.ToString(TempData["MonthlyPayment"]) ?? "0";

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
