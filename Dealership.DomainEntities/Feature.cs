﻿using System.Collections.Generic;

namespace Dealership.DomainEntities
{
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
