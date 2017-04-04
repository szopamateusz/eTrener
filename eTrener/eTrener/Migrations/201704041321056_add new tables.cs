namespace eTrener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DietModels",
                c => new
                    {
                        DietId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.DietId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MealModels",
                c => new
                    {
                        MealId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Diet_DietId = c.Int(),
                    })
                .PrimaryKey(t => t.MealId)
                .ForeignKey("dbo.DietModels", t => t.Diet_DietId)
                .Index(t => t.Diet_DietId);
            
            CreateTable(
                "dbo.ProductModels",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Calories = c.Double(nullable: false),
                        Fat = c.Double(nullable: false),
                        SaturatedFattyAcids = c.Double(nullable: false),
                        Carbs = c.Double(nullable: false),
                        Sugar = c.Double(nullable: false),
                        Fiber = c.Double(nullable: false),
                        Protein = c.Double(nullable: false),
                        Salt = c.Double(nullable: false),
                        Meal_MealId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.MealModels", t => t.Meal_MealId)
                .Index(t => t.Meal_MealId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DietModels", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductModels", "Meal_MealId", "dbo.MealModels");
            DropForeignKey("dbo.MealModels", "Diet_DietId", "dbo.DietModels");
            DropIndex("dbo.ProductModels", new[] { "Meal_MealId" });
            DropIndex("dbo.MealModels", new[] { "Diet_DietId" });
            DropIndex("dbo.DietModels", new[] { "UserId" });
            DropTable("dbo.ProductModels");
            DropTable("dbo.MealModels");
            DropTable("dbo.DietModels");
        }
    }
}
