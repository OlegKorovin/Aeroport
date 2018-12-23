namespace WebApplication8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class key : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "IdPROFILE", "dbo.USER_PROFILE");
            DropIndex("dbo.Users", new[] { "IdPROFILE" });
            DropPrimaryKey("dbo.USER_PROFILE");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.USER_PROFILE", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.USER_PROFILE", "PROFILE", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "login", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "IdPROFILE", c => c.String(maxLength: 100));
            AddPrimaryKey("dbo.USER_PROFILE", "PROFILE");
            AddPrimaryKey("dbo.Users", "login");
            CreateIndex("dbo.Users", "IdPROFILE");
            AddForeignKey("dbo.Users", "IdPROFILE", "dbo.USER_PROFILE", "PROFILE");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "IdPROFILE", "dbo.USER_PROFILE");
            DropIndex("dbo.Users", new[] { "IdPROFILE" });
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.USER_PROFILE");
            AlterColumn("dbo.Users", "IdPROFILE", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "login", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.USER_PROFILE", "PROFILE", c => c.String(maxLength: 100));
            AlterColumn("dbo.USER_PROFILE", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.USER_PROFILE", "Id");
            CreateIndex("dbo.Users", "IdPROFILE");
            AddForeignKey("dbo.Users", "IdPROFILE", "dbo.USER_PROFILE", "Id", cascadeDelete: true);
        }
    }
}
