namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class formsss : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkshopForms", "TalentedUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.WorkshopForms", "WorkshopId", c => c.Int(nullable: false));
            AddColumn("dbo.WorkshopForms", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.WorkshopForms", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.WorkshopForms", "PhoneNumber", c => c.String(nullable: false));
            CreateIndex("dbo.WorkshopForms", "TalentedUserId");
            CreateIndex("dbo.WorkshopForms", "WorkshopId");
            AddForeignKey("dbo.WorkshopForms", "TalentedUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.WorkshopForms", "WorkshopId", "dbo.Workshops", "Id", cascadeDelete: true);
            DropColumn("dbo.WorkshopForms", "name");
            DropColumn("dbo.WorkshopForms", "mobile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkshopForms", "mobile", c => c.String(nullable: false));
            AddColumn("dbo.WorkshopForms", "name", c => c.String(nullable: false));
            DropForeignKey("dbo.WorkshopForms", "WorkshopId", "dbo.Workshops");
            DropForeignKey("dbo.WorkshopForms", "TalentedUserId", "dbo.AspNetUsers");
            DropIndex("dbo.WorkshopForms", new[] { "WorkshopId" });
            DropIndex("dbo.WorkshopForms", new[] { "TalentedUserId" });
            DropColumn("dbo.WorkshopForms", "PhoneNumber");
            DropColumn("dbo.WorkshopForms", "LastName");
            DropColumn("dbo.WorkshopForms", "FirstName");
            DropColumn("dbo.WorkshopForms", "WorkshopId");
            DropColumn("dbo.WorkshopForms", "TalentedUserId");
        }
    }
}
