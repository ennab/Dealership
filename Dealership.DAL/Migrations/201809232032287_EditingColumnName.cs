namespace Dealership.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditingColumnName : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.VehicleFeatures", name: "ModelId", newName: "FeaturelId");
            RenameIndex(table: "dbo.VehicleFeatures", name: "IX_ModelId", newName: "IX_FeaturelId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.VehicleFeatures", name: "IX_FeaturelId", newName: "IX_ModelId");
            RenameColumn(table: "dbo.VehicleFeatures", name: "FeaturelId", newName: "ModelId");
        }
    }
}
