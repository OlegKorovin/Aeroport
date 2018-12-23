namespace WebApplication8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dhujujhjj : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.USER_PROFILE", "PROFILECODE", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "IdPROFILECODE", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "IdPROFILECODE", c => c.String(maxLength: 200));
            AlterColumn("dbo.USER_PROFILE", "PROFILECODE", c => c.String(maxLength: 50));
        }
    }
}
