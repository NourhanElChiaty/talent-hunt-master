namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimetojobapplicationpost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobApplicationPosts", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobApplicationPosts", "DateTime");
        }
    }
}
