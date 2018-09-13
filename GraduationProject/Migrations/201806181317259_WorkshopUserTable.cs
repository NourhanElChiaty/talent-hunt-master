namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkshopUserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkshopUserTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tagsid = c.Int(nullable: false),
                        Userid = c.String(maxLength: 128),
                        Workshopid = c.Int(nullable: false),
                        Workshops_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tags", t => t.Tagsid, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Userid)
                .ForeignKey("dbo.Workshops", t => t.Workshops_Id)
                .Index(t => t.Tagsid)
                .Index(t => t.Userid)
                .Index(t => t.Workshops_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkshopUserTables", "Workshops_Id", "dbo.Workshops");
            DropForeignKey("dbo.WorkshopUserTables", "Userid", "dbo.AspNetUsers");
            DropForeignKey("dbo.WorkshopUserTables", "Tagsid", "dbo.Tags");
            DropIndex("dbo.WorkshopUserTables", new[] { "Workshops_Id" });
            DropIndex("dbo.WorkshopUserTables", new[] { "Userid" });
            DropIndex("dbo.WorkshopUserTables", new[] { "Tagsid" });
            DropTable("dbo.WorkshopUserTables");
        }
    }
}
