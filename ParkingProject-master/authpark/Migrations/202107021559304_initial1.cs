namespace authpark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locations", "Parking_ParkingId", "dbo.Parkings");
            DropForeignKey("dbo.User", "Parking_ParkingId", "dbo.Parkings");
            DropIndex("dbo.Locations", new[] { "Parking_ParkingId" });
            DropIndex("dbo.User", new[] { "Parking_ParkingId" });
            AddColumn("dbo.Parkings", "GetLocation_LocationId", c => c.Int());
            AddColumn("dbo.Parkings", "GetUsers_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Parkings", "GetLocation_LocationId");
            CreateIndex("dbo.Parkings", "GetUsers_Id");
            AddForeignKey("dbo.Parkings", "GetLocation_LocationId", "dbo.Locations", "LocationId");
            AddForeignKey("dbo.Parkings", "GetUsers_Id", "dbo.User", "UserId");
            DropColumn("dbo.Locations", "Parking_ParkingId");
            DropColumn("dbo.User", "Parking_ParkingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Parking_ParkingId", c => c.Int());
            AddColumn("dbo.Locations", "Parking_ParkingId", c => c.Int());
            DropForeignKey("dbo.Parkings", "GetUsers_Id", "dbo.User");
            DropForeignKey("dbo.Parkings", "GetLocation_LocationId", "dbo.Locations");
            DropIndex("dbo.Parkings", new[] { "GetUsers_Id" });
            DropIndex("dbo.Parkings", new[] { "GetLocation_LocationId" });
            DropColumn("dbo.Parkings", "GetUsers_Id");
            DropColumn("dbo.Parkings", "GetLocation_LocationId");
            CreateIndex("dbo.User", "Parking_ParkingId");
            CreateIndex("dbo.Locations", "Parking_ParkingId");
            AddForeignKey("dbo.User", "Parking_ParkingId", "dbo.Parkings", "ParkingId");
            AddForeignKey("dbo.Locations", "Parking_ParkingId", "dbo.Parkings", "ParkingId");
        }
    }
}
