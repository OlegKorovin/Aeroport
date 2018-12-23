namespace WebApplication8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dhujujh : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IdPROFILECODE", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IdPROFILECODE");
        }
    }
}
