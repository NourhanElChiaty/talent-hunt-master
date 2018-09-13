namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Counter2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PostTables", "SelectVa", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PostTables", "SelectVa", c => c.Int(nullable: false));
        }
    }
}
