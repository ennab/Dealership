using Dealership.DomainEntities;
using System.Collections.Generic;

namespace Dealership.BLL.Repositories
{
    public interface IMakeRepository : IRepository<Make>
    {
        IEnumerable<Make> GetTopSellingMakes(int count);
        IEnumerable<Make> GetMakesWithModels(int pageIndex, int pageSize);
    }
}
