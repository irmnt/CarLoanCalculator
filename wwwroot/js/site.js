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

    let taxes = parseFloat(document.getElementById('taxesPlanA').value) || 0;

    let totalInterestPaid = parseFloat(document.getElementById('totalInterestPaidPlanA').value) || 0;

    // Total Payment Amount Calculation
    let totalPaymentAmount = subtotal + taxes + totalInterestPaid;

    // Set Total Payment Amount Calculation
    document.getElementById('totalPaymentAmountPlanA').textContent = `$${totalPaymentAmount.toFixed(2)}`;
}


// principal payment amount calculator
function subtotalPaymentCalculator_planA() {
    let vehiclePrice = parseFloat(document.getElementById('vehiclePricePlanA').value) || 0;
    let insuarancePrice = parseFloat(document.getElementById('insurancePricePlanA').value) || 0;
    let otherFees = parseFloat(document.getElementById('otherFeesPlanA').value) || 0;

    return vehiclePrice + insuarancePrice + otherFees;
}

function updateTaxes_planA() {
    let taxRate = parseInt(document.getElementById('taxRatePlanA')) || 0;

    let subtotal = subtotalPaymentCalculator_planA();

    let taxes = subtotal * taxRate / 100;

    document.getElementById('taxesPlanA').textContent = `$ ${taxes.toFixed(2)}`;
}