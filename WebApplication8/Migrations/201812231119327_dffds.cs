namespace WebApplication8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dffds : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.USER_PROFILE", "PROFILECODE", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.USER_PROFILE", new[] { "PROFILECODE" });
        }
    }
}
