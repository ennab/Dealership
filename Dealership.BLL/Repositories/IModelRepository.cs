using Dealership.DomainEntities;
using System.Collections.Generic;

namespace Dealership.BLL.Repositories
{
    public interface IModelRepository : IRepository<Model>
    {
        IEnumerable<Model> GetTopSellingModels(int count);
        IEnumerable<Model> GetAllWithMakers();
    }
}
