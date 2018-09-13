namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CounterTaguser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TagUserTables", "Counter", c => c.Int(nullable: false));
            DropColumn("dbo.PostTables", "SelectVa");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PostTables", "SelectVa", c => c.String());
            DropColumn("dbo.TagUserTables", "Counter");
        }
    }
}
