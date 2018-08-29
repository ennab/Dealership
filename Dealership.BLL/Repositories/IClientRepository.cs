using Dealership.DomainEntities;
using System.Collections.Generic;

namespace Dealership.BLL.Repositories
{
    public interface IClientRepository : IRepository<Cliant>
    {
        IEnumerable<Cliant> GetAllClients();
    }
}
