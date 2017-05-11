namespace Albaque_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserIdType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Chiffrages", "UserId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Chiffrages", "UserId", c => c.Int(nullable: false));
        }
    }
}
