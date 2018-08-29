using Dealership.BLL.Repositories;
using Dealership.DomainEntities;
using System.Collections.Generic;
using System.Linq;

namespace Dealership.DAL.Repositories
{
    public class MakeRepository : Repository<Make>, IMakeRepository
    {
        public MakeRepository(ApplicationDBContext context)
            : base(context)
        {
        }

        public IEnumerable<Make> GetTopSellingMakes(int count)
        {
            return ApplicationDBContext.Makes.OrderByDescending(c => c.Name).Take(count).ToList();
        }

        public IEnumerable<Make> GetMakesWithModels(int pageIndex, int pageSize = 10)
        {
            return ApplicationDBContext.Makes
                //.Include(c => c.Author)
                .OrderBy(c => c.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public ApplicationDBContext ApplicationDBContext
        {
            get { return Context as ApplicationDBContext; }
        }
    }
}
