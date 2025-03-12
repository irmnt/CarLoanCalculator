using System;

namespace CarLoanCalculator
{
    public class LoanDetails
    {
        public int Id { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal InterestRate { get; set; }
        public int LoanTerm { get; set; }
    }
    //public partial class YourPage : System.Web.UI.Page
    //{
    //    protected void btnConfirm_Click(object sender, EventArgs e)
    //    {
    //        // Get selected radio value
    //        string selectedPlan = HttpContext.Request.Form["loanPlan"]; 
    //        HttpContext.Current.Response.Write("Selected Plan: " + selectedPlan);

    //        //string name = txtName.Text; // Get value from TextBox

    //        //if (string.IsNullOrWhiteSpace(name))
    //        //{
    //        //    lblErrorMessage.Text = "Name is required!";
    //        //    lblErrorMessage.Visible = true; // Show error label
    //        //}
    //        //else
    //        //{
    //        //    lblErrorMessage.Visible = false; // Hide error label
    //        //    // Process input (e.g., save to database)
    //        //}
    //    }
    //}
}
