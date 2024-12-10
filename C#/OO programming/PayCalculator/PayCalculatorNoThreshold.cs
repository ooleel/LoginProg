using System;

namespace PayApplication
{

    /// <summary>
    /// Extends PayCalculator class handling No tax threshold
    /// </summary>
    public class PayCalculatorNoThreshold : PayCalculator
    {
        public static double CalculateTaxAmount(double payGrossCalculated)
        {
            var taxRates = new FileHelper().GetPaySlipTaxRate("nothreshold");
            return CalculateTaxAmount(payGrossCalculated, taxRates);
        }
    }
}
