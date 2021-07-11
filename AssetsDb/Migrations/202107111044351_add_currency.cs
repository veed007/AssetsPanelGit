namespace AssetsDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_currency : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assets", "Currency", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assets", "Currency");
        }
    }
}
