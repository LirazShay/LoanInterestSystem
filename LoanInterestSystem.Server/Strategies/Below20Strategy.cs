namespace LoanInterestSystem.Server.Strategies
{
    public class Below20Strategy : IInterestStrategy
    {
        public decimal CalculateInterest(decimal amount, int periodInMonths, decimal primeInterest)
        {
            decimal baseInterestRate = 2 + primeInterest;
            decimal baseInterest = baseInterestRate / 100 * amount;
            decimal extraInterest = CalculateExtraInterest(periodInMonths, amount);
            decimal totalInterest = baseInterest + extraInterest;
            return amount + totalInterest; // Return the total amount (principal + interest)
        }

        private decimal CalculateExtraInterest(int periodInMonths, decimal amount)
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
