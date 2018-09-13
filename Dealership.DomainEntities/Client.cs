using System.Collections.Generic;

namespace Dealership.DomainEntities
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNum { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
