using System;
using System.Collections.Generic;

namespace PayApplication
{
    /// <summary>
    /// Base class to hold all Pay calculation functions.
    /// Default class behaviour is tax calculated with tax threshold applied.
    /// </summary>
    public class PayCalculator
    {
        /// <summary>
        /// This method calculates the gross pay by taking in the number of worked hours multiplied by the hourly rate. 
        /// </summary>
        /// <param name="workedHours"></param>
        /// <param name="hourlyRate"></param>
        /// <returns>gross pay</returns>
        public static double CalculateGrossPay(int workedHours, int hourlyRate)
        {
            if (workedHours <= 0 || hourlyRate <= 0)
            {
                throw new ArgumentException("Worked hours and hourly rate must be positive.");
            }
            return workedHours * hourlyRate;
        }

        /// <summary>
        /// This method calculates the superannuation amount by taking in the calculated gross pay multiplied by the current superannuation rate (11.5%).
        /// </summary>
        /// <param name="grossPay"></param>
        /// <returns>superannuation amount</returns>
        public static double CalculateSuperAmount(double grossPay)
        {
            var superannuationRate = 0.115;
            return grossPay * superannuationRate;
        }

        /// <summary>
        /// This method calculates the tax amount following the tax formula and by taking in the calculated gross pay and the tax rate associated to the gross pay bracket.
        /// </summary>
        /// <param name="payGrossCalculated"></param>
        /// <param name="taxRates"></param>
        /// <returns>tax amount</returns>
        /// <exception cref="Exception"></exception>
        public static double CalculateTaxAmount(double payGrossCalculated, List<TaxRate> taxRates)
        {
            TaxRate applicableTaxRate = null;
            foreach (var taxRate in taxRates)
            {
                if (payGrossCalculated < taxRate.MaxWeeklyEarnings)
                {
                    applicableTaxRate = taxRate;
                    break;
                }
            }

            if (applicableTaxRate != null)
            {
                return applicableTaxRate.TaxRateA * (payGrossCalculated + 0.99) - applicableTaxRate.TaxRateB;
            }

            throw new Exception("Unable to calculate TaxRate");
        }

        /// <summary>
        /// This method calculates the net pay by taking in the gross pay and the calculated tax amount.
        /// </summary>
        /// <param name="payGrossCalculated"></param>
        /// <param name="taxAmount"></param>
        /// <returns></returns>
        public static double CalculateNetPay(double payGrossCalculated, double taxAmount)
        {
            return payGrossCalculated - taxAmount;
        }
    }
}
