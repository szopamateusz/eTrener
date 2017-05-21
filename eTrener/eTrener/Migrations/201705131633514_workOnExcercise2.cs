namespace eTrener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workOnExcercise2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TrainingExcercises", "ExcerciseId", "dbo.Excercises");
            DropIndex("dbo.TrainingExcercises", new[] { "ExcerciseId" });
            RenameColumn(table: "dbo.TrainingExcercises", name: "Log_TrainingLogId", newName: "TrainigLog_TrainingLogId");
            RenameIndex(table: "dbo.TrainingExcercises", name: "IX_Log_TrainingLogId", newName: "IX_TrainigLog_TrainingLogId");
            DropColumn("dbo.TrainingExcercises", "ExcerciseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TrainingExcercises", "ExcerciseId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.TrainingExcercises", name: "IX_TrainigLog_TrainingLogId", newName: "IX_Log_TrainingLogId");
            RenameColumn(table: "dbo.TrainingExcercises", name: "TrainigLog_TrainingLogId", newName: "Log_TrainingLogId");
            CreateIndex("dbo.TrainingExcercises", "ExcerciseId");
            AddForeignKey("dbo.TrainingExcercises", "ExcerciseId", "dbo.Excercises", "ExcerciseId", cascadeDelete: true);
        }
    }
}
