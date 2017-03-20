namespace eTrener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zmianauserdata : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "userData_Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "userData_Email", c => c.String());
        }
    }
}
