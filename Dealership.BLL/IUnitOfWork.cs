using Dealership.BLL.Repositories;
using System;

namespace Dealership.BLL
{
    public interface IUnitOfWork : IDisposable
    {
        IMakeRepository Makes { get; }
        IModelRepository Models { get; }
        IVehicleRepository Vehicles { get; }
        IClientRepository Clients { get; }
        int Complete();
    }
}
