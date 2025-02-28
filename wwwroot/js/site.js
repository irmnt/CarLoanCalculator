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
    setInterestRate();
    setInsurancePrice();
    updateTaxes_planA();
    updateTotalLoanAmount_planA();
    updateTotalPaymentAmount_planA();
    monthlyPaymentCalculator();
    totalInterestPaidCalculator();
}

// updating total amount
function updateTotalPaymentAmount_planA() {

    // Calculate subtotal
    let subtotal = subtotalPaymentCalculator_planA();

    // Taxes
    let taxes = parseFloat(document.getElementById('taxesPlanA').textContent.replace(/[^0-9.-]+/g, "")) || 0;

    // Total Interest Paid
    let totalInterestPaid = parseFloat(document.getElementById('totalInterestPaidPlanA').textContent.replace(/[^0-9.]+/g, "")) || 0;

    // Total Payment Amount Calculation and formatting to currency
    let totalPaymentAmount = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' }).format(subtotal + taxes + totalInterestPaid);

    // Set Total Payment Amount Calculation
    document.getElementById('totalPaymentAmountPlanA').textContent = totalPaymentAmount;
}


// calculating subtotal
function subtotalPaymentCalculator_planA() {

    // Get the Vehicle Price, Insurance Price and Other Fees
    let vehiclePrice = parseFloat(document.getElementById('vehiclePricePlanA').value.replace(/[^0-9.-]+/g, "")) || 0;

    // Insurance Price
    let insurancePrice = parseFloat(document.getElementById('insurancePricePlanA').textContent.replace(/[^0-9.]+/g, "")) || 0;

    // Other fees
    let otherFees = parseFloat(document.getElementById('otherFeesPlanA').value.replace(/[^0-9.]+/g, "")) || 0;

    return vehiclePrice + insurancePrice + otherFees;
}


// updating Taxes
function updateTaxes_planA() {
    let taxRate = parseInt(document.getElementById('taxRatePlanA').value.replace(/[^0-9.]+/g, "")) || 0;

    let subtotal = subtotalPaymentCalculator_planA();

    let taxes = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' }).format(subtotal * taxRate / 100);

    document.getElementById('taxesPlanA').textContent = taxes;
}


// updating Total Loan Amount
function updateTotalLoanAmount_planA() {
    let loanTerm = document.getElementById('loanTermPlanA').value;

    if (loanTerm == 'select option') {
        document.getElementById('totalLoanAmountPlanA').textContent = `$ 0`

    } else {
        let subtotal = subtotalPaymentCalculator_planA();

        let downPayment = parseFloat(document.getElementById('downPaymentPlanA').value.replace(/[^0-9.]+/g, "")) || 0;

        // Calculate Total Loan Amount and format to currency
        let loanAmount = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' }).format(subtotal - downPayment);

        document.getElementById('totalLoanAmountPlanA').textContent = loanAmount;
    }
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


// Setting Interest Rate
function setInterestRate() {
    let loanTerm = document.getElementById('loanTermPlanA').value || '';
    let interestRate = loanTerm == 'loanTermA_12m' ? '1.5 %'
        : loanTerm == 'loanTermA_36m' ? '2.5 %'
        : loanTerm == 'loanTermA_60m' ? '3.5 %'
                : loanTerm == 'loanTermA_120m' ? '5.0 %' : '0 %';

    document.getElementById('interestRatePlanA').textContent = interestRate;
}


// Calculating Monthly Payment
function monthlyPaymentCalculator() {
    let totalLoanAmount = parseFloat(document.getElementById('totalLoanAmountPlanA').textContent.replace(/[^0-9.-]+/g, "")) || 0;
    let annualInterestRate = parseFloat(document.getElementById('interestRatePlanA').textContent.replace(/[^0-9.]+/g, "")) || 0;
    let loanTerm = parseInt(document.getElementById('loanTermPlanA').value.replace(/[^0-9.]+/g, "")) || 0;

    // Validate all values are set
    if (totalLoanAmount > 0 && annualInterestRate > 0 && loanTerm > 0) {
        let monthlyInterestRate = annualInterestRate / 100 / 12;
        let growthFactor = (1 + monthlyInterestRate) ** loanTerm;
        let monthlyPayment = (totalLoanAmount * monthlyInterestRate * growthFactor) / (growthFactor - 1);

        // Format monthly payment to currency
        let formatted = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' }).format(monthlyPayment);
        document.getElementById('monthlyPaymentPlanA').textContent = formatted;
    }
    else {
        document.getElementById('monthlyPaymentPlanA').textContent = `$ 0`;
    }
}

// Calculating Total Interest Paid
function totalInterestPaidCalculator() {
    let totalLoanAmount = parseFloat(document.getElementById('totalLoanAmountPlanA').textContent.replace(/[^0-9.-]+/g, "")) || 0;
    let monthlyPayment = parseFloat(document.getElementById('monthlyPaymentPlanA').textContent.replace(/[^0-9.-]+/g, "")) || 0;
    let loanTerm = parseInt(document.getElementById('loanTermPlanA').value.replace(/[^0-9.]+/g, "")) || 0;

    // Validate all values are set and calculate total interest paid
    let totalInterestPaid = monthlyPayment > 0 && loanTerm > 0 && totalLoanAmount > 0
        ? (monthlyPayment * loanTerm) - totalLoanAmount
        : 0;

    // Format monthly payment to currency
    let formatted = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' }).format(totalInterestPaid);

    document.getElementById('totalInterestPaidPlanA').textContent = formatted;
}