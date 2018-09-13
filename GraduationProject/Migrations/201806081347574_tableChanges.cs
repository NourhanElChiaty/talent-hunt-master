namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PostTables", "Tags_Id", "dbo.Tags");
            DropIndex("dbo.PostTables", new[] { "Tags_Id" });
            DropColumn("dbo.PostTables", "Tags_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PostTables", "Tags_Id", c => c.Int());
            CreateIndex("dbo.PostTables", "Tags_Id");
            AddForeignKey("dbo.PostTables", "Tags_Id", "dbo.Tags", "Id");
        }
    }
}
