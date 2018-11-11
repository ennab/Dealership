using Dealership.DomainEntities;
using System.Data.Entity.ModelConfiguration;

namespace Dealership.DAL.EntityConfigrations
{
    class VenderConfiguration : EntityTypeConfiguration<Vendor>
    {
        public VenderConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Name).IsRequired();
        }
    }
}
