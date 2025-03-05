document.getElementById('submit').addEventListener('submit', function (event) {
    event.preventDefault();
    // validation checks
    let planSelected = document.querySelector('input[name="loanPlan"]:checked'); 

    // To do validation checks
    let plan = planSelected ? planSelected.value : '';
    document.$ = (id) => document.getElementById(id);
    let hoge = document.$('hoge');
    let hoge2 = document.$('hoge2');
    });


/**
 * Trigger Function
 * @param {any} plan : Plan A,B or C
 * 
 * Logic: Update all items when any of the input fields are changed
 */
function updateAllItems(plan) {
    setInterestRate(plan);
    setInsurancePrice(plan);
    taxesCalculator(plan);
    totalLoanAmountCalculator(plan);
    monthlyPaymentCalculator(plan);
    totalInterestPaidCalculator(plan);
    totalPaymentAmountCalculator(plan);
}
/**
 * Total Payment Amount Calculator
 * @param {any} plan : Plan A,B or C
 * 
 * Logic: Total Payment Amount = Subtotal + Taxes + Total Interest Paid
 */
function totalPaymentAmountCalculator(plan) {

    // Calculate subtotal
    let subtotal = subtotalPaymentCalculator(plan);

    // Taxes
    let taxes = parseFloat(document.getElementById('taxesPlan' + plan).textContent.replace(/[^0-9.-]+/g, "")) || 0;

    // Total Interest Paid
    let totalInterestPaid = parseFloat(document.getElementById('totalInterestPaidPlan' + plan).textContent.replace(/[^0-9.]+/g, "")) || 0;

    // Total Payment Amount Calculation and formatting to currency
    let totalPaymentAmount = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' }).format(subtotal + taxes + totalInterestPaid);

    // Set Total Payment Amount Calculation
    document.getElementById('totalPaymentAmountPlan' + plan).textContent = totalPaymentAmount;
}


/**
 * Subtotal Payment Calculator
 * @param {any} plan
 * @returns Subtotal Payment Amount
 * 
 * Logic: Subtotal Payment Amount = Vehicle Price + Insurance Price + Other Fees
 */
function subtotalPaymentCalculator(plan) {

    // Get the Vehicle Price, Insurance Price and Other Fees
    let vehiclePrice = parseFloat(document.getElementById('vehiclePricePlan' + plan).value.replace(/[^0-9.-]+/g, "")) || 0;

    // Insurance Price
    let insurancePrice = parseFloat(document.getElementById('insurancePricePlan' + plan).textContent.replace(/[^0-9.]+/g, "")) || 0;

    // Other fees
    let otherFees = parseFloat(document.getElementById('otherFeesPlan' + plan).value.replace(/[^0-9.]+/g, "")) || 0;

    return vehiclePrice + insurancePrice + otherFees;
}


/**
 * Taxes Calculator
 * @param {any} plan : Plan A,B or C
 * 
 * Logic: Taxes = Subtotal * Tax Rate
 */
function taxesCalculator(plan) {
    let taxRate = parseInt(document.getElementById('taxRatePlan' + plan).value.replace(/[^0-9.]+/g, "")) || 0;

    let subtotal = subtotalPaymentCalculator(plan);

    let taxes = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' }).format(subtotal * taxRate / 100);

    document.getElementById('taxesPlan' + plan).textContent = taxes;
}


/**
 * Total Loan Amount Calculator
 * @param {any} plan : Plan A,B or C
 * 
 * Logic: Total Loan Amount = Subtotal - Down Payment
 */
function totalLoanAmountCalculator(plan) {
    // Get the Loan Term
    let loanTerm = document.getElementById('loanTermPlan' + plan).value;

    if (loanTerm == 'select option') {
        document.getElementById('totalLoanAmountPlan' + plan).textContent = `$ 0`

    } else {
        let subtotal = subtotalPaymentCalculator(plan);

        let downPayment = parseFloat(document.getElementById('downPaymentPlan' + plan).value.replace(/[^0-9.]+/g, "")) || 0;

        // Calculate Total Loan Amount and format to currency
        let loanAmount = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' }).format(subtotal - downPayment);

        document.getElementById('totalLoanAmountPlan' + plan).textContent = loanAmount;
    }
}

