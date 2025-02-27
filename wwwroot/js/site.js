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
    setInsurancePrice();
    updateTaxes_planA();
    updateTotalLoanAmount_planA();
    updateTotalPaymentAmount_planA();
}

// updating total amount
function updateTotalPaymentAmount_planA() {

    // Calculate subtotal
    let subtotal = subtotalPaymentCalculator_planA();

    // Taxes
    let taxes = parseFloat(document.getElementById('taxesPlanA').textContent.replace(/[^0-9.-]+/g, "")) || 0;

    // Insurance Price
    let insurancePrice = parseFloat(document.getElementById('insurancePricePlanA').textContent.replace(/[^0-9.]+/g, "")) || 0;

    // Total Interest Paid
    let totalInterestPaid = parseFloat(document.getElementById('totalInterestPaidPlanA').value) || 0;

    // Total Payment Amount Calculation
    let totalPaymentAmount = subtotal + taxes + insurancePrice + totalInterestPaid;

    // Set Total Payment Amount Calculation
    document.getElementById('totalPaymentAmountPlanA').textContent = `$${totalPaymentAmount.toFixed(2)}`;
}


// calculating subtotal
function subtotalPaymentCalculator_planA() {

    // Get the Vehicle Price, Insurance Price and Other Fees
    let vehiclePrice = parseFloat(document.getElementById('vehiclePricePlanA').value) || 0;

    // task extract numbers
    // let insurancePrice = parseFloat(document.getElementById('insurancePricePlanA').value) || 0;
    let insurancePrice = 0;
    let otherFees = parseFloat(document.getElementById('otherFeesPlanA').value) || 0;

    return vehiclePrice + insurancePrice + otherFees;
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


// Setting Insurance Price
function setInsurancePrice() {
    let insuranceType = document.getElementById('insuranceTypePlanA').value;
    let insurancePrice = insuranceType == 'insuranceA_1yr' ? '$ 1,000'
        : insuranceType == 'insuranceA_3yrs' ? '$ 2,000'
            : insuranceType == 'insuranceA_5yrs' ? '$ 2,500'
                : insuranceType == 'insuranceA_10yrs' ? '$ 3,000' : '$ 0';

    document.getElementById('insurancePricePlanA').textContent = insurancePrice;
}