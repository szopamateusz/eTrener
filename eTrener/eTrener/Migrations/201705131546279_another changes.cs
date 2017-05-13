namespace eTrener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotherchanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TrainingExcercises", "Excercise_ExcerciseId", "dbo.Excercises");
            DropForeignKey("dbo.TrainingExcercises", "TrainigLog_TrainingLogId", "dbo.TrainigLogs");
            DropForeignKey("dbo.TrainigLogs", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.TrainingExcercises", new[] { "Excercise_ExcerciseId" });
            DropIndex("dbo.TrainingExcercises", new[] { "TrainigLog_TrainingLogId" });
            DropIndex("dbo.TrainigLogs", new[] { "UserId" });
            DropColumn("dbo.TrainingExcercises", "Excercise_ExcerciseId");
            DropColumn("dbo.TrainingExcercises", "TrainigLog_TrainingLogId");
            DropTable("dbo.TrainigLogs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TrainigLogs",
                c => new
                    {
                        TrainingLogId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TrainingLogId);
            
            AddColumn("dbo.TrainingExcercises", "TrainigLog_TrainingLogId", c => c.Int());
            AddColumn("dbo.TrainingExcercises", "Excercise_ExcerciseId", c => c.Int());
            CreateIndex("dbo.TrainigLogs", "UserId");
            CreateIndex("dbo.TrainingExcercises", "TrainigLog_TrainingLogId");
            CreateIndex("dbo.TrainingExcercises", "Excercise_ExcerciseId");
            AddForeignKey("dbo.TrainigLogs", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TrainingExcercises", "TrainigLog_TrainingLogId", "dbo.TrainigLogs", "TrainingLogId");
            AddForeignKey("dbo.TrainingExcercises", "Excercise_ExcerciseId", "dbo.Excercises", "ExcerciseId");
        }
    }
}
