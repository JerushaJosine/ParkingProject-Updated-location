namespace authpark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locationaddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "Address", c => c.String(nullable: false, maxLength: 350));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locations", "Address");
        }
    }
}