/**
 * Insurance Price Setter
 * @param {any} plan : Plan A,B or C
 * 
 * Logic:
 * 1 year = $ 1,000
 * 3 years = $ 2,000
 * 5 years = $ 2,500
 * 10 years = $ 3,000
 */
function setInsurancePrice(plan) {
    let insuranceType = document.getElementById('insuranceTypePlan' + plan).value;
    let insurancePrice = insuranceType == 'insurance' + plan + '_1yr' ? '$ 1,000'
        : insuranceType == 'insurance' + plan + '_3yrs' ? '$ 2,000'
            : insuranceType == 'insurance' + plan + '_5yrs' ? '$ 2,500'
                : insuranceType == 'insurance' + plan + '_10yrs' ? '$ 3,000' : '$ 0';

    document.getElementById('insurancePricePlan' + plan).textContent = insurancePrice;
}


/**
 * Interest Rate Setter
 * @param {any} plan : Plan A,B or C
 * 
 * Logic:
 * 12 months = 1.5%
 * 36 months = 2.5%
 * 60 months = 3.5%
 * 120 months = 5.0%
 */
function setInterestRate(plan) {
    let loanTerm = document.getElementById('loanTermPlan' + plan).value || '';
    let interestRate = loanTerm == 'loanTerm' + plan + '_12m' ? '1.5 %'
        : loanTerm == 'loanTerm' + plan + '_36m' ? '2.5 %'
            : loanTerm == 'loanTerm' + plan + '_60m' ? '3.5 %'
                : loanTerm == 'loanTerm' + plan + '_120m' ? '5.0 %' : '0 %';

    document.getElementById('interestRatePlan' + plan).textContent = interestRate;
}


/**
 * Monthly Payment Calculator
 * @param {any} plan : Plan A,B or C
 * 
 * Logic: Monthly Payment = (Total Loan Amount * Monthly Interest Rate * Growth Factor) / (Growth Factor - 1)
 */
function monthlyPaymentCalculator(plan) {
    let totalLoanAmount = parseFloat(document.getElementById('totalLoanAmountPlan' + plan).textContent.replace(/[^0-9.-]+/g, "")) || 0;
    let annualInterestRate = parseFloat(document.getElementById('interestRatePlan' + plan).textContent.replace(/[^0-9.]+/g, "")) || 0;
    let loanTerm = parseInt(document.getElementById('loanTermPlan' + plan).value.replace(/[^0-9.]+/g, "")) || 0;

    // Validate all values are set
    if (totalLoanAmount > 0 && annualInterestRate > 0 && loanTerm > 0) {
        let monthlyInterestRate = annualInterestRate / 100 / 12;
        let growthFactor = (1 + monthlyInterestRate) ** loanTerm;
        let monthlyPayment = (totalLoanAmount * monthlyInterestRate * growthFactor) / (growthFactor - 1);

        // Format monthly payment to currency
        let formatted = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' }).format(monthlyPayment);
        document.getElementById('monthlyPaymentPlan' + plan).textContent = formatted;
    }
    else {
        document.getElementById('monthlyPaymentPlan' + plan).textContent = `$ 0`;
    }
}


/**
 * Total Interest Paid Calculator
 * @param {any} plan : Plan A,B or C
 * 
 * Logic: Total Interest Paid = (Monthly Payment * Loan Term) - Total Loan Amount
 */
function totalInterestPaidCalculator(plan) {
    let totalLoanAmount = parseFloat(document.getElementById('totalLoanAmountPlan' + plan).textContent.replace(/[^0-9.-]+/g, "")) || 0;
    let monthlyPayment = parseFloat(document.getElementById('monthlyPaymentPlan' + plan).textContent.replace(/[^0-9.-]+/g, "")) || 0;
    let loanTerm = parseInt(document.getElementById('loanTermPlan' + plan).value.replace(/[^0-9.]+/g, "")) || 0;

    // Validate all values are set and calculate total interest paid
    let totalInterestPaid = monthlyPayment > 0 && loanTerm > 0 && totalLoanAmount > 0
        ? (monthlyPayment * loanTerm) - totalLoanAmount
        : 0;

    // Format monthly payment to currency
    let formatted = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'USD' }).format(totalInterestPaid);

    document.getElementById('totalInterestPaidPlan' + plan).textContent = formatted;
}