namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TalentedId = c.String(nullable: false, maxLength: 128),
                        Event_Name = c.String(),
                        Event_Location = c.String(),
                        Event_Date = c.DateTime(nullable: false),
                        Event_From = c.DateTime(nullable: false),
                        Event_To = c.DateTime(nullable: false),
                        Event_Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.TalentedId, cascadeDelete: true)
                .Index(t => t.TalentedId);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TalentedId = c.String(nullable: false, maxLength: 128),
                        Position = c.String(),
                        Company = c.String(),
                        Skills = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.TalentedId, cascadeDelete: true)
                .Index(t => t.TalentedId);
            
            CreateTable(
                "dbo.JobApplicationPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TalentedId = c.String(nullable: false, maxLength: 128),
                        JobTitle = c.String(),
                        JobLocation = c.String(),
                        JobCategory = c.String(),
                        EmploymentType = c.String(),
                        JobDescription = c.String(),
                        JobRequirements = c.String(),
                        Question = c.String(),
                        Benifits = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.TalentedId, cascadeDelete: true)
                .Index(t => t.TalentedId);
            
            CreateTable(
                "dbo.TalentAcquisitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TalentedId = c.String(nullable: false, maxLength: 128),
                        TA_FirstName = c.String(),
                        TA_LastName = c.String(),
                        TA_Email = c.String(),
                        TA_Company = c.String(),
                        TA_Nationality = c.String(),
                        TA_CompanyDescription = c.String(),
                        TA_Searching = c.String(),
                        TA_Avatar = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.TalentedId, cascadeDelete: true)
                .Index(t => t.TalentedId);
            
            CreateTable(
                "dbo.TalentedUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TalentedId = c.String(nullable: false, maxLength: 128),
                        TU_FirstName = c.String(),
                        TU_LastName = c.String(),
                        TU_Email = c.String(),
                        TU_School = c.String(),
                        TU_DOB = c.DateTime(),
                        TU_ProfiencyLevel = c.String(),
                        TU_Degree = c.String(),
                        TU_Gender = c.String(),
                        TU_Language = c.String(),
                        TU_Nationality = c.String(),
                        TU_SelfDescription = c.String(),
                        TU_Skills = c.String(),
                        TU_Avatar = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.TalentedId, cascadeDelete: true)
                .Index(t => t.TalentedId);
            
            CreateTable(
                "dbo.WorkshopForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        age = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        mobile = c.String(nullable: false),
                        city = c.String(nullable: false),
                        Question1 = c.String(nullable: false),
                        Question2 = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Workshops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TalentedId = c.String(nullable: false, maxLength: 128),
                        workshop_Name = c.String(),
                        workshop_Location = c.String(),
                        workshop_Fees = c.Int(nullable: false),
                        workshop_Date = c.DateTime(nullable: false),
                        workshop_Sessions = c.Int(nullable: false),
                        workshop_Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.TalentedId, cascadeDelete: true)
                .Index(t => t.TalentedId);
            
            AddColumn("dbo.Feedbacks", "TalentedId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Feedbacks", "Message", c => c.String(nullable: false));
            CreateIndex("dbo.Feedbacks", "TalentedId");
            AddForeignKey("dbo.Feedbacks", "TalentedId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Feedbacks", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Feedbacks", "Name", c => c.Int(nullable: false));
            DropForeignKey("dbo.Workshops", "TalentedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TalentedUsers", "TalentedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TalentAcquisitions", "TalentedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.JobApplicationPosts", "TalentedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Feedbacks", "TalentedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Experiences", "TalentedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "TalentedId", "dbo.AspNetUsers");
            DropIndex("dbo.Workshops", new[] { "TalentedId" });
            DropIndex("dbo.TalentedUsers", new[] { "TalentedId" });
            DropIndex("dbo.TalentAcquisitions", new[] { "TalentedId" });
            DropIndex("dbo.JobApplicationPosts", new[] { "TalentedId" });
            DropIndex("dbo.Feedbacks", new[] { "TalentedId" });
            DropIndex("dbo.Experiences", new[] { "TalentedId" });
            DropIndex("dbo.Events", new[] { "TalentedId" });
            DropColumn("dbo.Feedbacks", "Message");
            DropColumn("dbo.Feedbacks", "TalentedId");
            DropTable("dbo.Workshops");
            DropTable("dbo.WorkshopForms");
            DropTable("dbo.TalentedUsers");
            DropTable("dbo.TalentAcquisitions");
            DropTable("dbo.JobApplicationPosts");
            DropTable("dbo.Experiences");
            DropTable("dbo.Events");
        }
    }
}
