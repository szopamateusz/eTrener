namespace eTrener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedatabasecolumns : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.IngredientModels", name: "Meal_MealId", newName: "MealModel_MealId");
            RenameIndex(table: "dbo.IngredientModels", name: "IX_Meal_MealId", newName: "IX_MealModel_MealId");
            AddColumn("dbo.IngredientModels", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.IngredientModels", "ProductId");
            AddForeignKey("dbo.IngredientModels", "ProductId", "dbo.ProductModels", "ProductId", cascadeDelete: true);
            DropColumn("dbo.IngredientModels", "Name");
            DropColumn("dbo.IngredientModels", "Calories");
            DropColumn("dbo.IngredientModels", "Protein");
            DropColumn("dbo.IngredientModels", "Carbs");
            DropColumn("dbo.IngredientModels", "Fat");
            DropColumn("dbo.ProductModels", "SaturatedFattyAcids");
            DropColumn("dbo.ProductModels", "Sugar");
            DropColumn("dbo.ProductModels", "Fiber");
            DropColumn("dbo.ProductModels", "Salt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductModels", "Salt", c => c.Double(nullable: false));
            AddColumn("dbo.ProductModels", "Fiber", c => c.Double(nullable: false));
            AddColumn("dbo.ProductModels", "Sugar", c => c.Double(nullable: false));
            AddColumn("dbo.ProductModels", "SaturatedFattyAcids", c => c.Double(nullable: false));
            AddColumn("dbo.IngredientModels", "Fat", c => c.Double(nullable: false));
            AddColumn("dbo.IngredientModels", "Carbs", c => c.Double(nullable: false));
            AddColumn("dbo.IngredientModels", "Protein", c => c.Double(nullable: false));
            AddColumn("dbo.IngredientModels", "Calories", c => c.Double(nullable: false));
            AddColumn("dbo.IngredientModels", "Name", c => c.String());
            DropForeignKey("dbo.IngredientModels", "ProductId", "dbo.ProductModels");
            DropIndex("dbo.IngredientModels", new[] { "ProductId" });
            DropColumn("dbo.IngredientModels", "ProductId");
            RenameIndex(table: "dbo.IngredientModels", name: "IX_MealModel_MealId", newName: "IX_Meal_MealId");
            RenameColumn(table: "dbo.IngredientModels", name: "MealModel_MealId", newName: "Meal_MealId");
        }
    }
}
