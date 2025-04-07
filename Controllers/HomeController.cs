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

            // memo: before storing it in TempData, converting to string
            TempData["VehiclePricePlanA"] = model.VehiclePricePlanA.ToString();

            // Perform calculations using the service
            return RedirectToAction("Confirmation");
        }
        public IActionResult Confirmation()
        {
            var model = new LoanViewModel();

            if (TempData.ContainsKey("VehiclePricePlanA"))
            {
                // memo: convert the value in accordance with its data type
                model.VehiclePricePlanA = Convert.ToString(TempData["VehiclePricePlanA"]);
            }
            else
            {
                model.VehiclePricePlanA = "0";
            }

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
