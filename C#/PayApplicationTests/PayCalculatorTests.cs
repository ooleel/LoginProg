using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayApplication.Tests
{
    [TestClass()]
    public class PayCalculatorTests
    {
        [TestMethod()]
        public void CalculateGrossPayTest_ValidInputs_ReturnExp()
        {
            //Arrange
            int workedHours = 40;
            int hourlyRate = 25;
            double expectedGrossPay = 1000; //40*25

            //Act
            double grossPay = PayCalculator.CalculateGrossPay(workedHours, hourlyRate);

            //Assert
            Assert.AreEqual(expectedGrossPay, grossPay, "Gross pay calculation is incorrect.");
        }

        //edge cases
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateGrossPayTest_InvalidInput_ArgException()
        {
            //Arrange
            int workedHours = -10; //invalid hours
            int hourlyRate = 30;

            //Act
            PayCalculator.CalculateGrossPay(workedHours, hourlyRate);

            //Assert: handled by ExpectedException
        }

        [TestMethod()]
        public void CalculateSuperAmountTest_ValidGrossPay_ReturnExp()
        {
            //Arrange 
            double grossPay = 1000;
            double expectedSuperAmount = 115; //1000 * 0.115

            //Act
            double superAmount = PayCalculator.CalculateSuperAmount(grossPay);

            //Assert
            Assert.AreEqual(expectedSuperAmount, superAmount, "Superannuation amount calculation is incorrect.");
        }

        private List<TaxRate> taxRates;

        [TestInitialize]
        public void SetUp()
        {
            //read data from csv
            var fileHelper = new FileHelper();
            taxRates = fileHelper.GetPaySlipTaxRate("withthreshold");
        }

        [TestMethod()]
        public void CalculateTaxAmountTest_WithThreshold_ReturnExp()
        {
            //Arrange 
            double grossPay = 600;
            taxRates = new List<TaxRate>()
            {
                new TaxRate { MinWeeklyEarnings = 548, MaxWeeklyEarnings = 721, TaxRateA = 0.2100, TaxRateB = 68.3465 }
            };
            double expectedTaxAmount = (0.2100 * (600 + 0.99)) - 68.3465;

            //Act
            double actualTaxAmount = PayCalculatorWithThreshold.CalculateTaxAmount(grossPay);

            //Assert
            Assert.AreEqual(expectedTaxAmount, actualTaxAmount, "Tax calculation with threshold failed.");
        }

        [TestMethod()]
        public void CalculateTaxAmountTest_NoThreshold_ReturnExp()
        {
            //Arrange 
            double grossPay = 500;
            taxRates = new List<TaxRate>()
            {
                new TaxRate { MinWeeklyEarnings = 371, MaxWeeklyEarnings = 515, TaxRateA = 0.2190, TaxRateB = -1.9003 }
            };
            double expectedTaxAmount = (0.2190 * (500 + 0.99)) - (-1.9003);

            //Act
            double actualTaxAmount = PayCalculatorNoThreshold.CalculateTaxAmount(grossPay);

            //Assert
            Assert.AreEqual(expectedTaxAmount, actualTaxAmount, "Tax calculation without threshold failed.");
        }

        [TestMethod()]
        public void CalculateNetPayTest_ValidInputs_ReturnExp()
        {
            //Arrange 
            double grossPay = 1000;
            double taxAmount = 200; //based on previous tests
            double expectedNetPay = 800;

            //Act
            double actualNetPay = PayCalculator.CalculateNetPay(grossPay, taxAmount);

            //Assert
            Assert.AreEqual(expectedNetPay, actualNetPay, "Net pay amount calculation is incorrect.");
        }
    }
}