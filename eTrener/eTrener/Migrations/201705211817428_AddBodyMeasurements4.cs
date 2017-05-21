namespace eTrener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBodyMeasurements4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BodyMeasurements", "Weight", c => c.String());
            AlterColumn("dbo.BodyMeasurements", "Neck", c => c.String());
            AlterColumn("dbo.BodyMeasurements", "Chest", c => c.String());
            AlterColumn("dbo.BodyMeasurements", "Biceps", c => c.String());
            AlterColumn("dbo.BodyMeasurements", "Forearm", c => c.String());
            AlterColumn("dbo.BodyMeasurements", "Waist", c => c.String());
            AlterColumn("dbo.BodyMeasurements", "Hip", c => c.String());
            AlterColumn("dbo.BodyMeasurements", "Wrist", c => c.String());
            AlterColumn("dbo.BodyMeasurements", "Thigh", c => c.String());
            AlterColumn("dbo.BodyMeasurements", "Calf", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BodyMeasurements", "Calf", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BodyMeasurements", "Thigh", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BodyMeasurements", "Wrist", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BodyMeasurements", "Hip", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BodyMeasurements", "Waist", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BodyMeasurements", "Forearm", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BodyMeasurements", "Biceps", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BodyMeasurements", "Chest", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BodyMeasurements", "Neck", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BodyMeasurements", "Weight", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
