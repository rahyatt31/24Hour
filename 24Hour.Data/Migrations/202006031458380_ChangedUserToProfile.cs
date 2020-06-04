namespace _24Hour.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedUserToProfile : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.User", newName: "Profile");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Profile", newName: "User");
        }
    }
}
