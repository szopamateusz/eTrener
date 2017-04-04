namespace eTrener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingredient : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IngredientModels",
                c => new
                    {
                        IngredientId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Calories = c.Double(nullable: false),
                        Protein = c.Double(nullable: false),
                        Carbs = c.Double(nullable: false),
                        Fat = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IngredientId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.IngredientModels");
        }
    }
}
