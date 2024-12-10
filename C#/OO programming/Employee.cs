using CsvHelper.Configuration.Attributes;

namespace PayApplication
{
    /// <summary>
    /// This class sets the employee main information, to be use in the payslip.
    /// </summary>
    public class Employee
    {
        public int EmployeeID { get; set; }
        public Person Person { get; set; }
        public int HourlyRate { get; set; }

        [BooleanTrueValues("Y")]
        [BooleanFalseValues("N")]
        public bool TaxThreshold { get; set; }

        public override string ToString()
        {
            return $"{EmployeeID} {Person.FirstName} {Person.LastName}";
        }
    }
}
