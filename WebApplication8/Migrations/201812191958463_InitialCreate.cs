namespace WebApplication8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Author = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ROLEs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NAME = c.String(maxLength: 100),
                        DISCRIPTION = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.USER_PROFILE",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PROFILE = c.String(maxLength: 100),
                        IDPROFILEROLE = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ROLEs", t => t.IDPROFILEROLE, cascadeDelete: true)
                .Index(t => t.IDPROFILEROLE);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        login = c.String(maxLength: 100),
                        FIO = c.String(maxLength: 200),
                        IdPROFILE = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.USER_PROFILE", t => t.IdPROFILE, cascadeDelete: true)
                .Index(t => t.IdPROFILE);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "IdPROFILE", "dbo.USER_PROFILE");
            DropForeignKey("dbo.USER_PROFILE", "IDPROFILEROLE", "dbo.ROLEs");
            DropIndex("dbo.Users", new[] { "IdPROFILE" });
            DropIndex("dbo.USER_PROFILE", new[] { "IDPROFILEROLE" });
            DropTable("dbo.Users");
            DropTable("dbo.USER_PROFILE");
            DropTable("dbo.ROLEs");
            DropTable("dbo.Books");
        }
    }
}
