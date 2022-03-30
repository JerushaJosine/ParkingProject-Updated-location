namespace authpark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class police : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Police",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ServiceStation = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Police");
        }
    }
}
