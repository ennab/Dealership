using System.Collections.Generic;

namespace Dealership.WebAPI.Dtos
{
    public class FeatureDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<VehicleDto> Vehicles { get; set; }
    }
}