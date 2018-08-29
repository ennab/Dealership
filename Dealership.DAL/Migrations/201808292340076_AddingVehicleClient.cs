namespace Dealership.DAL.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddingVehicleClient : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliants",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Address = c.String(),
                    PhoneNum = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Vehicles",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    VIN = c.String(),
                    StockNum = c.String(),
                    ModelId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Models", t => t.ModelId, cascadeDelete: false)
                .Index(t => t.ModelId);

            CreateTable(
                "dbo.VehicleCliants",
                c => new
                {
                    Vehicle_Id = c.Int(nullable: false),
                    Cliant_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Vehicle_Id, t.Cliant_Id })
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cliants", t => t.Cliant_Id, cascadeDelete: true)
                .Index(t => t.Vehicle_Id)
                .Index(t => t.Cliant_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.VehicleCliants", "Cliant_Id", "dbo.Cliants");
            DropForeignKey("dbo.VehicleCliants", "Vehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "ModelId", "dbo.Models");
            DropIndex("dbo.VehicleCliants", new[] { "Cliant_Id" });
            DropIndex("dbo.VehicleCliants", new[] { "Vehicle_Id" });
            DropIndex("dbo.Vehicles", new[] { "ModelId" });
            DropTable("dbo.VehicleCliants");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Cliants");
        }
    }
}
