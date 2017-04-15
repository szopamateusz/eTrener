namespace eTrener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdatabaseb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.IngredientModels", "Weight", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ProductModels", "Calories", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ProductModels", "Fat", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ProductModels", "Carbs", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ProductModels", "Protein", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductModels", "Protein", c => c.Double(nullable: false));
            AlterColumn("dbo.ProductModels", "Carbs", c => c.Double(nullable: false));
            AlterColumn("dbo.ProductModels", "Fat", c => c.Double(nullable: false));
            AlterColumn("dbo.ProductModels", "Calories", c => c.Double(nullable: false));
            AlterColumn("dbo.IngredientModels", "Weight", c => c.Double(nullable: false));
        }
    }
}
