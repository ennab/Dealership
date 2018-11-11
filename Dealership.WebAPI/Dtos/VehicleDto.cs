using System.Collections.Generic;

namespace Dealership.WebAPI.Dtos
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VIN { get; set; }
        public string StockNum { get; set; }
        public int ModelId { get; set; }
        public int? ClientId { get; set; }
        public ICollection<FeatureDto> Features { get; set; }
    }
}