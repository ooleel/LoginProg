using System;
using System.Collections.Generic;

namespace PayApplication
{
    /// <summary>
    /// Extends PayCalculator class handling With tax threshold
    /// </summary>
    public class PayCalculatorWithThreshold : PayCalculator
    {
        public static double CalculateTaxAmount(double payGrossCalculated)
        {
            var taxRates = new FileHelper().GetPaySlipTaxRate("withthreshold");
            return CalculateTaxAmount(payGrossCalculated, taxRates);
        }
    }
}
