using Dealership.DAL.EntityConfigrations;
using Dealership.DomainEntities;
using System.Data.Entity;

namespace Dealership.DAL
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
            : base("name=PlutoContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Make> Makes { get; set; }
        public virtual DbSet<Model> Models { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MakeConfiguration());
        }
    }
}
