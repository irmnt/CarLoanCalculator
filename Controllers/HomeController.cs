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
            string plan = model.SelectedPlan.ToString();

            decimal vehivlePrice = plan == "A" ? decimal.Parse(model.VehiclePricePlanA)
                : plan == "B" ? decimal.Parse(model.VehiclePricePlanB)
                : plan == "C" ? decimal.Parse(model.VehiclePricePlanC)
                : 0;

            decimal downPayment = plan == "A" ? decimal.Parse(model.DownPaymentPlanA.ToString())
                : plan == "B" ? decimal.Parse(model.DownPaymentPlanB.ToString())
                : plan == "C" ? decimal.Parse(model.DownPaymentPlanC.ToString())
                : 0;

            string insuranceType = plan == "A" ? LoanDetails.GetInsuranceType(model.InsuranceTypePlanA.ToString(), plan)
                : plan == "B" ? LoanDetails.GetInsuranceType(model.InsuranceTypePlanB.ToString(), plan)
                : plan == "C" ? LoanDetails.GetInsuranceType(model.InsuranceTypePlanC.ToString(), plan)
                : "No Insurance";

            decimal insurancePrice = plan == "A" ? decimal.Parse(LoanDetails.GetInsurancePrice(model.InsuranceTypePlanA.ToString(), plan))
                : plan == "B" ? decimal.Parse(LoanDetails.GetInsurancePrice(model.InsuranceTypePlanB.ToString(), plan))
                : plan == "C" ? decimal.Parse(LoanDetails.GetInsurancePrice(model.InsuranceTypePlanC.ToString(), plan)) 
                : 0;

            decimal otherFees = plan == "A"
                ? decimal.Parse(model.OtherFeesPlanA.ToString())
                : plan == "B"
                ? decimal.Parse(model.OtherFeesPlanB.ToString())
                : plan == "C"
                ? decimal.Parse(model.OtherFeesPlanC.ToString())
                : 0;

            string taxRate = plan == "A" ? model.TaxRatePlanA.ToString()
                : plan == "B" ? model.TaxRatePlanB.ToString()
                : plan == "C" ? model.TaxRatePlanC.ToString()
                : "0";

            
            decimal interestRate = plan == "A" 
                ? decimal.Parse(LoanDetails.GetInterestRate(model.LoanTermPlanA.ToString(), plan).Replace("%", "").Trim())
                : plan == "B" 
                ? decimal.Parse(LoanDetails.GetInterestRate(model.LoanTermPlanB.ToString(), plan).Replace("%", "").Trim())
                : plan == "C" 
                ? decimal.Parse(LoanDetails.GetInterestRate(model.LoanTermPlanC.ToString(), plan).Replace("%", "").Trim())
                : 0;

            decimal taxes = LoanDetails.CalculateTaxes(vehivlePrice, insurancePrice, otherFees, decimal.Parse(taxRate));
            
            var loanTerm = plan == "A"
                ? LoanDetails.GetLoanTermToInt(model.LoanTermPlanA.ToString(), plan)
                : plan == "B"
                ? LoanDetails.GetLoanTermToInt(model.LoanTermPlanB.ToString(), plan)
                : plan == "C"
                ? LoanDetails.GetLoanTermToInt(model.LoanTermPlanC.ToString(), plan)
                : 0;

            string loanStartDate = plan == "A"
                ? model.LoanStartDatePlanA.ToString()
                : plan == "B"
                ? model.LoanStartDatePlanB.ToString()
                : plan == "C"
                ? model.LoanStartDatePlanC.ToString()
                : "04/2025";

            string loanEndDate = LoanDetails.GetLoanEndDate(loanStartDate, loanTerm);

            decimal totalLoanAmount = LoanDetails.CalculateTotalLoanAmount(vehivlePrice, downPayment, insurancePrice, otherFees, taxes);
            decimal monthlyPayment = LoanDetails.CalcurateMonthlyPayment(vehivlePrice, downPayment, insurancePrice, otherFees, taxes, interestRate, loanTerm);
            decimal totalInterestPaid = LoanDetails.GetInterestPaid(monthlyPayment, totalLoanAmount, loanTerm);
            decimal totalPayment = LoanDetails.CalculateTotalPayment(vehivlePrice, insurancePrice, otherFees, taxes, totalInterestPaid);


            // memo: before storing it in TempData, converting to string
            TempData["VehiclePrice"] = vehivlePrice.ToString("F2");
            TempData["DownPayment"] = downPayment.ToString("F2");
            TempData["InsuranceType"] = insuranceType;
            TempData["InsurancePrice"] = insurancePrice.ToString();
            TempData["OtherFees"] = otherFees.ToString("F2");
            TempData["TaxRate"] = taxRate;
            TempData["InterestRate"] = interestRate.ToString();
            TempData["Taxes"] = taxes.ToString("F2");
            TempData["LoanTerm"] =loanTerm;
            TempData["LoanStartDate"] = loanStartDate;
            TempData["LoanEndDate"] = loanEndDate;
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
            model.LoanEndDate = Convert.ToString(TempData["LoanEndDate"]) ?? "TBD";
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
