namespace WebApplication8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dhrdg : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.USER_PROFILE", "PROFILECODE");
        }
        
        public override void Down()
        {
            AddColumn("dbo.USER_PROFILE", "PROFILECODE", c => c.Int(nullable: false));
        }
    }
}
