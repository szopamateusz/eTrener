namespace eTrener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nextmigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.IngredientModels", "Units");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IngredientModels", "Units", c => c.String());
        }
    }
}
