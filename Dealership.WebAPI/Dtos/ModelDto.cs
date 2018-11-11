using System.Collections.Generic;

namespace Dealership.WebAPI.Dtos
{
    public class ModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MakeId { get; set; }
        public ICollection<VehicleDto> Vehicles { get; set; }
    }
}