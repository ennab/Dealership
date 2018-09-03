using Dealership.DomainEntities;
using System.Collections.Generic;
using System.Linq;

namespace Dealership.BLL.Services
{
    class VehicleServices
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public VehicleServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Fetches vehicle details by id
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        public Vehicle GetProductById(int vehicleId)
        {
            var vehicle = _unitOfWork.Vehicles.Get(vehicleId);
            if (vehicle != null)
            {
                //Mapper.CreateMap<Product, ProductEntity>();
                //var productModel = Mapper.Map<Product, ProductEntity>(product);
                //return productModel;
                return vehicle;
            }
            return null;
        }

        /// <summary>
        /// Fetches all the vehicles.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Vehicle> GetAllVehicles()
        {
            var vehicles = _unitOfWork.Vehicles.GetAll().ToList();
            if (vehicles.Any())
            {
                //Mapper.CreateMap<Product, ProductEntity>();
                //var productsModel = Mapper.Map<List<Product>, List<ProductEntity>>(products);
                //return productsModel;
                return vehicles;
            }
            return null;
        }

        /// <summary>
        /// Creates a vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public int CreateProduct(Vehicle vehicle)
        {
            //using (var scope = new TransactionScope())
            //{
            //var vehicle = new Vehicle
            //{
            //    ProductName = productEntity.ProductName
            //};
            _unitOfWork.Vehicles.Add(vehicle);
            _unitOfWork.Complete();
            //scope.Complete();
            return vehicle.Id;
            //}
        }

        /// <summary>
        /// Updates a Vehicle
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <param name="Vehicle"></param>
        /// <returns></returns>
        public bool UpdateVehicle(int vehicleId, Vehicle vehicle)
        {
            var success = false;
            if (vehicle != null)
            {
                var _vehicle = _unitOfWork.Vehicles.Get(vehicleId);
                if (_vehicle != null)
                {
                    _vehicle.Name = vehicle.Name;
                    //_unitOfWork.Vehicles.Update(_vehicle);
                    _unitOfWork.Complete();

                    success = true;
                }
            }
            return success;
        }

        /// <summary>
        /// Deletes a particular vehicle
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        public bool DeleteVehicle(int vehicleId)
        {
            var success = false;
            if (vehicleId > 0)
            {
                var _vehicle = _unitOfWork.Vehicles.Get(vehicleId);
                if (_vehicle != null)
                {

                    _unitOfWork.Vehicles.Remove(_vehicle);
                    _unitOfWork.Complete();
                    success = true;
                }
            }
            return success;
        }
    }
}
