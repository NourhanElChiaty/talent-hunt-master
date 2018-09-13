namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class job : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TalentedUserId = c.String(maxLength: 128),
                        JobPostId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Question1 = c.String(nullable: false),
                        Question2 = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobApplicationPosts", t => t.JobPostId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.TalentedUserId)
                .Index(t => t.TalentedUserId)
                .Index(t => t.JobPostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobForms", "TalentedUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.JobForms", "JobPostId", "dbo.JobApplicationPosts");
            DropIndex("dbo.JobForms", new[] { "JobPostId" });
            DropIndex("dbo.JobForms", new[] { "TalentedUserId" });
            DropTable("dbo.JobForms");
        }
    }
}
