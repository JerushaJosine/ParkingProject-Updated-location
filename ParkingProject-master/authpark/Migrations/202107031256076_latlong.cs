namespace authpark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class latlong : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "Lat", c => c.String(nullable: false));
            AddColumn("dbo.Locations", "Long", c => c.String(nullable: false));
            DropColumn("dbo.Locations", "Langitude");
            DropColumn("dbo.Locations", "Longitute");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "Longitute", c => c.String(nullable: false));
            AddColumn("dbo.Locations", "Langitude", c => c.String(nullable: false));
            DropColumn("dbo.Locations", "Long");
            DropColumn("dbo.Locations", "Lat");
        }
    }
}
