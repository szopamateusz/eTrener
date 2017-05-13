namespace eTrener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesintraininglog : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TrainingExcercises", "ExcerciseId", "dbo.Excercises");
            DropIndex("dbo.TrainingExcercises", new[] { "ExcerciseId" });
            RenameColumn(table: "dbo.TrainingExcercises", name: "ExcerciseId", newName: "Excercise_ExcerciseId");
            RenameColumn(table: "dbo.TrainingExcercises", name: "Log_TrainingLogId", newName: "TrainigLog_TrainingLogId");
            RenameIndex(table: "dbo.TrainingExcercises", name: "IX_Log_TrainingLogId", newName: "IX_TrainigLog_TrainingLogId");
            AddColumn("dbo.TrainingExcercises", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.TrainingExcercises", "Excercise_ExcerciseId", c => c.Int());
            CreateIndex("dbo.TrainingExcercises", "UserId");
            CreateIndex("dbo.TrainingExcercises", "Excercise_ExcerciseId");
            AddForeignKey("dbo.TrainingExcercises", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TrainingExcercises", "Excercise_ExcerciseId", "dbo.Excercises", "ExcerciseId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainingExcercises", "Excercise_ExcerciseId", "dbo.Excercises");
            DropForeignKey("dbo.TrainingExcercises", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.TrainingExcercises", new[] { "Excercise_ExcerciseId" });
            DropIndex("dbo.TrainingExcercises", new[] { "UserId" });
            AlterColumn("dbo.TrainingExcercises", "Excercise_ExcerciseId", c => c.Int(nullable: false));
            DropColumn("dbo.TrainingExcercises", "UserId");
            RenameIndex(table: "dbo.TrainingExcercises", name: "IX_TrainigLog_TrainingLogId", newName: "IX_Log_TrainingLogId");
            RenameColumn(table: "dbo.TrainingExcercises", name: "TrainigLog_TrainingLogId", newName: "Log_TrainingLogId");
            RenameColumn(table: "dbo.TrainingExcercises", name: "Excercise_ExcerciseId", newName: "ExcerciseId");
            CreateIndex("dbo.TrainingExcercises", "ExcerciseId");
            AddForeignKey("dbo.TrainingExcercises", "ExcerciseId", "dbo.Excercises", "ExcerciseId", cascadeDelete: true);
        }
    }
}
