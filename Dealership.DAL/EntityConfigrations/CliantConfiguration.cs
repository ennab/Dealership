using Dealership.DomainEntities;
using System.Data.Entity.ModelConfiguration;

namespace Dealership.DAL.EntityConfigrations
{
    class CliantConfiguration : EntityTypeConfiguration<Client>
    {
        public CliantConfiguration()
        {
            HasKey(v => v.Id);

            Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(255);
            Property(p => p.LastName)
               .IsRequired()
               .HasMaxLength(255);

            HasRequired(a => a.Address)
                .WithRequiredPrincipal(c => c.Client);

        }
    }
}
