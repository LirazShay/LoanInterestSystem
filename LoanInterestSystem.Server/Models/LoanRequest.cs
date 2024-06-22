namespace LoanInterestSystem.Server.Models
{
    public class LoanRequest
    {
        public int ClientId { get; set; }
        public decimal Amount { get; set; }
        public int PeriodInMonths { get; set; }
    }
}
