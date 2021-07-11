namespace AssetsDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable_LocationId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assets", "LocationId", "dbo.Locations");
            DropIndex("dbo.Assets", new[] { "LocationId" });
            AlterColumn("dbo.Assets", "LocationId", c => c.Int());
            CreateIndex("dbo.Assets", "LocationId");
            AddForeignKey("dbo.Assets", "LocationId", "dbo.Locations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assets", "LocationId", "dbo.Locations");
            DropIndex("dbo.Assets", new[] { "LocationId" });
            AlterColumn("dbo.Assets", "LocationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Assets", "LocationId");
            AddForeignKey("dbo.Assets", "LocationId", "dbo.Locations", "Id", cascadeDelete: true);
        }
    }
}
