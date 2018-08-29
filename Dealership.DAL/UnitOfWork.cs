using Dealership.BLL;
using Dealership.BLL.Repositories;
using Dealership.DAL.Repositories;

namespace Dealership.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
            Makes = new MakeRepository(_context);
            Models = new ModelRepository(_context);
            Vehicles = new VehicleRepository(_context);
            Clients = new ClientRepository(_context);
        }

        public IMakeRepository Makes { get; private set; }
        public IModelRepository Models { get; private set; }
        public IVehicleRepository Vehicles { get; private set; }
        public IClientRepository Clients { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
