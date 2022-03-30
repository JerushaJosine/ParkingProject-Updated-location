namespace authpark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TotalVacancies = c.Int(nullable: false),
                        Langitude = c.String(nullable: false),
                        Longitute = c.String(nullable: false),
                        Price = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Parking_ParkingId = c.Int(),
                    })
                .PrimaryKey(t => t.LocationId)
                .ForeignKey("dbo.Parkings", t => t.Parking_ParkingId)
                .Index(t => t.Parking_ParkingId);
            
            CreateTable(
                "dbo.Parkings",
                c => new
                    {
                        ParkingId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        LocationId = c.String(),
                        VehicalRegNo = c.String(nullable: false),
                        CheckinTime = c.DateTime(),
                        CheckoutTime = c.DateTime(),
                        ParkingStatus = c.String(),
                    })
                .PrimaryKey(t => t.ParkingId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        location = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Parking_ParkingId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Parkings", t => t.Parking_ParkingId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Parking_ParkingId);
            
            CreateTable(
                "dbo.UserCliam",
                c => new
                    {
                        ClaimId = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.ClaimId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.RoleId)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.User", "Parking_ParkingId", "dbo.Parkings");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.UserCliam", "UserId", "dbo.User");
            DropForeignKey("dbo.Locations", "Parking_ParkingId", "dbo.Parkings");
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserLogin", new[] { "UserId" });
            DropIndex("dbo.UserCliam", new[] { "UserId" });
            DropIndex("dbo.User", new[] { "Parking_ParkingId" });
            DropIndex("dbo.User", "UserNameIndex");
            DropIndex("dbo.Locations", new[] { "Parking_ParkingId" });
            DropTable("dbo.Roles");
            DropTable("dbo.UserRole");
            DropTable("dbo.UserLogin");
            DropTable("dbo.UserCliam");
            DropTable("dbo.User");
            DropTable("dbo.Parkings");
            DropTable("dbo.Locations");
        }
    }
}
