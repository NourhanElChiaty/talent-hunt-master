namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Trial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostTables", "Tags_Id", c => c.Int());
            CreateIndex("dbo.PostTables", "Tags_Id");
            AddForeignKey("dbo.PostTables", "Tags_Id", "dbo.Tags", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostTables", "Tags_Id", "dbo.Tags");
            DropIndex("dbo.PostTables", new[] { "Tags_Id" });
            DropColumn("dbo.PostTables", "Tags_Id");
        }
    }
}
