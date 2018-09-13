namespace Dealership.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigClient : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Cliants", newName: "Clients");
            RenameColumn(table: "dbo.Vehicles", name: "CliantId", newName: "ClientId");
            RenameIndex(table: "dbo.Vehicles", name: "IX_CliantId", newName: "IX_ClientId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Vehicles", name: "IX_ClientId", newName: "IX_CliantId");
            RenameColumn(table: "dbo.Vehicles", name: "ClientId", newName: "CliantId");
            RenameTable(name: "dbo.Clients", newName: "Cliants");
        }
    }
}
