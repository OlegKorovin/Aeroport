namespace WebApplication8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dhd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "IdPROFILE", "dbo.USER_PROFILE");
            DropPrimaryKey("dbo.USER_PROFILE");
            AlterColumn("dbo.USER_PROFILE", "PROFILECODE", c => c.String(nullable: false, maxLength: 50));
            AddPrimaryKey("dbo.USER_PROFILE", "PROFILECODE");
            AddForeignKey("dbo.Users", "IdPROFILE", "dbo.USER_PROFILE", "PROFILECODE");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "IdPROFILE", "dbo.USER_PROFILE");
            DropPrimaryKey("dbo.USER_PROFILE");
            AlterColumn("dbo.USER_PROFILE", "PROFILECODE", c => c.String(nullable: false, maxLength: 50));
            AddPrimaryKey("dbo.USER_PROFILE", "PROFILECODE");
            AddForeignKey("dbo.Users", "IdPROFILE", "dbo.USER_PROFILE", "PROFILECODE");
        }
    }
}
