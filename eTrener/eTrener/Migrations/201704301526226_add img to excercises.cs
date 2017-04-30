namespace eTrener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addimgtoexcercises : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Excercises", "ImgUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Excercises", "ImgUrl");
        }
    }
}
