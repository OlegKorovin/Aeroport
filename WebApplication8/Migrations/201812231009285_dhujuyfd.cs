namespace WebApplication8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dhujuyfd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.USER_PROFILE", "PROFILECODE", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.USER_PROFILE", "PROFILECODE");
        }
    }
}
