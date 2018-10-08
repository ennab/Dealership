using Dealership.BLL.Repositories;
using Dealership.DomainEntities;
using System;
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

        public IEnumerable<Object> GetVehicleFeatures()
        {
            var q = from v in ApplicationDBContext.Vehicles
                    join m in ApplicationDBContext.Models on v.ModelId equals m.Id into g
                    select new { VehicleName = v.Name, Models = g };
            return q;

            var qq = ApplicationDBContext.Vehicles.Join(ApplicationDBContext.Models,
                    v => v.ModelId,
                    m => m.Id,
                    (v, m) => new { VIN = v.VIN, ModelName = m.Name });

        }
        public ApplicationDBContext ApplicationDBContext { get { return Context as ApplicationDBContext; } }
    }
}
