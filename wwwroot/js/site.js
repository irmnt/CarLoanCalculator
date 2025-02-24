document.getElementById('loanForm').addEventListener('submit', function (event) {
    event.preventDefault();

    let amount = parseFloat(document.getElementById('loanAmount').value);
    let rate = parseFloat(document.getElementById('rate').value) / 100 / 12;
    let term = parseFloat(document.getElementById('loanTerm').value) * 12;

    let monthlyPayment = (amount * rate) / (1 - Math.pow(1 + rate, -term));
    document.getElementById('result').innerText = `Monthly Payment: $${monthlyPayment.toFixed(2)}`;
});


// Trigger function
function updateAllItems() {
    updateTaxes_planA();
    updateTotalLoanAmount_planA();
    updateTotalPaymentAmount_planA();
}

// updating total amount
function updateTotalPaymentAmount_planA() {

    let subtotal = subtotalPaymentCalculator_planA();

    // task extract numbers
    let taxes = parseFloat(document.getElementById('taxesPlanA').value) || 0;
    
    // total interest paid
    let totalInterestPaid = parseFloat(document.getElementById('totalInterestPaidPlanA').value) || 0;

    // Total Payment Amount Calculation
    let totalPaymentAmount = subtotal + taxes + totalInterestPaid;

    // Set Total Payment Amount Calculation
    document.getElementById('totalPaymentAmountPlanA').textContent = `$${totalPaymentAmount.toFixed(2)}`;
}


// calculating subtotal
function subtotalPaymentCalculator_planA() {
    let vehiclePrice = parseFloat(document.getElementById('vehiclePricePlanA').value) || 0;
    let insuarancePrice = parseFloat(document.getElementById('insurancePricePlanA').value) || 0;
    let otherFees = parseFloat(document.getElementById('otherFeesPlanA').value) || 0;

    return vehiclePrice + insuarancePrice + otherFees;
}


// updating Taxes
function updateTaxes_planA() {
    let taxRate = parseInt(document.getElementById('taxRatePlanA').value) || 0;

    let subtotal = subtotalPaymentCalculator_planA();

    let taxes = subtotal * taxRate / 100;

    document.getElementById('taxesPlanA').textContent = `$ ${taxes.toFixed(2)}`;
}


// updating Total Loan Amount
function updateTotalLoanAmount_planA() {
    let subtotal = subtotalPaymentCalculator_planA();

    let downPayment = parseFloat(document.getElementById('downPaymentPlanA').value) || 0;

    let loanAmount = subtotal - downPayment;

    document.getElementById('totalLoanAmountPlanA').textContent = `$ ${loanAmount.toFixed(2)}`
}