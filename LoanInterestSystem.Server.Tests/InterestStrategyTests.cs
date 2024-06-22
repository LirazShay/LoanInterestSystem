using LoanInterestSystem.Server.Models;
using LoanInterestSystem.Server.Strategies;

namespace LoanInterestSystem.Server.Tests
{

    [TestFixture]
    public class InterestCalculatorTests
    {
        private const decimal PrimeInterestRate = 1.5m; // Prime interest rate is given as 1.5%

        [TestCase(19, 1000, 12, 1035)] // Age < 20, period = 12 months, 2% + 1.5% prime interest = 3.5%
        [TestCase(19, 1000, 18, 1044)] // Age < 20, period = 18 months, additional 0.15% per month for 6 extra months, total interest = 3.5% + 0.9% = 4.4%
        [TestCase(19, 1000, 24, 1053)] // Age < 20, period = 24 months, additional 0.15% per month for 12 extra months, total interest = 3.5% + 1.8% = 5.3%

        [TestCase(25, 5000, 12, 5100)] // Age 20-35, amount ≤ 5000, period = 12 months, 2% fixed
        [TestCase(25, 5000, 18, 5145)] // Age 20-35, amount ≤ 5000, period = 18 months, 2% + extra 0.9% = 2.9%
        [TestCase(25, 10000, 12, 10300)] // Age 20-35, 5000 < amount ≤ 30000, period = 12 months, 3% total
        [TestCase(25, 10000, 24, 10480)] // Age 20-35, 5000 < amount ≤ 30000, period = 24 months, 3% + extra 1.8% = 4.8%
        [TestCase(25, 40000, 12, 41000)] // Age 20-35, amount > 30000, period = 12 months, 2.5% total
        [TestCase(25, 40000, 18, 41360)] // Age 20-35, amount > 30000, period = 18 months, 2.5% + extra 0.9% = 3.4%

        [TestCase(40, 15000, 12, 15450)] // Age > 35, amount ≤ 15000, period = 12 months, 3% total
        [TestCase(40, 15000, 18, 15585)] // Age > 35, amount ≤ 15000, period = 18 months, 3% + extra 0.9% = 3.9%
        [TestCase(40, 20000, 12, 20900)] // Age > 35, 15000 < amount ≤ 30000, period = 12 months, 4.5% total
        [TestCase(40, 20000, 24, 21260)] // Age > 35, 15000 < amount ≤ 30000, period = 24 months, 4.5% + extra 1.8% = 6.3%
        [TestCase(40, 40000, 12, 40400)] // Age > 35, amount > 30000, period = 12 months, 1% total
        [TestCase(40, 40000, 18, 40760)] // Age > 35, amount > 30000, period = 18 months, 1% + extra 0.9% = 1.9%
        public void CalculateInterest_WhenCalled_ReturnsCorrectTotalAmount(int age, int amount, int periodInMonths, int expectedTotalAmount)
        {
            var strategy = InterestStrategyFactory.GetStrategy(age);

            var totalAmount = strategy.CalculateInterest(amount, periodInMonths, PrimeInterestRate);

            Assert.That(totalAmount, Is.EqualTo(expectedTotalAmount));
        }
    }
}
