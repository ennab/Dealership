using Dealership.DomainEntities;
using System.Collections.Generic;

namespace Dealership.BLL.Repositories
{
    public interface IVendorRepository : IRepository<Vendor>
    {
        IEnumerable<Vendor> GetTopVenders(int count);
        IEnumerable<Vendor> GetAllByName();
    }
}
