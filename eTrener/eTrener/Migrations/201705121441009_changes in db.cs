namespace eTrener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesindb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrainingExcercises", "TrainingTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.TrainingExcercises", "TrainingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrainingExcercises", "TrainingId", c => c.Int(nullable: false));
            DropColumn("dbo.TrainingExcercises", "TrainingTime");
        }
    }
}
