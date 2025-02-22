// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.getElementById('loanForm').addEventListener('submit', function (event) {
    event.preventDefault();

    let amount = parseFloat(document.getElementById('loanAmount').value);
    let rate = parseFloat(document.getElementById('rate').value) / 100 / 12;
    let term = parseFloat(document.getElementById('loanTerm').value) * 12;

    let monthlyPayment = (amount * rate) / (1 - Math.pow(1 + rate, -term));
    document.getElementById('result').innerText = `Monthly Payment: $${monthlyPayment.toFixed(2)}`;
});

// update total amount
function updateTotalPaymentAmount_PlanA() {

    // Price of Vehivle
    let priceOfVehicle = parseInt(document.getElementById('vehiclePricePlanA').value) || 0;

    // Down Payment
    let downPayment = parseInt(document.getElementById('downPaymentPlanA').value) || 0;

    // Insurance Type
    let insuranceType = document.getElementById('insuranceTypePlanA') || 0;

    // Other Fees
    let otherFees = parseInt(document.getElementById('otherFeesPlanA').value) || 0;

    // Loan Term
    let loanTerm = parseInt(document.getElementById('loanTermPlanA').value) || 0;


    // Taxes 10%
    let taxes = 0.10;

    // Total Payment Amount Calculation
    let totalPaymentAmount = (priceOfVehicle + otherFees) * (1 + taxes) - downPayment;

    // Set Total Payment Amount Calculation
    document.getElementById('totalLoanAmountPlanA').textContent = `$${totalPaymentAmount.toFixed(2)}`;
}