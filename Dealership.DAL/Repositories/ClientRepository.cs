using Dealership.BLL.Repositories;
using Dealership.DomainEntities;
using System.Collections.Generic;
using System.Linq;

namespace Dealership.DAL.Repositories
{
    class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDBContext context) : base(context)
        {

        }
        public ApplicationDBContext ApplicationDBContext { get { return Context as ApplicationDBContext; } }

        public IEnumerable<Client> GetAllClients()
        {
            return ApplicationDBContext.Clients.ToList();
        }
    }
}
