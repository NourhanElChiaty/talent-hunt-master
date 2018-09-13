namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatimeworkshop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workshops", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workshops", "DateTime");
        }
    }
}
