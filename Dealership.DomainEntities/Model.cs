﻿using System.Collections.Generic;

namespace Dealership.DomainEntities
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Make Make { get; set; }
        public int MakeId { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
