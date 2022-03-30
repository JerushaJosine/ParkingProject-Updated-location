namespace authpark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loc : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Parkings", name: "GetLocation_LocationId", newName: "Location_Table_LocationId");
            RenameColumn(table: "dbo.Parkings", name: "GetUsers_Id", newName: "Users_Table_Id");
            RenameIndex(table: "dbo.Parkings", name: "IX_GetLocation_LocationId", newName: "IX_Location_Table_LocationId");
            RenameIndex(table: "dbo.Parkings", name: "IX_GetUsers_Id", newName: "IX_Users_Table_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Parkings", name: "IX_Users_Table_Id", newName: "IX_GetUsers_Id");
            RenameIndex(table: "dbo.Parkings", name: "IX_Location_Table_LocationId", newName: "IX_GetLocation_LocationId");
            RenameColumn(table: "dbo.Parkings", name: "Users_Table_Id", newName: "GetUsers_Id");
            RenameColumn(table: "dbo.Parkings", name: "Location_Table_LocationId", newName: "GetLocation_LocationId");
        }
    }
}
