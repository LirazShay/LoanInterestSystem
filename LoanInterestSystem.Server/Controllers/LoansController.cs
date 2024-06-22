using LoanInterestSystem.Server.Models;
using LoanInterestSystem.Server.Repositories;
using LoanInterestSystem.Server.Strategies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanInterestSystem.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public LoansController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }


        [HttpPost]
        public ActionResult<LoanResponse> CalculateLoan([FromBody] LoanRequest request)
        {
            var client = _clientRepository.GetClientById(request.ClientId);
            if (client == null) return NotFound("Client not found");

            var strategy = InterestStrategyFactory.GetStrategy(client.Age);
            var totalAmount = strategy.CalculateInterest(request.Amount, request.PeriodInMonths, 0);

            return new LoanResponse { TotalAmount = totalAmount };
        }
    }
}