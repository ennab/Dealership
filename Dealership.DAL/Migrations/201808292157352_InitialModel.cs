namespace Dealership.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Makes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MakeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Makes", t => t.MakeId, cascadeDelete: true)
                .Index(t => t.MakeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Models", "MakeId", "dbo.Makes");
            DropIndex("dbo.Models", new[] { "MakeId" });
            DropTable("dbo.Models");
            DropTable("dbo.Makes");
        }
    }
}
