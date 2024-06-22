namespace LoanInterestSystem.Server.Strategies
{
    public interface IInterestStrategy
    {
        decimal CalculateInterest(decimal amount, int periodInMonths, decimal primeInterest);
    }
}
