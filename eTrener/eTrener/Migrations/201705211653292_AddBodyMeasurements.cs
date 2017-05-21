namespace eTrener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBodyMeasurements : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BodyMeasurements",
                c => new
                    {
                        BodyMeasurementdId = c.Int(nullable: false, identity: true),
                        TrainingTime = c.DateTime(nullable: false),
                        Weight = c.Double(nullable: false),
                        Neck = c.Double(nullable: false),
                        Chest = c.Double(nullable: false),
                        Biceps = c.Double(nullable: false),
                        Triceps = c.Double(nullable: false),
                        Forearm = c.Double(nullable: false),
                        Waist = c.Double(nullable: false),
                        Hip = c.Double(nullable: false),
                        Wrist = c.Double(nullable: false),
                        Thigh = c.Double(nullable: false),
                        Calf = c.Double(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BodyMeasurementdId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BodyMeasurements", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.BodyMeasurements", new[] { "UserId" });
            DropTable("dbo.BodyMeasurements");
        }
    }
}
