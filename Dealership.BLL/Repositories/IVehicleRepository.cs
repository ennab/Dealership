using Dealership.DomainEntities;
using System.Collections.Generic;

namespace Dealership.BLL.Repositories
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        IEnumerable<Vehicle> GetBestSellingVehicles(int count);
    }
}
