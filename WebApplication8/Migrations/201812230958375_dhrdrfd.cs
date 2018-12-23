namespace WebApplication8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dhrdrfd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "IdPROFILE", "dbo.USER_PROFILE");
            DropPrimaryKey("dbo.USER_PROFILE");
            AlterColumn("dbo.USER_PROFILE", "PROFILECODE", c => c.Int(nullable: false));
            AlterColumn("dbo.USER_PROFILE", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.USER_PROFILE", "Id");
            AddForeignKey("dbo.Users", "IdPROFILE", "dbo.USER_PROFILE", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "IdPROFILE", "dbo.USER_PROFILE");
            DropPrimaryKey("dbo.USER_PROFILE");
            AlterColumn("dbo.USER_PROFILE", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.USER_PROFILE", "PROFILECODE", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.USER_PROFILE", "PROFILECODE");
            AddForeignKey("dbo.Users", "IdPROFILE", "dbo.USER_PROFILE", "PROFILECODE", cascadeDelete: true);
        }
    }
}
