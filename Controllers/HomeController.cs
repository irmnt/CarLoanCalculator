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
            // TEST
            // result: didn't display
            var model = new LoanViewModel
            {
                InterestRatePlanA = 5.0,
                VehiclePricePlanA = 20000,
                DownPaymentPlanA = 2000,
                InsuranceTypePlanA = "insuranceA_1yr",
                OtherFeesPlanA = 500,
                TaxRatePlanA = 15,
                LoanTermPlanA = "36 months",
                LoanStartDatePlanA = "01/2023",
                TotalInterestPaidPlanA = 1500,
                TotalLoanAmountPlanA = 18000,
                MonthlyPaymentPlanA = 500
            };
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Confirm(LoanViewModel model)
        {
            if (ModelState.IsValid) {
                // Get selected plan
                char selectedPlan = model.SelectedPlan;

                // To do - Utilize the selected plan to calculate the monthly payment

                // Perform calculations using the service
                return RedirectToAction("Confirmation", model);
            }
            return View("Index", model);
        }
        
        public IActionResult Confirmation(LoanViewModel model)
        {
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
