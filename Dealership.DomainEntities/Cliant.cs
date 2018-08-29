using System.Collections.Generic;

namespace Dealership.DomainEntities
{
    public class Cliant
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        public string PhoneNum { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }

    }
}
