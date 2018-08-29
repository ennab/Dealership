using Dealership.BLL.Repositories;
using Dealership.DomainEntities;
using System.Collections.Generic;
using System.Linq;

namespace Dealership.DAL.Repositories
{
    class ClientRepository : Repository<Cliant>, IClientRepository
    {
        public ClientRepository(ApplicationDBContext context) : base(context)
        {

        }
        public ApplicationDBContext ApplicationDBContext { get { return Context as ApplicationDBContext; } }

        public IEnumerable<Cliant> GetAllClients()
        {
            return ApplicationDBContext.Clients.ToList();
        }
    }
}
