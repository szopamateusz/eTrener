namespace eTrener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changenamesoftablesandviews : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DietModels", newName: "DietViewModels");
            RenameTable(name: "dbo.ProductModels", newName: "Products");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Products", newName: "ProductModels");
            RenameTable(name: "dbo.DietViewModels", newName: "DietModels");
        }
    }
}
