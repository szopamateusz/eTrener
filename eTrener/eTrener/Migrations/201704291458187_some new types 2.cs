namespace eTrener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somenewtypes2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.IngredientModels", "Weight", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.IngredientModels", "Weight", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
