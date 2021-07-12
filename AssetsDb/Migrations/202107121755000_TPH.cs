namespace AssetsDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TPH : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assets", "Address", c => c.String());
            AddColumn("dbo.Assets", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Assets", "Initial_val", c => c.Int());
            AlterColumn("dbo.Assets", "Residual_val", c => c.Int());
            AlterColumn("dbo.Assets", "Assessed_val", c => c.Int());
            AlterColumn("dbo.Assets", "Count", c => c.Int());
            DropColumn("dbo.Assets", "IsMonetary");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Assets", "IsMonetary", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Assets", "Count", c => c.Int(nullable: false));
            AlterColumn("dbo.Assets", "Assessed_val", c => c.Int(nullable: false));
            AlterColumn("dbo.Assets", "Residual_val", c => c.Int(nullable: false));
            AlterColumn("dbo.Assets", "Initial_val", c => c.Int(nullable: false));
            DropColumn("dbo.Assets", "Discriminator");
            DropColumn("dbo.Assets", "Address");
        }
    }
}
