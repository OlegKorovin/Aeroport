namespace WebApplication8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dff : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.USER_PROFILE", new[] { "PROFILECODE" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.USER_PROFILE", "PROFILECODE", unique: true);
        }
    }
}
