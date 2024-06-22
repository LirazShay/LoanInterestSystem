namespace LoanInterestSystem.Server.Strategies
{
    public class Above35Strategy : IInterestStrategy
    {
        public decimal CalculateInterest(decimal amount, int periodInMonths, decimal primeInterest)
        {
            decimal interestRate;

            if (amount <= 15000)
            {
                interestRate = 1.5m + primeInterest; // 1.5% + prime interest
            }
            else if (amount > 15000 && amount <= 30000)
            {
                interestRate = 3m + primeInterest; // 3% + prime interest
            }
            else
            {
                interestRate = 1m; // 1% fixed
            }

            decimal baseInterest = interestRate / 100 * amount;
            decimal extraInterest = CalculateExtraInterest(amount, periodInMonths);
            decimal totalInterest = baseInterest + extraInterest;

            return amount + totalInterest; // Return the total amount (principal + interest)
        }

        private decimal CalculateExtraInterest(decimal amount, int periodInMonths)
        {
            if (periodInMonths > 12)
            {
                int extraMonths = periodInMonths - 12;
                decimal extraInterestRate = extraMonths * 0.15m;
                return extraInterestRate / 100 * amount;
            }
            return 0;
        }
    }
}
