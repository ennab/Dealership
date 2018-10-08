using Dealership.DomainEntities;
using System.Data.Entity.ModelConfiguration;

namespace Dealership.DAL.EntityConfigrations
{
    class VehicleConfiguration : EntityTypeConfiguration<Vehicle>
    {
        public VehicleConfiguration()
        {
            HasKey(v => v.Id);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);
            Property(p => p.VIN)
                .IsRequired();

            HasRequired(m => m.Model)
                .WithMany(v => v.Vehicles)
                .HasForeignKey(v => v.ModelId).WillCascadeOnDelete(false);
            HasMany(f => f.Features)
                .WithMany(v => v.Vehicles)
                .Map(t =>
                {
                    t.ToTable("VehicleFeatures");
                    t.MapLeftKey("VehicleId");
                    t.MapRightKey("FeaturelId");
                });
            HasOptional(c => c.Client)
                .WithMany(v => v.Vehicles);

        }
    }
}
