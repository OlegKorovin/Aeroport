namespace WebApplication8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PROFILECODE : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "IdPROFILE", "dbo.USER_PROFILE");
            DropIndex("dbo.Users", new[] { "IdPROFILE" });
            DropPrimaryKey("dbo.USER_PROFILE");
            AddColumn("dbo.USER_PROFILE", "PROFILECODE", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.USER_PROFILE", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "IdPROFILE", c => c.String(maxLength: 50));
            AddPrimaryKey("dbo.USER_PROFILE", "PROFILECODE");
            CreateIndex("dbo.Users", "IdPROFILE");
            AddForeignKey("dbo.Users", "IdPROFILE", "dbo.USER_PROFILE", "PROFILECODE");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "IdPROFILE", "dbo.USER_PROFILE");
            DropIndex("dbo.Users", new[] { "IdPROFILE" });
            DropPrimaryKey("dbo.USER_PROFILE");
            AlterColumn("dbo.Users", "IdPROFILE", c => c.Int(nullable: false));
            AlterColumn("dbo.USER_PROFILE", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.USER_PROFILE", "PROFILECODE");
            AddPrimaryKey("dbo.USER_PROFILE", "Id");
            CreateIndex("dbo.Users", "IdPROFILE");
            AddForeignKey("dbo.Users", "IdPROFILE", "dbo.USER_PROFILE", "Id", cascadeDelete: true);
        }
    }
}
