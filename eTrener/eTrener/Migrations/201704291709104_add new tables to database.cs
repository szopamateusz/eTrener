namespace eTrener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewtablestodatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Excercises",
                c => new
                    {
                        ExcerciseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        About = c.String(),
                        BodyPart = c.String(),
                        YtUrl = c.String(),
                    })
                .PrimaryKey(t => t.ExcerciseId);
            
            CreateTable(
                "dbo.TrainingExcercises",
                c => new
                    {
                        TrainingElementId = c.Int(nullable: false, identity: true),
                        TrainingId = c.Int(nullable: false),
                        ExcerciseId = c.Int(nullable: false),
                        SeriesNumber = c.Int(nullable: false),
                        Repetition = c.Int(nullable: false),
                        Weight = c.Double(nullable: false),
                        Log_TrainingLogId = c.Int(),
                    })
                .PrimaryKey(t => t.TrainingElementId)
                .ForeignKey("dbo.Excercises", t => t.ExcerciseId, cascadeDelete: true)
                .ForeignKey("dbo.TrainigLogs", t => t.Log_TrainingLogId)
                .Index(t => t.ExcerciseId)
                .Index(t => t.Log_TrainingLogId);
            
            CreateTable(
                "dbo.TrainigLogs",
                c => new
                    {
                        TrainingLogId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TrainingLogId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainigLogs", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TrainingExcercises", "Log_TrainingLogId", "dbo.TrainigLogs");
            DropForeignKey("dbo.TrainingExcercises", "ExcerciseId", "dbo.Excercises");
            DropIndex("dbo.TrainigLogs", new[] { "UserId" });
            DropIndex("dbo.TrainingExcercises", new[] { "Log_TrainingLogId" });
            DropIndex("dbo.TrainingExcercises", new[] { "ExcerciseId" });
            DropTable("dbo.TrainigLogs");
            DropTable("dbo.TrainingExcercises");
            DropTable("dbo.Excercises");
        }
    }
}
