namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EvenTUserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventUserTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tagsid = c.Int(nullable: false),
                        Userid = c.String(maxLength: 128),
                        Eventid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Eventid, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.Tagsid, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Userid)
                .Index(t => t.Tagsid)
                .Index(t => t.Userid)
                .Index(t => t.Eventid);
            
            DropColumn("dbo.TagUserTables", "Counter");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TagUserTables", "Counter", c => c.Int(nullable: false));
            DropForeignKey("dbo.EventUserTables", "Userid", "dbo.AspNetUsers");
            DropForeignKey("dbo.EventUserTables", "Tagsid", "dbo.Tags");
            DropForeignKey("dbo.EventUserTables", "Eventid", "dbo.Events");
            DropIndex("dbo.EventUserTables", new[] { "Eventid" });
            DropIndex("dbo.EventUserTables", new[] { "Userid" });
            DropIndex("dbo.EventUserTables", new[] { "Tagsid" });
            DropTable("dbo.EventUserTables");
        }
    }
}
