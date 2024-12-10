using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PayApplication
{
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();
            //PopulateTaxRates();
            // Add code below to complete the implementation to populate the listBox
            // by reading the employee.csv file into a List of PaySlip objects, then binding this to the ListBox.
            // CSV file format: <employee ID>, <first name>, <last name>, <hourly rate>, <taxthreshold>

            fileHelper = new FileHelper();
            employeeDetailsListBox.DataSource = fileHelper.GetEmployeeData();
        }

        private FileHelper fileHelper;
        private PaySlip paySlip;

        private void calculateButton_Click(object sender, EventArgs e)
        {
            // Add code below to complete the implementation to populate the
            // payment summary (textBox2) using the PaySlip and PayCalculatorNoThreshold
            // and PayCalculatorWithThresholds classes object and methods.

            try
            {
                //validate input
                if (string.IsNullOrEmpty(hoursWorkedTextbox.Text) || !double.TryParse(hoursWorkedTextbox.Text, out double hoursWorked) || hoursWorked <= 0)
                {
                    //if invalid, show error message
                    MessageBox.Show("Please enter a valid number of hours worked, only positive.");
                    return;
                }

                //if valid, calculation
                var employee = employeeDetailsListBox.SelectedItem as Employee;
                paySlip = new PaySlip(employee, hoursWorkedTextbox.Text);
                paySlipTextBox.Text = paySlip.ToString();
            }
            catch (Exception ex)
            {
                //if error, exception message
                MessageBox.Show($"An error occured: {ex.Message}");
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Add code below to complete the implementation for saving the
            // calculated payment data into a csv file.
            // File naming convention: Pay_<full name>_<datetimenow>.csv
            // Data fields expected - EmployeeId, Full Name, Hours Worked, Hourly Rate, Tax Threshold, Gross Pay, Tax, Net Pay, Superannuation

            if (paySlip != null)
            {
                fileHelper.SaveEmployeePaySlip(paySlip);
                MessageBox.Show("Payslip saved in GeneratedPaySlips.");
            }
            else 
            {
                MessageBox.Show("Please select an employee and calculate a payslip.");
            }
        }

        private void CalculatorForm_Load(object sender, EventArgs e)
        {

        }

        private void hoursWorkedTextbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
