namespace Dealership.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehicleFeatureConfig : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.VehicleFeatures", name: "Vehicle_Id", newName: "VehicleId");
            RenameColumn(table: "dbo.VehicleFeatures", name: "Feature_Id", newName: "ModelId");
            RenameIndex(table: "dbo.VehicleFeatures", name: "IX_Vehicle_Id", newName: "IX_VehicleId");
            RenameIndex(table: "dbo.VehicleFeatures", name: "IX_Feature_Id", newName: "IX_ModelId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.VehicleFeatures", name: "IX_ModelId", newName: "IX_Feature_Id");
            RenameIndex(table: "dbo.VehicleFeatures", name: "IX_VehicleId", newName: "IX_Vehicle_Id");
            RenameColumn(table: "dbo.VehicleFeatures", name: "ModelId", newName: "Feature_Id");
            RenameColumn(table: "dbo.VehicleFeatures", name: "VehicleId", newName: "Vehicle_Id");
        }
    }
}
