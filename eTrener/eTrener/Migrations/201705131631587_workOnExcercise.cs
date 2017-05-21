namespace eTrener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workOnExcercise : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrainingExcercises", "ExcerciseName", c => c.String());
            AddColumn("dbo.TrainingExcercises", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.TrainingExcercises", "UserId");
            AddForeignKey("dbo.TrainingExcercises", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainingExcercises", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.TrainingExcercises", new[] { "UserId" });
            DropColumn("dbo.TrainingExcercises", "UserId");
            DropColumn("dbo.TrainingExcercises", "ExcerciseName");
        }
    }
}
