namespace AltairCodex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdentityIdColumnInAppUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppUsers", "IdentityId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppUsers", "IdentityId");
        }
    }
}
