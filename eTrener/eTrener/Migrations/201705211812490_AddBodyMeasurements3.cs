namespace eTrener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBodyMeasurements3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BodyMeasurements", "Weight", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BodyMeasurements", "Neck", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BodyMeasurements", "Chest", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BodyMeasurements", "Biceps", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BodyMeasurements", "Forearm", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BodyMeasurements", "Waist", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BodyMeasurements", "Hip", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BodyMeasurements", "Wrist", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BodyMeasurements", "Thigh", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BodyMeasurements", "Calf", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BodyMeasurements", "Calf", c => c.Double(nullable: false));
            AlterColumn("dbo.BodyMeasurements", "Thigh", c => c.Double(nullable: false));
            AlterColumn("dbo.BodyMeasurements", "Wrist", c => c.Double(nullable: false));
            AlterColumn("dbo.BodyMeasurements", "Hip", c => c.Double(nullable: false));
            AlterColumn("dbo.BodyMeasurements", "Waist", c => c.Double(nullable: false));
            AlterColumn("dbo.BodyMeasurements", "Forearm", c => c.Double(nullable: false));
            AlterColumn("dbo.BodyMeasurements", "Biceps", c => c.Double(nullable: false));
            AlterColumn("dbo.BodyMeasurements", "Chest", c => c.Double(nullable: false));
            AlterColumn("dbo.BodyMeasurements", "Neck", c => c.Double(nullable: false));
            AlterColumn("dbo.BodyMeasurements", "Weight", c => c.Double(nullable: false));
        }
    }
}
