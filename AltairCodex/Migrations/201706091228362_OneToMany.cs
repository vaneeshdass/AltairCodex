namespace AltairCodex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneToMany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        AppUserId = c.Int(nullable: false),
                        Name = c.String(),
                        ReleaseYear = c.Int(nullable: false),
                        Platform = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameId)
                .ForeignKey("dbo.AppUsers", t => t.AppUserId, cascadeDelete: true)
                .Index(t => t.AppUserId);
            
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        AppUserId = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        AddressLine = c.String(),
                        Country = c.String(),
                        PinCode = c.Long(nullable: false),
                        Location = c.Geography(),
                    })
                .PrimaryKey(t => t.AppUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "AppUserId", "dbo.AppUsers");
            DropIndex("dbo.Games", new[] { "AppUserId" });
            DropTable("dbo.AppUsers");
            DropTable("dbo.Games");
        }
    }
}
