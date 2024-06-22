using LoanInterestSystem.Server.Models;

namespace LoanInterestSystem.Server.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly List<Client> _clients = new List<Client>
    {
        new Client { Id = 1, Age = 18 },
        new Client { Id = 2, Age = 25 },
        new Client { Id = 3, Age = 40 }
    };

        public Client GetClientById(int id)
        {
            return _clients.FirstOrDefault(c => c.Id == id);
        }
    }
}
