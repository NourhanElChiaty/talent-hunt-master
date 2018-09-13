namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Counter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostTables", "SelectVa", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostTables", "SelectVa");
        }
    }
}
