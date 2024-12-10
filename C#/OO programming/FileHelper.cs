using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace PayApplication
{
    /// <summary>
    /// This class holds the methods dealing with file handling (using CsvHelper), to make the other classes more simple. 
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// This method goes through the two tax rates files to return a list of tax rates ordered but max weekly earnings. This will ease the process in PayCalculator.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>list of tax rates</returns>
        /// <exception cref="System.Exception"></exception>
        public List<TaxRate> GetPaySlipTaxRate(string fileName)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };

            var path = $@"DataFiles\taxrate-{fileName}.csv";
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, config))
            {
                return csv.GetRecords<TaxRate>().OrderBy(x => x.MaxWeeklyEarnings).ToList();
            }

            throw new System.Exception($"Could not process Tax Rates for {fileName}");
        }

        /// <summary>
        /// This method goes through the employee data file to return a list of the employee data. This will ease the process in PaySlip.
        /// </summary>
        /// <returns>list of employee data</returns>
        /// <exception cref="System.Exception"></exception>
        public List<Employee> GetEmployeeData()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };

            string fileName = @"DataFiles\employee.csv";
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, config))
            {
                var employees = csv.GetRecords<Employee>();
                return employees.ToList<Employee>();
            }

            throw new System.Exception($"Could not process Employee records");
        }

        /// <summary>
        /// This method allows to save the generated payslips and store them in a designated folder..
        /// </summary>
        /// <param name="paySlip"></param>
        public void SaveEmployeePaySlip(PaySlip paySlip)
        {
            var employee = paySlip.Employee;
            string fileName = $"Pay-{employee.EmployeeID}-{employee.Person.FirstName}-{employee.Person.LastName}-{DateTime.Now.Ticks}.csv";
            string filePath = Path.Combine("../../DataFiles/GeneratedPaySlips", fileName); 
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecord(paySlip);
                csv.NextRecord();
            }
        }
    }
}
