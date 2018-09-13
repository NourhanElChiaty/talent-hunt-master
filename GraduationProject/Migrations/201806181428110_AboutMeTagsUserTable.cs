namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AboutMeTagsUserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutMeTagsUSerTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tagsid = c.Int(nullable: false),
                        Userid = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tags", t => t.Tagsid, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Userid)
                .Index(t => t.Tagsid)
                .Index(t => t.Userid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AboutMeTagsUSerTables", "Userid", "dbo.AspNetUsers");
            DropForeignKey("dbo.AboutMeTagsUSerTables", "Tagsid", "dbo.Tags");
            DropIndex("dbo.AboutMeTagsUSerTables", new[] { "Userid" });
            DropIndex("dbo.AboutMeTagsUSerTables", new[] { "Tagsid" });
            DropTable("dbo.AboutMeTagsUSerTables");
        }
    }
}
