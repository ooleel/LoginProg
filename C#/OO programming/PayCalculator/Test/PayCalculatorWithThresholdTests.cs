using NUnit.Framework;

namespace PayApplication.Tests
{
    [TestFixture]
    public class PayCalculatorWithThresholdTests
    {
        [TestCase(0d, 0d)]
        [TestCase(500d, 33.0929d)]
        [TestCase(1000000d, 469436.9457d)]
        public void TestPayCalculatorWithThreshold(double grossPay, double expectedResult)
        {
            var result = PayCalculatorWithThreshold.CalculateTaxAmount(grossPay);
            Assert.That(result, Is.EqualTo(expectedResult).Within(0.01));
        }
    }
}
