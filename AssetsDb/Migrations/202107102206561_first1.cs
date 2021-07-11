namespace AssetsDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Amount = c.Int(nullable: false),
                        Initial_val = c.Int(nullable: false),
                        Residual_val = c.Int(nullable: false),
                        Assessed_val = c.Int(nullable: false),
                        Unit = c.String(),
                        Count = c.Int(nullable: false),
                        Additional = c.String(),
                        IsMonetary = c.Boolean(nullable: false),
                        LocationId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Info = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assets", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Assets", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Assets", new[] { "CompanyId" });
            DropIndex("dbo.Assets", new[] { "LocationId" });
            DropTable("dbo.Locations");
            DropTable("dbo.Companies");
            DropTable("dbo.Assets");
        }
    }
}
