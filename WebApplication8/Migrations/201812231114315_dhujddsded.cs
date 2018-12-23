namespace WebApplication8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dhujddsded : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Users", "login", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "login" });
        }
    }
}
