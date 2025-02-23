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

    let subtotal = subtotalPaymentCalculator_planA();

    let taxes = parseDouble(document.getElementById('taxesPlanA').value) || 0;

    let totalInterestPaid = parseDouble(document.getElementById('totalInterestPaidPlanA').value) || 0;

    // Total Payment Amount Calculation
    let totalPaymentAmount = subtotal + taxes + totalInterestPaid;

    // Set Total Payment Amount Calculation
    document.getElementById('totalLoanAmountPlanA').textContent = `$${totalPaymentAmount.toFixed(2)}`;
}


// principal payment amount calculator
function subtotalPaymentCalculator_planA() {
    let vehiclePrice = parseDouble(document.getElementById('vehiclePricePlanA').value) || 0;
    let insuarancePrice = parseDouble(document.getElementById('insurancePricePlanA').value) || 0;
    let otherFees = parseDouble(document.getElementById('otherFeesPlanA').value) || 0;

    return vehiclePrice + insuarancePrice + otherFees;
}