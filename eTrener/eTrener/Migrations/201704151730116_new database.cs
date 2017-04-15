namespace eTrener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MealModels", "Diet_DietId", "dbo.DietModels");
            DropForeignKey("dbo.IngredientModels", "MealModel_MealId", "dbo.MealModels");
            DropForeignKey("dbo.IngredientModels", "ProductId", "dbo.ProductModels");
            DropIndex("dbo.MealModels", new[] { "Diet_DietId" });
            DropIndex("dbo.IngredientModels", new[] { "ProductId" });
            DropIndex("dbo.IngredientModels", new[] { "MealModel_MealId" });
            RenameColumn(table: "dbo.IngredientModels", name: "ProductId", newName: "Model_ProductId");
            AddColumn("dbo.IngredientModels", "Units", c => c.String());
            AddColumn("dbo.IngredientModels", "Meal", c => c.String());
            AddColumn("dbo.IngredientModels", "DietModel_DietId", c => c.Int());
            AlterColumn("dbo.IngredientModels", "Model_ProductId", c => c.Int());
            CreateIndex("dbo.IngredientModels", "Model_ProductId");
            CreateIndex("dbo.IngredientModels", "DietModel_DietId");
            AddForeignKey("dbo.IngredientModels", "DietModel_DietId", "dbo.DietModels", "DietId");
            AddForeignKey("dbo.IngredientModels", "Model_ProductId", "dbo.ProductModels", "ProductId");
            DropColumn("dbo.IngredientModels", "MealModel_MealId");
            DropTable("dbo.MealModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MealModels",
                c => new
                    {
                        MealId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Diet_DietId = c.Int(),
                    })
                .PrimaryKey(t => t.MealId);
            
            AddColumn("dbo.IngredientModels", "MealModel_MealId", c => c.Int());
            DropForeignKey("dbo.IngredientModels", "Model_ProductId", "dbo.ProductModels");
            DropForeignKey("dbo.IngredientModels", "DietModel_DietId", "dbo.DietModels");
            DropIndex("dbo.IngredientModels", new[] { "DietModel_DietId" });
            DropIndex("dbo.IngredientModels", new[] { "Model_ProductId" });
            AlterColumn("dbo.IngredientModels", "Model_ProductId", c => c.Int(nullable: false));
            DropColumn("dbo.IngredientModels", "DietModel_DietId");
            DropColumn("dbo.IngredientModels", "Meal");
            DropColumn("dbo.IngredientModels", "Units");
            RenameColumn(table: "dbo.IngredientModels", name: "Model_ProductId", newName: "ProductId");
            CreateIndex("dbo.IngredientModels", "MealModel_MealId");
            CreateIndex("dbo.IngredientModels", "ProductId");
            CreateIndex("dbo.MealModels", "Diet_DietId");
            AddForeignKey("dbo.IngredientModels", "ProductId", "dbo.ProductModels", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.IngredientModels", "MealModel_MealId", "dbo.MealModels", "MealId");
            AddForeignKey("dbo.MealModels", "Diet_DietId", "dbo.DietModels", "DietId");
        }
    }
}
