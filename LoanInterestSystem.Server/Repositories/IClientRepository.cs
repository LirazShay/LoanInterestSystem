using LoanInterestSystem.Server.Models;

namespace LoanInterestSystem.Server.Repositories
{
    public interface IClientRepository
    {
        Client GetClientById(int id);
    }
}
