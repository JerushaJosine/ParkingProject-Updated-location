namespace authpark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Parkings", "Location_Table_LocationId", "dbo.Locations");
            DropIndex("dbo.Parkings", new[] { "Location_Table_LocationId" });
            DropColumn("dbo.Parkings", "LocationId");
            RenameColumn(table: "dbo.Parkings", name: "Location_Table_LocationId", newName: "LocationId");
            AlterColumn("dbo.Parkings", "LocationId", c => c.Int(nullable: false));
            AlterColumn("dbo.Parkings", "LocationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Parkings", "LocationId");
            AddForeignKey("dbo.Parkings", "LocationId", "dbo.Locations", "LocationId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parkings", "LocationId", "dbo.Locations");
            DropIndex("dbo.Parkings", new[] { "LocationId" });
            AlterColumn("dbo.Parkings", "LocationId", c => c.Int());
            AlterColumn("dbo.Parkings", "LocationId", c => c.String());
            RenameColumn(table: "dbo.Parkings", name: "LocationId", newName: "Location_Table_LocationId");
            AddColumn("dbo.Parkings", "LocationId", c => c.String());
            CreateIndex("dbo.Parkings", "Location_Table_LocationId");
            AddForeignKey("dbo.Parkings", "Location_Table_LocationId", "dbo.Locations", "LocationId");
        }
    }
}
