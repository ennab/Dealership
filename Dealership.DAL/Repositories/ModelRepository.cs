﻿using Dealership.BLL.Repositories;
using Dealership.DomainEntities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Dealership.DAL.Repositories
{
    public class ModelRepository : Repository<Model>, IModelRepository
    {
        public ModelRepository(ApplicationDBContext context) : base(context)
        {

        }

        public IEnumerable<Model> GetTopSellingModels(int count)
        {
            return ApplicationDBContext.Models.OrderByDescending(c => c.Name).Take(count).ToList();
        }

        public IEnumerable<Model> GetAllWithMakers()
        {
            return ApplicationDBContext.Models.Include(c => c.Make).ToList();
        }

        public ApplicationDBContext ApplicationDBContext
        {
            get { return Context as ApplicationDBContext; }
        }
    }
}
