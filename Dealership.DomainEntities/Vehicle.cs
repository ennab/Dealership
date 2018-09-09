using System.Collections.Generic;

namespace Dealership.DomainEntities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VIN { get; set; }
        public string StockNum { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public ICollection<Cliant> Cliants { get; set; }
    }
}
