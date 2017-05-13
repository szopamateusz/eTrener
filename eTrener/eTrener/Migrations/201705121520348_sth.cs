namespace eTrener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sth : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TrainingExcercises", "TrainingTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TrainingExcercises", "TrainingTime", c => c.DateTime(nullable: false));
        }
    }
}
