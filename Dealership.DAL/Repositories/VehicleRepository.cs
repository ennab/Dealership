using Dealership.BLL.Repositories;
using Dealership.DomainEntities;
using System.Collections.Generic;
using System.Linq;

namespace Dealership.DAL.Repositories
{
    class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(ApplicationDBContext _context) : base(_context)
        {
        }
        public IEnumerable<Vehicle> GetBestSellingVehicles(int count)
        {
            return ApplicationDBContext.Vehicles.OrderByDescending(c => c.Name).Take(count).ToList();
        }
        public ApplicationDBContext ApplicationDBContext { get { return Context as ApplicationDBContext; } }
    }
}
