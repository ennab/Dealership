using System.Collections.Generic;

namespace Dealership.Services.Concrete
{
    interface IVehicleServices
    {
        Vehicle GetVehicleById(int Id);
        IEnumerable<Vehicle> GetAllVehicles();
        int CreateVehicle(Vehicle vehicle);
        bool UpdateVehicle(int vehicleId, Vehicle vehicle);
        bool DeleteVehicle(int VehicleId);
    }
}
