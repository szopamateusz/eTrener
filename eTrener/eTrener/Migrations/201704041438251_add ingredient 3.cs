namespace eTrener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingredient3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IngredientModels", "Meal_MealId", c => c.Int());
            CreateIndex("dbo.IngredientModels", "Meal_MealId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.IngredientModels", new[] { "Meal_MealId" });
            DropColumn("dbo.IngredientModels", "Meal_MealId");
        }
    }
}
