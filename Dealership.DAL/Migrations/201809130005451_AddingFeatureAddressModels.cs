namespace Dealership.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingFeatureAddressModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VehicleCliants", "Vehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.VehicleCliants", "Cliant_Id", "dbo.Cliants");
            DropForeignKey("dbo.Vehicles", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Models", "MakeId", "dbo.Makes");
            DropIndex("dbo.VehicleCliants", new[] { "Vehicle_Id" });
            DropIndex("dbo.VehicleCliants", new[] { "Cliant_Id" });
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.String(),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliants", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleFeatures",
                c => new
                    {
                        Vehicle_Id = c.Int(nullable: false),
                        Feature_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vehicle_Id, t.Feature_Id })
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_Id, cascadeDelete: true)
                .ForeignKey("dbo.Features", t => t.Feature_Id, cascadeDelete: true)
                .Index(t => t.Vehicle_Id)
                .Index(t => t.Feature_Id);
            
            AddColumn("dbo.Cliants", "FirstName", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Cliants", "MiddleName", c => c.String());
            AddColumn("dbo.Cliants", "LastName", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Cliants", "AddressId", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "CliantId", c => c.Int());
            AlterColumn("dbo.Vehicles", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Vehicles", "VIN", c => c.String(nullable: false));
            AlterColumn("dbo.Makes", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Vehicles", "CliantId");
            AddForeignKey("dbo.Vehicles", "CliantId", "dbo.Cliants", "Id");
            AddForeignKey("dbo.Vehicles", "ModelId", "dbo.Models", "Id");
            AddForeignKey("dbo.Models", "MakeId", "dbo.Makes", "Id");
            DropColumn("dbo.Cliants", "Name");
            DropColumn("dbo.Cliants", "Address");
            DropTable("dbo.VehicleCliants");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VehicleCliants",
                c => new
                    {
                        Vehicle_Id = c.Int(nullable: false),
                        Cliant_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vehicle_Id, t.Cliant_Id });
            
            AddColumn("dbo.Cliants", "Address", c => c.String());
            AddColumn("dbo.Cliants", "Name", c => c.String());
            DropForeignKey("dbo.Models", "MakeId", "dbo.Makes");
            DropForeignKey("dbo.Vehicles", "ModelId", "dbo.Models");
            DropForeignKey("dbo.VehicleFeatures", "Feature_Id", "dbo.Features");
            DropForeignKey("dbo.VehicleFeatures", "Vehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "CliantId", "dbo.Cliants");
            DropForeignKey("dbo.Addresses", "Id", "dbo.Cliants");
            DropIndex("dbo.VehicleFeatures", new[] { "Feature_Id" });
            DropIndex("dbo.VehicleFeatures", new[] { "Vehicle_Id" });
            DropIndex("dbo.Vehicles", new[] { "CliantId" });
            DropIndex("dbo.Addresses", new[] { "Id" });
            AlterColumn("dbo.Makes", "Name", c => c.String());
            AlterColumn("dbo.Vehicles", "VIN", c => c.String());
            AlterColumn("dbo.Vehicles", "Name", c => c.String());
            DropColumn("dbo.Vehicles", "CliantId");
            DropColumn("dbo.Cliants", "AddressId");
            DropColumn("dbo.Cliants", "LastName");
            DropColumn("dbo.Cliants", "MiddleName");
            DropColumn("dbo.Cliants", "FirstName");
            DropTable("dbo.VehicleFeatures");
            DropTable("dbo.Features");
            DropTable("dbo.Addresses");
            CreateIndex("dbo.VehicleCliants", "Cliant_Id");
            CreateIndex("dbo.VehicleCliants", "Vehicle_Id");
            AddForeignKey("dbo.Models", "MakeId", "dbo.Makes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Vehicles", "ModelId", "dbo.Models", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VehicleCliants", "Cliant_Id", "dbo.Cliants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VehicleCliants", "Vehicle_Id", "dbo.Vehicles", "Id", cascadeDelete: true);
        }
    }
}
