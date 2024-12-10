namespace PayApplication
{
    /// <summary>
    /// Class capturing details accociated with an employee's pay slip record (gross pay, hours worked, hourly rate, tax amount, net pay, superannuation amount).
    /// </summary>
    public class PaySlip
    {
       public PaySlip(Employee employee, string hoursWorked)
        {
            Employee = employee;
            HoursWorked = int.Parse(hoursWorked);
            PayGrossCalculated = PayCalculator.CalculateGrossPay(HoursWorked, employee.HourlyRate);
            TaxCalculated = employee.TaxThreshold
                ? PayCalculatorWithThreshold.CalculateTaxAmount(PayGrossCalculated)
                : PayCalculatorNoThreshold.CalculateTaxAmount(PayGrossCalculated);
            SuperCalculated = PayCalculator.CalculateSuperAmount(PayGrossCalculated);
            PayNetCalculated = PayCalculator.CalculateNetPay(PayGrossCalculated, TaxCalculated);
        }

        public Employee Employee { get; }
        public int HoursWorked { get; }
        public double TaxCalculated { get; }

        public double PayGrossCalculated { get; }
        public double SuperCalculated { get; }
        public double PayNetCalculated { get; }

        public override string ToString()
        {
            var taxThreshold = Employee.TaxThreshold ? "claimed" : "not claimed";

            return $@"
Employee details: {Employee}
Hours worked: {HoursWorked}
Hourly rate: {Employee.HourlyRate}
Tax Threshold: {taxThreshold}
Gross Pay: {PayGrossCalculated.ToString("C")}
Tax amount: {TaxCalculated.ToString("C")}
Net Pay: {PayNetCalculated.ToString("C")}
Superannuation: {SuperCalculated.ToString("C")}
";
        }
    }
}
