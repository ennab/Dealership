using Dealership.DomainEntities;
using System.Data.Entity.ModelConfiguration;

namespace Dealership.DAL.EntityConfigrations
{
    public class MakeConfiguration : EntityTypeConfiguration<Make>
    {
        public MakeConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(255);

            HasMany(m => m.Models)
                .WithRequired(m => m.Make)
                .HasForeignKey(f => f.MakeId).WillCascadeOnDelete(false);
        }

    }
}
