namespace LoanInterestSystem.Server.Strategies
{
    public class InterestStrategyFactory
    {
        public static IInterestStrategy GetStrategy(int age)
        {
            if (age < 20)
            {
                return new Below20Strategy();
            }
            else if (age >= 20 && age <= 35)
            {
                return new Between20And35Strategy();
            }
            else
            {
                return new Above35Strategy();
            }
        }
    }
}
