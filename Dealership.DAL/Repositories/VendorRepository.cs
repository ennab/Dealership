using Dealership.BLL.Repositories;
using Dealership.DomainEntities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Dealership.DAL.Repositories
{
    class VendorRepository : Repository<Vendor>, IVendorRepository
    {
        public VendorRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Vendor> GetAllByName()
        {
            return ApplicationDBContext.Venders.OrderByDescending(c => c.Name);
        }

        public IEnumerable<Vendor> GetTopVenders(int count)
        {
            return ApplicationDBContext.Venders.OrderByDescending(c => c.Id);
        }
        public ApplicationDBContext ApplicationDBContext { get { return Context as ApplicationDBContext; } }
    }
}
