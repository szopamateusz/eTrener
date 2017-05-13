namespace eTrener.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DietViewModels",
                c => new
                    {
                        DietId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.DietId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.DietPositions",
                c => new
                    {
                        DietPositionId = c.Int(nullable: false, identity: true),
                        DietId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DietPositionId)
                .ForeignKey("dbo.DietViewModels", t => t.DietId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.DietId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Calories = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Carbs = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Protein = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserData_Name = c.String(),
                        UserData_Surname = c.String(),
                        UserData_Age = c.Int(nullable: false),
                        UserData_Sex = c.String(),
                        UserData_Email = c.String(),
                        UserData_Phone = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Excercises",
                c => new
                    {
                        ExcerciseId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        About = c.String(),
                        BodyPart = c.String(),
                        YtUrl = c.String(),
                        ImgUrl = c.String(),
                    })
                .PrimaryKey(t => t.ExcerciseId);
            
            CreateTable(
                "dbo.TrainingExcercises",
                c => new
                    {
                        TrainingElementId = c.Int(nullable: false, identity: true),
                        TrainingTime = c.DateTime(nullable: false),
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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.TrainigLogs", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TrainingExcercises", "Log_TrainingLogId", "dbo.TrainigLogs");
            DropForeignKey("dbo.TrainingExcercises", "ExcerciseId", "dbo.Excercises");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DietViewModels", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DietPositions", "ProductId", "dbo.Products");
            DropForeignKey("dbo.DietPositions", "DietId", "dbo.DietViewModels");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.TrainigLogs", new[] { "UserId" });
            DropIndex("dbo.TrainingExcercises", new[] { "Log_TrainingLogId" });
            DropIndex("dbo.TrainingExcercises", new[] { "ExcerciseId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.DietPositions", new[] { "ProductId" });
            DropIndex("dbo.DietPositions", new[] { "DietId" });
            DropIndex("dbo.DietViewModels", new[] { "UserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TrainigLogs");
            DropTable("dbo.TrainingExcercises");
            DropTable("dbo.Excercises");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Products");
            DropTable("dbo.DietPositions");
            DropTable("dbo.DietViewModels");
        }
    }
}
