namespace eTrener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dellproperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductModels", "Meal_MealId", "dbo.MealModels");
            DropIndex("dbo.ProductModels", new[] { "Meal_MealId" });
            DropColumn("dbo.ProductModels", "Meal_MealId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductModels", "Meal_MealId", c => c.Int());
            CreateIndex("dbo.ProductModels", "Meal_MealId");
            AddForeignKey("dbo.ProductModels", "Meal_MealId", "dbo.MealModels", "MealId");
        }
    }
}
