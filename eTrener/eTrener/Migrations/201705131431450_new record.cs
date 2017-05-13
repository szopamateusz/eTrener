namespace eTrener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newrecord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrainingExcercises", "ExcerciseName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrainingExcercises", "ExcerciseName");
        }
    }
}
