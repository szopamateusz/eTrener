namespace eTrener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IngredientModels", "Model_ProductId", "dbo.ProductModels");
            DropForeignKey("dbo.IngredientModels", "DietModel_DietId", "dbo.DietModels");
            DropIndex("dbo.IngredientModels", new[] { "Model_ProductId" });
            DropIndex("dbo.IngredientModels", new[] { "DietModel_DietId" });
            CreateTable(
                "dbo.DietPositions",
                c => new
                    {
                        DietPositionId = c.Int(nullable: false, identity: true),
                        DietId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DietPositionId)
                .ForeignKey("dbo.DietModels", t => t.DietId, cascadeDelete: true)
                .ForeignKey("dbo.ProductModels", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.DietId)
                .Index(t => t.ProductId);
            
            DropTable("dbo.IngredientModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.IngredientModels",
                c => new
                    {
                        IngredientId = c.Int(nullable: false, identity: true),
                        Weight = c.Int(nullable: false),
                        Meal = c.String(),
                        Model_ProductId = c.Int(),
                        DietModel_DietId = c.Int(),
                    })
                .PrimaryKey(t => t.IngredientId);
            
            DropForeignKey("dbo.DietPositions", "ProductId", "dbo.ProductModels");
            DropForeignKey("dbo.DietPositions", "DietId", "dbo.DietModels");
            DropIndex("dbo.DietPositions", new[] { "ProductId" });
            DropIndex("dbo.DietPositions", new[] { "DietId" });
            DropTable("dbo.DietPositions");
            CreateIndex("dbo.IngredientModels", "DietModel_DietId");
            CreateIndex("dbo.IngredientModels", "Model_ProductId");
            AddForeignKey("dbo.IngredientModels", "DietModel_DietId", "dbo.DietModels", "DietId");
            AddForeignKey("dbo.IngredientModels", "Model_ProductId", "dbo.ProductModels", "ProductId");
        }
    }
}
