namespace PayApplication
{
    /// <summary>
    /// This class sets the tax rates to later work with FileHelper and PayCalculator.
    /// </summary>
    public class TaxRate
    {
        public int MinWeeklyEarnings { get; set; }
        public int MaxWeeklyEarnings { get; set; }
        public double TaxRateA {  get; set; }
        public double TaxRateB { get; set; }

        public override string ToString()
        {
            return $"{MaxWeeklyEarnings} {TaxRateA} {TaxRateB}";
        }
    }
}
