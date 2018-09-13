namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Imagepath = c.Binary(),
                        Description = c.String(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Userid = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Userid)
                .Index(t => t.Userid);
            
            CreateTable(
                "dbo.TagUserTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tagsid = c.Int(nullable: false),
                        Userid = c.String(maxLength: 128),
                        postid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PostTables", t => t.postid, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.Tagsid, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Userid)
                .Index(t => t.Tagsid)
                .Index(t => t.Userid)
                .Index(t => t.postid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagUserTables", "Userid", "dbo.AspNetUsers");
            DropForeignKey("dbo.TagUserTables", "Tagsid", "dbo.Tags");
            DropForeignKey("dbo.TagUserTables", "postid", "dbo.PostTables");
            DropForeignKey("dbo.PostTables", "Userid", "dbo.AspNetUsers");
            DropIndex("dbo.TagUserTables", new[] { "postid" });
            DropIndex("dbo.TagUserTables", new[] { "Userid" });
            DropIndex("dbo.TagUserTables", new[] { "Tagsid" });
            DropIndex("dbo.PostTables", new[] { "Userid" });
            DropTable("dbo.TagUserTables");
            DropTable("dbo.PostTables");
        }
    }
}
